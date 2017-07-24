using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RiotGamesApi.AspNetCore.RateLimit
{
    public class RegionLimit
    {
        private object _lock = new object();

        //private object _lock2 = new object();

        private List<ApiLimit> _limits;

        public List<ApiLimit> Limits
        {
            get
            {
                lock (_lock)
                {
                    return _limits;
                }
            }
            set
            {
                lock (_lock)
                {
                    _limits = value;
                }
            }
        }

        private DateTime _reTryAfter;

        public DateTime ReTryAfter
        {
            get
            {
                lock (_lock)
                {
                    return _reTryAfter;
                }
            }
            set
            {
                lock (_lock)
                {
                    _reTryAfter = value;
                }
            }
        }

        public bool IsRetryActive
        {
            get
            {
                return ReTryAfter > DateTime.Now;
            }
        }

        public void AddLimits(List<ApiLimit> li)
        {
            Limits = li.Select(r => r.DeepCopy()).ToList();
        }
    }
}