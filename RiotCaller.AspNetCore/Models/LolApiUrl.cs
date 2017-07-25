using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace RiotGamesApi.AspNetCore.Models
{
    /// <summary>
    /// lol apiurl creator 
    /// </summary>
    public class LolApiUrl
    {
        /// <summary>
        /// lol apiurl creator 
        /// </summary>
        /// <param name="_newApiUrl">
        /// name of apiMethod 
        /// </param>
        /// <param name="_version">
        /// version of Method 
        /// </param>
        public LolApiUrl(LolApiName _newApiUrl, double _version)
        {
            ApiMethods = new List<Method>();
            SetVersion(_version);
            ApiName = _newApiUrl;
        }

        public LolApiName ApiName { get; set; }

        public List<Method> ApiMethods { get; set; }
        public string Version { get; set; }
        public int LastApiMethodIndex { get; set; }

        public bool CompareVersion(double _destinationVersion)
        {
            string version = _destinationVersion.ToString("F1", CultureInfo.InvariantCulture);
            version = version.Replace(".0", "");
            return Version == $"v{version}";
        }

        public void SetVersion(double _version)
        {
            string version = _version.ToString("F1", CultureInfo.InvariantCulture);
            version = version.Replace(".0", "");
            Version = $"v{version}";
        }

        public double GetVersion()
        {
            return double.Parse(Version.Substring(1), CultureInfo.InvariantCulture);
        }

        public string VersionToString()
        {
            return double.Parse(Version.Substring(1), CultureInfo.InvariantCulture)
                .ToString(CultureInfo.InvariantCulture);
        }

        public LolApiUrl GetMethod(LolApiMethodName middleType, Type returnType, params LolApiPath[] subApis)
        {
            this.ApiMethods.Add(new Method(middleType, subApis, returnType, ApiMethodType.Get));
            this.LastApiMethodIndex = this.ApiMethods.Count - 1;
            return this;
        }

        public LolApiUrl PostMethod(LolApiMethodName middleType, Type returnType, Type bodyValueType, bool IsBodyRequired,
            params LolApiPath[] subApis)
        {
            this.ApiMethods.Add(new Method(middleType, subApis, returnType, ApiMethodType.Post, bodyValueType, IsBodyRequired));
            this.LastApiMethodIndex = this.ApiMethods.Count - 1;
            return this;
        }

        public LolApiUrl PutMethod(LolApiMethodName methodName, Type bodyValueType, bool IsBodyRequired,
            params LolApiPath[] subApis)
        {
            this.ApiMethods.Add(new Method(methodName, subApis, typeof(int), ApiMethodType.Put, bodyValueType, IsBodyRequired));
            this.LastApiMethodIndex = this.ApiMethods.Count - 1;
            return this;
        }

        /// <summary>
        /// Query parameter for static-data and tournament apis OR Post-Request 
        /// </summary>
        /// <param name="queryParameterTypes">
        /// NameOfQuery, ValueTypeOfQuery 
        /// </param>
        /// <returns>
        /// </returns>
        public LolApiUrl AddQueryParameter(Dictionary<string, Type> queryParameterTypes)
        {
            try
            {
                if (this.ApiName == LolApiName.StaticData ||
                    this.ApiName == LolApiName.Tournament ||
                    this.ApiName == LolApiName.TournamentStub)
                {
                    this.ApiMethods[this.LastApiMethodIndex].TypesOfQueryParameter = queryParameterTypes;
                }
                else
                {
                    throw new RiotGamesApiException("QueryParameters only for static-data and tournament");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return this;
        }
    }

    public class Method
    {
        public Method(LolApiMethodName md, LolApiPath[] array, Type returnValueType, ApiMethodType requestType, Type _bodyValueType, bool _isBodyRequired)
            : this(md, array, returnValueType, requestType)
        {
            BodyValueType = _bodyValueType;
            IsBodyRequired = _isBodyRequired;
        }

        public Method(LolApiMethodName md, LolApiPath[] array, Type returnValueType, ApiMethodType requestType)
        {
            this.ApiMethodName = md;
            this.RiotGamesApiPaths = array ?? new LolApiPath[0];
            ReturnValueType = returnValueType;
            TypesOfQueryParameter = new Dictionary<string, Type>();
            RequestType = requestType;
        }

        public bool IsBodyRequired { get; set; }
        public Type BodyValueType { get; set; }
        public ApiMethodType RequestType { get; set; }
        public LolApiMethodName ApiMethodName { get; set; }

        public LolApiPath[] RiotGamesApiPaths { get; set; }

        public Type ReturnValueType { get; }
        public Dictionary<string, Type> TypesOfQueryParameter { get; set; }

        public override string ToString()
        {
            string newSubUrl = $"{ApiMethodName.GetStringValue()}/";
            for (int i = 0; i < RiotGamesApiPaths.Length; i++)
            {
                newSubUrl += $"{RiotGamesApiPaths[i].GetStringValue()}";
                if (i != RiotGamesApiPaths.Length - 1)
                {
                    newSubUrl += "/";
                }
            }
            return newSubUrl;
        }
    }
}