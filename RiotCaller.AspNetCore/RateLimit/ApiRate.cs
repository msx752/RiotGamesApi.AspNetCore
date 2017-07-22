using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RiotGamesApi.AspNetCore.RateLimit
{
    public class ApiRate
    {
        private static object _lock = new object();

        public List<RLimit> RateLimits
        {
            get
            {
                return ApiSettings.RateOptions.RateLimits;
            }
        }

        private DateTime? ReTry { get; set; }

        public void Handle()
        {
            if (RateLimits.Count == 0)
                return;

            lock (_lock)
            {
                //Debug.WriteLine($"{Task.CurrentId}");
                Wait();
            }
        }

        private void Wait()
        {
            TimeSpan currentDelay = (ReTry - DateTime.Now) ?? TimeSpan.Zero;
            foreach (var v in RateLimits)
            {
                if (v.Counter < v.Limit) continue;

                var largestDelay = v.ChainStartTime.Add(v.Time) - DateTime.Now;
                //Debug.WriteLine($"[{DateTime.Now:MM/dd/yyyy HH:mm:ss.fff}] limit:{v.Limit}\tmultipler:{v.Time}\tcount:{v.Counter}\t\tDelay:{largestDelay}");
                if (largestDelay > currentDelay)
                    currentDelay = largestDelay;

                break;
            }
            RateLimits.ForEach((v) =>
            {
                if (v.ChainStartTime <= DateTime.Now.Add(currentDelay) - v.Time)
                    v.Counter = 0;

                v.ChainStartTime = DateTime.Now.Add(currentDelay);
                v.Counter++;
            });
            Task.Delay(currentDelay).Wait();
        }
    }
}