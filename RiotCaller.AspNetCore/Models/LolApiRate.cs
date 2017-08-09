using System;
using System.Collections.Generic;
using System.Text;
using RiotGamesApi.AspNetCore.Enums;

namespace RiotGamesApi.AspNetCore.Models
{
    public class LolApiRate
    {
        public LolApiRateUrl For(LolApiName api)
        {
            LolApiRateUrl url = new LolApiRateUrl();

            return url;
        }
    }
}