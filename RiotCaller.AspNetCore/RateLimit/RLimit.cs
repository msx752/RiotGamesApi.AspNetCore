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

        public DateTime ChainStartTime { get; internal set; }
        public int Counter { get; internal set; }
        public int Limit { get; internal set; }
        public TimeSpan Time { get; internal set; }

        public void Reset()
        {
            if (ChainStartTime <= DateTime.Now - Time)
                Counter = 0;
            ChainStartTime = DateTime.Now;
            Counter++;
        }

        public RLimit DeepCopy()
        {
            RLimit other = (RLimit)this.MemberwiseClone();
            return other;
        }
    }
}