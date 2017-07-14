using Newtonsoft.Json;
using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.Extensions;
using RiotGamesApi.AspNetCore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using RiotGamesApi.AspNetCore.Interfaces;
using Platform = RiotGamesApi.AspNetCore.RiotApi.Enums.Platform;

namespace RiotGamesApi.AspNetCore
{
    internal class RiotGamesApiRequest<T> :
     /*   IRSelectApi<T>,*/ IFor<T>, IAddParameter<T>, IBuild<T>, IGet<T>, IProperty<T> where T : new()
    {
        private IResult<T> _riotResult;

        public RiotGamesApiRequest()
        {
        }

        public RiotGamesApiUrl ApiList { get; internal set; }
        public string BaseUrl { get; internal set; }
        public List<RiotGamesApiParameter> ParametersWithValue { get; private set; }
        public string RequestUrl { get; private set; }

        public IResult<T> RiotResult
        {
            get { return _riotResult ?? (_riotResult = new RiotGamesApiResult<T>()); }
            set { _riotResult = value; }
        }

        public int SelectedApiIndex { get; private set; } = -1;
        public List<SubUrl> SelectedSubUrlCache { get; internal set; }
        public UrlType UrlType { get; internal set; }
        //moved to another class
        //public IFor<T> SelectApi(ApiName apiType, double version = 3.0)
        //{
        //    UrlType = apiType.GetUrlType();
        //    BaseUrl = RiotGamesApiSettings.RiotGamesApiOptions.RiotGamesApis[UrlType].ApiUrl;
        //    ApiList = RiotGamesApiSettings.RiotGamesApiOptions.RiotGamesApis[UrlType].RiotGamesApiUrls
        //        .FirstOrDefault(p => p.SubUrl == apiType && p.CompareVersion(version));
        //    if (ApiList == null)
        //        throw new Exception($"{UrlType} is not defined in RiotGamesApiBuilder or selected version:{version} is not defined");

        //    return this;
        //}

        public IBuild<T> AddParameter(params RiotGamesApiParameter[] parameters)
        {
            if (parameters.Any())
            {
                try
                {
                    ParametersWithValue = parameters.ToList();
                    SubUrl selected = null;
                    foreach (var u in SelectedSubUrlCache)
                    {
                        if (u.RiotGamesApiSubApiTypes.Length != parameters.Length)
                            continue;

                        for (var i = 0; i < u.RiotGamesApiSubApiTypes.Length; i++)
                        {
                            var u1 = u;
                            if (ParametersWithValue.FirstOrDefault(p => p.Type == u1.RiotGamesApiSubApiTypes[i]) != null)
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
                        throw new Exception("SelectedSubUrl is not found with this parameters");
                    SelectedApiIndex = ApiList.SubUrls.FindIndex(p => p == selected);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            else
            {
                SelectedSubUrlCache = SelectedSubUrlCache.Where(p => p.RiotGamesApiSubApiTypes.Count() == 0).ToList();
            }
            return this;
        }

        public IGet<T> Build(Platform platform)
        {
            try
            {
                SubUrl selected = null;
                if (SelectedApiIndex != -1)
                {
                    selected = ApiList.SubUrls[SelectedApiIndex];
                }
                else
                {
                    if (SelectedSubUrlCache.Count == 1)
                        selected = SelectedSubUrlCache.First();
                    else
                        throw new Exception("there will be a conflict, i am not sure");
                }
                var newUrl = $"{BaseUrl}/{ApiList.SubUrl.GetStringValue()}/{ApiList.Version}/{selected.MiddleType.GetStringValue()}";
                newUrl = newUrl.Replace("{platformId}", platform.ToString());
                List<ApiParameterType> array =
                    ((ApiParameterType[])Enum.GetValues(typeof(ApiParameterType)))
                    .ToList();

                for (var index = 0; index < selected.RiotGamesApiSubApiTypes.Length; index++)
                {
                    var parameter = selected.RiotGamesApiSubApiTypes[index];
                    newUrl = $"{newUrl}/{parameter.GetStringValue()}";
                    //if (index != selected.RiotGamesApiSubApiTypes.Length - 1)
                    //    newUrl += "/";
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
                    if (index == array.Count - 1 || selected.RiotGamesApiSubApiTypes.Length == 0)
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

        public IAddParameter<T> For(ApiMiddleName middleType)
        {
            SelectedSubUrlCache = ApiList.SubUrls.Where(p => p.MiddleType == middleType).ToList();
            return this;
        }

        public IResult<T> Get(params KeyValuePair<string, string>[] optionalParameters)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(RiotGamesApiSettings.RiotGamesApiOptions.RiotApiKey))
                    throw new Exception("api_key is not found, please set key to 'RiotApiMain.Api_Key' ");

                this.RequestUrl += $"?api_key={RiotGamesApiSettings.RiotGamesApiOptions.RiotApiKey}";
                foreach (KeyValuePair<string, string> parameter in optionalParameters)
                {
                    this.RequestUrl += $"&{parameter.Key}={parameter.Value}";
                }
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, this.RequestUrl);
                request.Headers.Add("UserAgent", "RiotGamesApi");
                request.Headers.Add("Accept-Language", "tr-TR,tr;q=0.8,en-US;q=0.6,en;q=0.4,ru;q=0.2");
                request.Headers.Add("Accept-Charset", "ISO-8859-1,UTF-8");
                HttpClient httpClient = new HttpClient();
                using (HttpResponseMessage response = httpClient.GetAsync(request.RequestUri).Result)
                {
                    if (!response.IsSuccessStatusCode)
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
                    else
                    {
                        using (HttpContent content = response.Content)
                        {
                            string json = content.ReadAsStringAsync().Result;
                            RiotResult.Result = JsonConvert.DeserializeObject<T>(json);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                RiotResult.Exception = e;
            }
            return RiotResult;
        }

        public override string ToString()
        {
            if (RequestUrl != null)
                return RequestUrl;
            else
                return base.ToString();
        }
    }
}