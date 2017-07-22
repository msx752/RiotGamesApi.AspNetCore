using System;
using System.Collections.Generic;

namespace RiotGamesApi.AspNetCore.RateLimit
{
    public class RateLimitOption
    {
        public Dictionary<TimeSpan, int> Limits { get; set; } =
            new Dictionary<TimeSpan, int>();

        public RateLimitOption AddDays(short multiplier, int limit)
        {
            AddTimeSpan(new TimeSpan(multiplier, 0, 0, 0), limit);
            return this;
        }

        public RateLimitOption AddHours(short multiplier, int limit)
        {
            Limits[new TimeSpan(multiplier, 0, 0)] = limit;
            return this;
        }

        public RateLimitOption AddMinutes(short multiplier, int limit)
        {
            AddTimeSpan(new TimeSpan(0, multiplier, 0), limit);
            return this;
        }

        public RateLimitOption AddSeconds(short multiplier, int limit)
        {
            AddTimeSpan(new TimeSpan(0, 0, multiplier), limit);
            return this;
        }

        private void AddTimeSpan(TimeSpan ts, int limit)
        {
            Limits[ts] = limit;
        }
    }
}