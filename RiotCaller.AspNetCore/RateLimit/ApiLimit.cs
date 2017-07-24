using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.AspNetCore.RateLimit
{
    public class ApiLimit
    {
        public ApiLimit(TimeSpan ts, int limit)
        {
            Limit = limit;
            Time = ts;
        }

        public DateTime ChainStartTime { get; internal set; }
        public int Counter { get; internal set; }
        public int Limit { get; internal set; }
        public TimeSpan Time { get; internal set; }

        public ApiLimit DeepCopy()
        {
            ApiLimit other = (ApiLimit)this.MemberwiseClone();
            return other;
        }
    }
}