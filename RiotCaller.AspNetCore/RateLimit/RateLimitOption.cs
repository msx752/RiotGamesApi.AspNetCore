using System;
using System.Collections.Generic;
using System.Linq;

namespace RiotGamesApi.AspNetCore.RateLimit
{
    public class RateLimitOption
    {
        public List<RLimit> RateLimits { get; private set; } = new List<RLimit>();

        public RateLimitOption AddDays(short multiplier, int limit)
        {
            Add(new TimeSpan(multiplier, 0, 0, 0), limit);
            return this;
        }

        public RateLimitOption AddHours(short multiplier, int limit)
        {
            Add(new TimeSpan(multiplier, 0, 0), limit);
            return this;
        }

        public RateLimitOption AddMinutes(short multiplier, int limit)
        {
            Add(new TimeSpan(0, multiplier, 0), limit);
            return this;
        }

        public RateLimitOption AddSeconds(short multiplier, int limit)
        {
            Add(new TimeSpan(0, 0, multiplier), limit);
            return this;
        }

        private void Add(TimeSpan ts, int limit)
        {
            RateLimits.Add(new RLimit(ts, limit));
            RateLimits = RateLimits.OrderByDescending(p => p.Time).ToList();
        }
    }
}