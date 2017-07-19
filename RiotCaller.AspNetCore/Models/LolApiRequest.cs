using Newtonsoft.Json;
using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.Extensions;
using RiotGamesApi.AspNetCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        public bool Caching { get; internal set; } = false;
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
                        throw new Exception("SelectedSubUrlCache is not found with this parameters");
                    SelectedApiIndex = ApiList.ApiMethods.FindIndex(p => p == selected);
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
                        throw new Exception("there will be a conflict, i am not sure");
                }
                var newUrl = $"{BaseUrl}/{ApiList.ApiName.GetStringValue()}/{ApiList.Version}/{selected.ApiMethodName.GetStringValue()}";
                newUrl = newUrl.Replace("{platformId}", platform);
                List<LolParameterType> array =
                    ((LolParameterType[])Enum.GetValues(typeof(LolParameterType)))
                    .ToList();

                for (var index = 0; index < selected.RiotGamesApiPaths.Length; index++)
                {
                    var parameter = selected.RiotGamesApiPaths[index];
                    newUrl = $"{newUrl}/{parameter.GetStringValue()}";
                }
                //it can change with 'selectedParam.FindParameterType()' method in he future
                for (var index = 0; index < array.Count; index++)
                {
                    var parameterType = array[index];
                    var condition = $"{{{parameterType}}}";
                    var ParameterIndex = newUrl.IndexOf(condition, StringComparison.Ordinal);
                    if (ParameterIndex != -1)
                    {
                        var para = ParametersWithValue.First(p => p.Type.GetStringValue().IndexOf(condition) != -1);

                        if (parameterType.CompareParameterType(para.Value.GetType()))
                            newUrl = newUrl.Replace(condition, para.Value.ToString());
                        else
                            throw new Exception($"types of parameter value doesn't match: expected:{parameterType.GetParameterType()}, actual:{para.Value.GetType()}");
                    }
                    if (index == array.Count - 1 || selected.RiotGamesApiPaths.Length == 0)
                    {
                        RequestUrl = newUrl;
                        break;
                    }
                }
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

                     HttpRequestMessage request = CreateHttpRequest(HttpMethod.Get);
                     HttpClient httpClient = new HttpClient();
                     using (HttpResponseMessage response = await httpClient.GetAsync(request.RequestUri))
                     {
                         GetResult(response);
                     }
                     if (Caching)
                     {
                         ApiSettings.ApiCache.Add<T>(this);
                     }
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

        private void GetResult(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                ExceptionControl(response);
            }
            else
            {
                using (HttpContent content = response.Content)
                {
                    string json = content.ReadAsStringAsync().Result;
                    RiotResult.Result = JsonConvert.DeserializeObject<T>(json);
                }
            }
        }

        public async Task<IResult<T>> PostAsync(Dictionary<string, object> optionalParameters = null, object bodyParameter = null)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    RegisterApiKey();
                    RegisterQueryParameter(optionalParameters);

                    HttpRequestMessage request = CreateHttpRequest(HttpMethod.Post);
                    HttpClient httpClient = new HttpClient();
                    StringContent data = null;
                    if (bodyParameter != null)
                        data = new StringContent(JsonConvert.SerializeObject(bodyParameter));
                    else
                        data = new StringContent("");

                    using (HttpResponseMessage response = await httpClient.PostAsync(request.RequestUri, data))
                    {
                        GetResult(response);
                    }
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
                    HttpRequestMessage request = CreateHttpRequest(HttpMethod.Put);
                    HttpClient httpClient = new HttpClient();
                    StringContent data = null;
                    if (bodyParameter != null)
                        data = new StringContent(JsonConvert.SerializeObject(bodyParameter));
                    else
                        data = new StringContent("");

                    using (HttpResponseMessage response = await httpClient.PutAsync(request.RequestUri, data))
                    {
                        GetResult(response);
                    }
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
            if (ApiSettings.ApiOptions.CacheOptions.EnableStaticApiCaching &&
                this.UrlType == LolUrlType.Static)
                Caching = useCache;
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

        private HttpRequestMessage CreateHttpRequest(HttpMethod method)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, this.RequestUrl);
            request.Headers.Add("UserAgent", "RiotGamesApi.AspNetCore");
            request.Headers.Add("Accept-Language", "tr-TR,tr;q=0.8,en-US;q=0.6,en;q=0.4,ru;q=0.2");
            request.Headers.Add("Accept-Charset", "ISO-8859-1,UTF-8");
            return request;
        }

        private void ExceptionControl(HttpResponseMessage response)
        {
            Exception exp = null;
            if ((int)response.StatusCode == 400)
                exp = new Exception($"Bad request:{(int)response.StatusCode}");
            else if ((int)response.StatusCode == 401)
                exp = new Exception($"Unauthorized:{(int)response.StatusCode}");
            else if ((int)response.StatusCode == 403)
                exp = new Exception($"Forbidden:{(int)response.StatusCode}");
            else if ((int)response.StatusCode == 404)
                exp = new Exception($"Data not found:{(int)response.StatusCode}");
            else if ((int)response.StatusCode == 405)
                exp = new Exception($"Method not allowed:{(int)response.StatusCode}");
            else if ((int)response.StatusCode == 415)
                exp = new Exception($"Unsupported media type:{(int)response.StatusCode}");
            else if ((int)response.StatusCode == 429)
                exp = new Exception($"Rate limit exceeded:{(int)response.StatusCode}");
            else if ((int)response.StatusCode == 500)
                exp = new Exception($"Internal server error:{(int)response.StatusCode}");
            else if ((int)response.StatusCode == 502)
                exp = new Exception($"Bad gateway:{(int)response.StatusCode}");
            else if ((int)response.StatusCode == 503)
                exp = new Exception($"Service unavailable:{(int)response.StatusCode}");
            else if ((int)response.StatusCode == 504)
                exp = new Exception($"Gateway timeout:{(int)response.StatusCode}");
            else
                exp = new Exception($"Unknown Error code:{(int)response.StatusCode}");
            throw exp;
        }

        private void RegisterApiKey()
        {
            if (string.IsNullOrWhiteSpace(ApiSettings.ApiOptions.RiotApiKey))
                throw new Exception("api_key is not found, please set key to 'RiotApiMain.Api_Key' ");
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