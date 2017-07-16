using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.AspNetCore.Cache
{
    public class CacheOption
    {
        public bool EnableStaticApiCaching { get; set; } = false;
        public TimeSpan StaticApiCacheExpiry { get; set; } = new TimeSpan(1, 0, 0);
    }
}