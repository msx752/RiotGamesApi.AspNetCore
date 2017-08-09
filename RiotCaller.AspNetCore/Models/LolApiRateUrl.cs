using System;
using System.Collections.Generic;
using System.Text;
using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.RateLimit;

namespace RiotGamesApi.AspNetCore.Models
{
    public class LolApiRateUrl
    {
        public LolApiRateUrl SelectPaths(params LolApiMethodName[] paths)
        {
            return this;
        }

        public void SetLimit(params ApiLimit[] limits)
        {
        }
    }
}