using System;
using System.Collections.Generic;
using System.Text;
using RiotGamesApi.AspNetCore.Enums;

namespace RiotGamesApi.AspNetCore.RateLimit
{
    public class LolRateLimit
    {
        public LolRateLimit(LolApiName name)
        {
            ApiName = name;
            ApiMethods = new List<LolApiMethodName>();
        }

        public LolApiName ApiName { get; set; }
        public List<LolApiMethodName> ApiMethods { get; set; }
    }
}