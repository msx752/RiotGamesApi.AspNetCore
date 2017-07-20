using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.AspNetCore.RateLimit
{
    public class RateLimitOption
    {
        public Dictionary<TimeSpan, int> Limits { get; set; } =
            new Dictionary<TimeSpan, int>();

        public RateLimitOption AddHours(short timeMultiplier, int limit)
        {
            Limits[new TimeSpan(timeMultiplier, 0, 0)] = limit;
            return this;
        }

        public RateLimitOption AddMinutes(short timeMultiplier, int limit)
        {
            Limits[new TimeSpan(0, timeMultiplier, 0)] = limit;
            return this;
        }

        public RateLimitOption AddSeconds(short timeMultiplier, int limit)
        {
            Limits[new TimeSpan(0, 0, timeMultiplier)] = limit;
            return this;
        }
    }
}