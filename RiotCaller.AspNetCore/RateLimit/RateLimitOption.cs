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

        public ConcurrentDictionary<LolUrlType, RLolApi> All { get; internal set; }

        /// <summary>
        /// default true 
        /// </summary>
        public bool DisableLimiting { get; internal set; }
    }
}