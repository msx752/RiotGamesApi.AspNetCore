using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.RateLimit.Property;
using System.Collections.Concurrent;

namespace RiotGamesApi.AspNetCore.RateLimit
{
    public class RateLimitOption
    {
        public RateLimitOption()
        {
            DisableLimiting = false;
        }

        /// <summary>
        /// rate-limits which defined from userSettings 
        /// </summary>
        public ConcurrentDictionary<LolUrlType, RLolApi> All { get; internal set; }

        /// <summary>
        /// disable rate-limiter (default: false) 
        /// </summary>
        public bool DisableLimiting { get; internal set; }
    }
}