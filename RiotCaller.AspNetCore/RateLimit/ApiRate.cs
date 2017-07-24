using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Force.DeepCloner;
using RiotGamesApi.AspNetCore.Enums;

namespace RiotGamesApi.AspNetCore.RateLimit
{
    public class ApiRate
    {
        private object _lock2 = new object();

        public MyRateLimit Rates
        {
            get
            {
                lock (_lock2)
                    return _rates;
            }
        }

        private object _lock = new object();
        private readonly MyRateLimit _rates = new MyRateLimit();

        public void Handle(RateLimitProperties prop)
        {
            if (ApiSettings.ApiOptions.RateLimitOptions.DisableLimiting == false)
            {
                //DateTime start = DateTime.Now;
                Wait(prop);
                //Debug.WriteLine($"{(DateTime.Now - start).Milliseconds} ms elapsed.");
            }
        }

        public void Add(string region, LolUrlType type, List<LolApiName> apiNames, List<ApiLimit> limits)
        {
            Rates.Add(region, type, apiNames, limits);
        }

        public RLolApiName FindRate(RateLimitProperties prop)
        {
            return Rates.Find(prop.Platform, prop.UrlType, prop.ApiName);
        }

        public RLolApiName FindRate(string platform, LolUrlType type, LolApiName apiName)
        {
            return Rates.Find(platform, type, apiName);
        }

        public void SetRetryTime(RateLimitProperties prop, int reTryAfterSeconds)
        {
            RLolApiName regionLimit = Rates.Find(prop.Platform, prop.UrlType, prop.ApiName);
            regionLimit.ReTryAfter = DateTime.Now.AddSeconds(reTryAfterSeconds);
        }

        public void SetRetryTime(string region, LolUrlType type, LolApiName name, int reTryAfterSeconds)
        {
            RLolApiName regionLimit = Rates.Find(region, type, name);
            regionLimit.ReTryAfter = DateTime.Now.AddSeconds(reTryAfterSeconds);
        }

        private void Wait(RateLimitProperties prop)
        {
            TimeSpan currentDelay = TimeSpan.Zero;
            RLolApiName regionLimit = Rates.Find(prop.Platform, prop.UrlType, prop.ApiName);
            if (regionLimit == null)
            {
                var snc = ApiSettings.ApiOptions.RateLimitOptions.All[prop.UrlType];
                Rates.Add(prop.Platform, prop.UrlType, snc.DeepClone());
                regionLimit = Rates.Find(prop.Platform, prop.UrlType, prop.ApiName);
            }
            lock (_lock)
            {
                if (regionLimit.IsRetryActive)
                    currentDelay = (regionLimit.ReTryAfter - DateTime.Now);
                foreach (var limit in regionLimit.Limits)
                {
                    if (limit.Counter < limit.Limit)
                        continue;

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