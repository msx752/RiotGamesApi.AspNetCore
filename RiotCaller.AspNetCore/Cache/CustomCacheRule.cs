using System;
using System.Collections.Generic;
using System.Text;
using RiotGamesApi.AspNetCore.Enums;

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

        public LolUrlType UrlType { get; set; }
        public LolApiName ApiName { get; set; }
        public TimeSpan ExpiryTime { get; set; }
    }
}