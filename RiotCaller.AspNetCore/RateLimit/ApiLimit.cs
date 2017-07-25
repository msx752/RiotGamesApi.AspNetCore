using RiotGamesApi.AspNetCore.Enums;
using System;

namespace RiotGamesApi.AspNetCore.RateLimit
{
    public class ApiLimit
    {
        public ApiLimit(TimeSpan ts, int limit, RateLimitType limitType = RateLimitType.AppRate)
        {
            Limit = limit;
            Time = ts;
            LimitType = limitType;
        }

        public DateTime ChainStartTime { get; internal set; }
        public int Counter { get; internal set; }
        public int Limit { get; internal set; }
        public RateLimitType LimitType { get; internal set; }
        public TimeSpan Time { get; internal set; }

        public override string ToString()
        {
            return $"{Time}:{Limit}:{Counter}";
        }
    }
}