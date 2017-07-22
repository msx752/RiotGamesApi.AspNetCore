using Newtonsoft.Json;
using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.Extensions;
using RiotGamesApi.AspNetCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using RiotGamesApi.AspNetCore.RiotApi.Enums;
using RiotGamesApi.AspNetCore.RiotApi.TournamentStubEndPoints;

namespace RiotGamesApi.AspNetCore.Models
{
    internal class LolApiRequest<T> :
     /*   IRSelectApi<T>,*/ IFor<T>, IAddParameter<T>, IBuild<T>, IRequestMethod<T>, IProperty<T> where T : new()
    {
        private IResult<T> _riotResult;

        public LolApiRequest()
        {
        }

        public LolApiUrl ApiList { get; internal set; }
        public string BaseUrl { get; internal set; }

        public String CacheKey
        {
            get
            {
                return RequestUrl
                    .Replace($"?api_key={ApiSettings.ApiOptions.RiotApiKey}", "");
            }
        }

        public bool Caching { get; internal set; }
        public List<ApiParameter> ParametersWithValue { get; private set; }
        public string RequestUrl { get; private set; }

        public IResult<T> RiotResult
        {
            get { return _riotResult ?? (_riotResult = new RiotGamesApiResult<T>()); }
            set { _riotResult = value; }
        }

        public int SelectedApiIndex { get; private set; } = -1;
        public List<Method> SelectedSubUrlCache { get; internal set; }
        public LolUrlType UrlType { get; internal set; }

        public IBuild<T> AddParameter(params ApiParameter[] parameters)
        {
            if (parameters.Any())
            {
                try
                {
                    ParametersWithValue = parameters.ToList();
                    Method selected = null;
                    foreach (var u in SelectedSubUrlCache)
                    {
                        if (u.RiotGamesApiPaths.Length != parameters.Length)
                            continue;

                        for (var i = 0; i < u.RiotGamesApiPaths.Length; i++)
                        {
                            var u1 = u;
                            if (ParametersWithValue.FirstOrDefault(p => p.Type == u1.RiotGamesApiPaths[i]) != null)
                                selected = u;
                            else
                            {
                                selected = null;
                                break;
                            }
                        }
                        if (selected != null)
                            break;
                    }
                    SelectedSubUrlCache.Clear();
                    if (selected == null)
                        throw new RiotGamesApiException("SelectedSubUrlCache is not found with this parameters");
                    SelectedApiIndex = ApiList.ApiMethods.FindIndex(p => p == selected);
                }
                catch (RiotGamesApiException e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            else
            {
                SelectedSubUrlCache = SelectedSubUrlCache.Where(p => p.RiotGamesApiPaths.Count() == 0).ToList();
            }
            return this;
        }

        public IRequestMethod<T> Build(PhysicalRegion platform)
        {
            return Build(platform.ToString());
        }

        public IRequestMethod<T> Build(string platform)
        {
            try
            {
                Method selected = null;
                if (SelectedApiIndex != -1)
                {
                    selected = ApiList.ApiMethods[SelectedApiIndex];
                }
                else
                {
                    if (SelectedSubUrlCache.Count == 1)
                        selected = SelectedSubUrlCache.First();
                    else
                        throw new RiotGamesApiException("there will be a conflict, i am not sure");
                }
                var newUrl =
                    $"{BaseUrl}/{ApiList.ApiName.GetStringValue()}/{ApiList.Version}/{selected.ApiMethodName.GetStringValue()}";
                newUrl = newUrl.Replace("{platformId}", platform);
                List<LolParameterType> array =
                    ((LolParameterType[])Enum.GetValues(typeof(LolParameterType)))
                    .ToList();
                //url replace value
                for (int i = 0; i < selected.RiotGamesApiPaths.Length; i++)
                {
                    var parameter = selected.RiotGamesApiPaths[i];
                    newUrl = $"{newUrl}/{parameter.GetStringValue()}";
                    var prUrl = parameter.GetStringValue();
                    Regex r = new Regex("\\{\\w+\\}", RegexOptions.RightToLeft);
                    var m = r.Match(prUrl);
                    if (m.Success)
                    {
                        string nameOfParameterType = m.Value;
                        string paramStringVl = parameter.GetStringValue();
                        var para = ParametersWithValue.First(
                            p => p.Type.GetStringValue().IndexOf(paramStringVl) != -1);
                        var parameterType = array.First(p => $"{{{p.ToString()}}}" == nameOfParameterType);
                        Type paraValueGetType = para.Value.GetType();
                        string paraValueToString = para.Value.ToString();
                        if (parameterType.CompareParameterType(paraValueGetType))
                            newUrl = newUrl.Replace(nameOfParameterType, paraValueToString);
                        else
                        {
                            Type parameterTypeGetParameterType = parameterType.GetParameterType();
                            throw new RiotGamesApiException
                                ($"types of parameter value doesn't match: expected:{parameterTypeGetParameterType}, actual:{paraValueGetType}");
                        }

                        if (i == selected.RiotGamesApiPaths.Length - 1)
                        {
                            RequestUrl = newUrl;
                            break;
                        }
                    }
                    else
                    {
                        throw new RiotGamesApiException($"undefined 'parameterType' detected {prUrl}");
                    }
                }
                if (selected.RiotGamesApiPaths.Length == 0)
                {
                    RequestUrl = newUrl;
                }
            }
            catch (RiotGamesApiException e)
            {
                Console.WriteLine(e);
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return this;
        }

        public IRequestMethod<T> Build(ServicePlatform platform)
        {
            return Build(platform.ToString());
        }

        public IAddParameter<T> For(LolApiMethodName middleType)
        {
            SelectedSubUrlCache = ApiList.ApiMethods.Where(p => p.ApiMethodName == middleType).ToList();
            return this;
        }

        public IResult<T> Get(Dictionary<string, object> optionalParameters = null)
        {
            GetAsync(optionalParameters).Wait();
            return RiotResult;
        }

        public async Task<IResult<T>> GetAsync(Dictionary<string, object> optionalParameters = null)
        {
            return await Task.Run(async () =>
             {
                 try
                 {
                     RegisterApiKey();
                     RegisterQueryParameter(optionalParameters);
                     if (CacheControl())
                         return RiotResult;

                     await GetHttpResponse(HttpMethod.Get);
                 }
                 catch (RiotGamesApiException e)
                 {
                     RiotResult.Exception = e;
                     Console.WriteLine(e);
                 }
                 catch (Exception e)
                 {
                     RiotResult.Exception = e;
                     Console.WriteLine(e);
                 }
                 return RiotResult;
             });
        }

        public IResult<T> Post(object bodyParameter = null)
        {
            return Post(new Dictionary<string, object>(), bodyParameter);
        }

        public IResult<T> Post(Dictionary<string, object> optionalParameters = null, object bodyParameter = null)
        {
            PostAsync(optionalParameters, bodyParameter).Wait();
            return RiotResult;
        }

        public Task<IResult<T>> PostAsync(object bodyParameter = null)
        {
            return PostAsync(null, bodyParameter);
        }

        public async Task<IResult<T>> PostAsync(Dictionary<string, object> optionalParameters = null, object bodyParameter = null)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    RegisterApiKey();
                    RegisterQueryParameter(optionalParameters);
                    if (CacheControl())
                        return RiotResult;

                    await GetHttpResponse(HttpMethod.Post);
                }
                catch (RiotGamesApiException e)
                {
                    RiotResult.Exception = e;
                    Console.WriteLine(e);
                }
                catch (Exception e)
                {
                    RiotResult.Exception = e;
                    Console.WriteLine(e);
                }
                return RiotResult;
            });
        }

