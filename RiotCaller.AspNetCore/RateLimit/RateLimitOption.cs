using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using RiotGamesApi.AspNetCore.Enums;

namespace RiotGamesApi.AspNetCore.RateLimit
{
    public class RateLimitOption
    {
        public RateLimitOption()
        {
            DisableLimiting = false;
        }

        public ConcurrentDictionary<LolUrlType, RLolApi> All { get; internal set; }

        /// <summary>
        /// default true 
        /// </summary>
        public bool DisableLimiting { get; internal set; }
    }
}