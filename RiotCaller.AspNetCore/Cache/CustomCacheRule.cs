using RiotGamesApi.AspNetCore.Enums;
using System;

namespace RiotGamesApi.AspNetCore.Cache
{
    public class CustomCacheRule
    {
        public CustomCacheRule(LolUrlType urlType, LolApiName apiName, TimeSpan expiryTime)
        {
            this.UrlType = urlType;
            this.ApiName = apiName;
            this.ExpiryTime = expiryTime;
        }

        public LolApiName ApiName { get; set; }
        public TimeSpan ExpiryTime { get; set; }
        public LolUrlType UrlType { get; set; }
    }
}