        public IResult<T> Put(object bodyParameter = null)
        {
            PutAsync(bodyParameter).Wait();
            return RiotResult;
        }

        public async Task<IResult<T>> PutAsync(object bodyParameter = null)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    RegisterApiKey();
                    if (CacheControl())
                        return RiotResult;

                    await GetHttpResponse(HttpMethod.Put);
                }
                catch (RiotGamesApiException e)
                {
                    RiotResult.Exception = e;
                    Console.WriteLine(e);
                }
                catch (Exception e)
                {
                    RiotResult.Exception = e;
                    Console.WriteLine(e);
                }
                return RiotResult;
            });
        }

        public override string ToString()
        {
            if (RequestUrl != null)
                return RequestUrl;
            else
                return base.ToString();
        }

        public IRequestMethod<T> UseCache(bool useCache = false)
        {
            if (ApiSettings.ApiOptions.CacheOptions.EnableStaticApiCaching && this.UrlType == LolUrlType.Static)
                Caching = useCache;
            else
            {
                Caching = false;
            }
            return this;
        }

        private bool CacheControl()
        {
            if (Caching)
            {
                T data;
                var rslt = ApiSettings.ApiCache.Get<T>(this, out data);
                if (rslt)
                {
                    RiotResult.IsCache = true;
                    RiotResult.Result = data;
                    return true;
                }
            }
            return false;
        }

        private async Task GetHttpResponse(HttpMethod method, object bodyData = null)
        {
            if (UrlType == LolUrlType.Static ||
                UrlType == LolUrlType.Tournament)
            {
                ApiSettings.RateLimiter.Handle();
            }

            StringContent data = null;
            if (method == HttpMethod.Put || method == HttpMethod.Post)
            {
                if (bodyData != null)
                    data = new StringContent(JsonConvert.SerializeObject(bodyData));
                else
                    data = new StringContent("");
            }

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, this.RequestUrl);
            request.Headers.Add("UserAgent", "RiotGamesApi.AspNetCore");
            request.Headers.Add("Accept-Language", "tr-TR,tr;q=0.8,en-US;q=0.6,en;q=0.4,ru;q=0.2");
            request.Headers.Add("Accept-Charset", "ISO-8859-1,UTF-8");

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = null;
            if (method == HttpMethod.Get)
                response = await httpClient.GetAsync(request.RequestUri);
            else if (method == HttpMethod.Post)
                response = await httpClient.PostAsync(request.RequestUri, data);
            else if (method == HttpMethod.Put)
                response = await httpClient.PutAsync(request.RequestUri, data);
            else
                throw new RiotGamesApiException("undefined httpMethod request");

            if (!response.IsSuccessStatusCode)
            {
                RiotGamesApiException exp = null;
                if ((int)response.StatusCode == 400)
                    exp = new RiotGamesApiException($"Bad request:{(int)response.StatusCode}");
                else if ((int)response.StatusCode == 401)
                    exp = new RiotGamesApiException($"Unauthorized:{(int)response.StatusCode}");
                else if ((int)response.StatusCode == 403)
                    exp = new RiotGamesApiException($"Forbidden:{(int)response.StatusCode}");
                else if ((int)response.StatusCode == 404)
                    exp = new RiotGamesApiException($"Data not found:{(int)response.StatusCode}");
                else if ((int)response.StatusCode == 405)
                    exp = new RiotGamesApiException($"Method not allowed:{(int)response.StatusCode}");
                else if ((int)response.StatusCode == 415)
                    exp = new RiotGamesApiException($"Unsupported media type:{(int)response.StatusCode}");
                else if ((int)response.StatusCode == 429)
                {
                    //handle response
#if DEBUG
                    Debug.WriteLine(response.Headers);
#endif
                    exp = new RiotGamesApiException($"Rate limit exceeded:{(int)response.StatusCode}");
                }
                else if ((int)response.StatusCode == 500)
                    exp = new RiotGamesApiException($"Internal server error:{(int)response.StatusCode}");
                else if ((int)response.StatusCode == 502)
                    exp = new RiotGamesApiException($"Bad gateway:{(int)response.StatusCode}");
                else if ((int)response.StatusCode == 503)
                    exp = new RiotGamesApiException($"Service unavailable:{(int)response.StatusCode}");
                else if ((int)response.StatusCode == 504)
                    exp = new RiotGamesApiException($"Gateway timeout:{(int)response.StatusCode}");
                else
                    exp = new RiotGamesApiException($"Unknown Error code:{(int)response.StatusCode}");
                throw exp;
            }
            else
            {
                using (HttpContent content = response.Content)
                {
                    string json = await content.ReadAsStringAsync();
                    RiotResult.Result = JsonConvert.DeserializeObject<T>(json);
                }
            }

            if (Caching)
            {
                ApiSettings.ApiCache.Add<T>(this);
            }
        }

        private void RegisterApiKey()
        {
            if (string.IsNullOrWhiteSpace(ApiSettings.ApiOptions.RiotApiKey))
                throw new RiotGamesApiException("api_key is not found, please set key to 'RiotApiMain.Api_Key' ");
            this.RequestUrl += $"?api_key={ApiSettings.ApiOptions.RiotApiKey}";
        }

        private void RegisterQueryParameter(Dictionary<string, object> optionalParameters)
        {
            if (optionalParameters != null)
            {
                foreach (var parameter in optionalParameters)
                {
                    if (parameter.Value != null)
                        this.RequestUrl += $"&{parameter.Key}={parameter.Value}";
                }
            }
        }
    }
}