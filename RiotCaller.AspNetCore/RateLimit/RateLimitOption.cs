using RiotGamesApi.AspNetCore.Enums;
using System.Collections.Concurrent;
using RiotGamesApi.AspNetCore.RateLimit.Property;

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