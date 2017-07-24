using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using RiotGamesApi.AspNetCore.Enums;

namespace RiotGamesApi.AspNetCore.RateLimit
{
    public class ApiRate2
    {
        private MyRateLimit Rates = new MyRateLimit();
        private object _lock = new object();

        public void Handle(RateLimitProperties prop)
        {
            //DateTime start = DateTime.Now;
            Wait(prop);
            //Debug.WriteLine($"{(DateTime.Now - start).Milliseconds} ms elapsed.");
        }

        public void Add(string region, LolUrlType type, List<LolApiName> apiNames, List<ApiLimit> limits)
        {
            Rates.Add(region, type, apiNames, limits);
        }

        private void Wait(RateLimitProperties prop)
        {
            TimeSpan currentDelay = TimeSpan.Zero;
            RLolApiName regionLimit = Rates.Find(prop.Platform, prop.UrlType, prop.ApiName);
            if (regionLimit == null) return;
            lock (_lock)
            {
                if (regionLimit.IsRetryActive)
                    currentDelay = (regionLimit.ReTryAfter - DateTime.Now);
                foreach (var limit in regionLimit.Limits)
                {
                    if (limit.Counter < limit.Limit) continue;

                    var largestDelay = limit.ChainStartTime.Add(limit.Time) - DateTime.Now;
#if DEBUG
                    Debug.WriteLine(
                        $"[{DateTime.Now:MM/dd/yyyy HH:mm:ss.fff}] limit:{limit.Limit}\tregion:{prop.Platform}\ttype:{prop.UrlType}\tapiName:{prop.ApiName}\tmultipler:{limit.Time}\tcount:{limit.Counter}\t\tDelay:{largestDelay}");
#endif
                    if (largestDelay > currentDelay)
                        currentDelay = largestDelay;

                    break;
                }
                regionLimit.Limits.ForEach((limit) =>
                {
                    if (limit.ChainStartTime <= DateTime.Now.Add(currentDelay) - limit.Time)
                        limit.Counter = 0;

                    limit.ChainStartTime = DateTime.Now.Add(currentDelay);
                    limit.Counter++;
                });
            }
            Task.Delay(currentDelay).Wait();
        }
    }
}