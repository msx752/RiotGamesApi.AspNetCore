using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.AspNetCore.RateLimit
{
    public class RLimit
    {
        public RLimit(TimeSpan ts, int limit)
        {
            Limit = limit;
            Time = ts;
        }

        public DateTime ChainStartTime { get; protected internal set; }
        public int Counter { get; protected internal set; }
        public int Limit { get; protected internal set; }
        public TimeSpan Time { get; protected internal set; }

        public void Reset()
        {
            if (ChainStartTime <= DateTime.Now - Time)
                Counter = 0;
            ChainStartTime = DateTime.Now;
            Counter++;
        }
    }
}