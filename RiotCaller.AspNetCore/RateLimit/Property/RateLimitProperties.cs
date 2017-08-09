﻿using RiotGamesApi.AspNetCore.Enums;

namespace RiotGamesApi.AspNetCore.RateLimit.Property
{
    public class RateLimitProperties
    {
        public LolApiName ApiName { get; set; }
        public LolApiMethodName ApiMethod { get; set; }
        public string Platform { get; set; }
        public LolUrlType UrlType { get; set; }

        public override string ToString()
        {
            return $"{Platform}:{UrlType}:{ApiName}";
        }
    }
}