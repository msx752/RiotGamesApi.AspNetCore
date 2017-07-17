using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace RiotGamesApi.AspNetCore.Models
{
    public class RiotGamesApiUrl
    {
        public RiotGamesApiUrl(ApiName _newApiUrl, double _version)
        {
            SubUrls = new List<SubUrl>();
            SetVersion(_version);
            SubUrl = _newApiUrl;
        }

        public ApiName SubUrl { get; set; }
        public List<SubUrl> SubUrls { get; set; }
        public string Version { get; set; }
        public int LastSubUrlIndex { get; set; }

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
    }

    public class SubUrl
    {
        public SubUrl(ApiMiddleName md, ApiParam[] array, Type returnValueType, ApiRequestType requestType, Type _bodyValueType, bool _isBodyRequired)
            : this(md, array, returnValueType, requestType)
        {
            BodyValueType = _bodyValueType;
            IsBodyRequired = _isBodyRequired;
        }

        public SubUrl(ApiMiddleName md, ApiParam[] array, Type returnValueType, ApiRequestType requestType)
        {
            this.MiddleType = md;
            this.RiotGamesApiSubApiTypes = array ?? new ApiParam[0];
            ReturnValueType = returnValueType;
            QueryParameterTypes = new Dictionary<string, Type>();
            RequestType = requestType;
        }

        public bool IsBodyRequired { get; set; }
        public Type BodyValueType { get; set; }
        public ApiRequestType RequestType { get; set; }
        public ApiMiddleName MiddleType { get; set; }

        public ApiParam[] RiotGamesApiSubApiTypes { get; set; }

        public Type ReturnValueType { get; }
        public Dictionary<string, Type> QueryParameterTypes { get; set; }

        public override string ToString()
        {
            string newSubUrl = $"{MiddleType.GetStringValue()}/";
            for (int i = 0; i < RiotGamesApiSubApiTypes.Length; i++)
            {
                newSubUrl += $"{RiotGamesApiSubApiTypes[i].GetStringValue()}";
                if (i != RiotGamesApiSubApiTypes.Length - 1)
                {
                    newSubUrl += "/";
                }
            }
            return newSubUrl;
        }
    }
}