using RiotGamesApi.AspNetCore.Enums;
using System;

namespace RiotGamesApi.AspNetCore.RateLimit
{
    public class ApiLimit
    {
        //private object _lock = new object();
        private int _counter;

        private DateTime _chainStartTime;

        public ApiLimit(TimeSpan ts, int limit, RateLimitType limitType)
        {
            Limit = limit;
            Time = ts;
            LimitType = limitType;
        }

        public DateTime ChainStartTime
        {
            get
            {
                //lock (_lock)
                return _chainStartTime;
            }
            internal set
            {
                //lock (_lock)
                _chainStartTime = value;
            }
        }

        public int Counter
        {
            get
            {
                //lock (_lock)
                return _counter;
            }
            internal set
            {
                //lock (_lock)
                _counter = value;
            }
        }

        public int Limit { get; private set; }
        public RateLimitType LimitType { get; private set; }
        public TimeSpan Time { get; private set; }

        public override string ToString()
        {
            return $"{Time}:{Limit}:{Counter}";
        }
    }
}