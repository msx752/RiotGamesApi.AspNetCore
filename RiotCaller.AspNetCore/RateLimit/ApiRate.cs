using Force.DeepCloner;
using RiotGamesApi.AspNetCore.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using RiotGamesApi.AspNetCore.Models;
using RiotGamesApi.AspNetCore.RateLimit.Property;

namespace RiotGamesApi.AspNetCore.RateLimit
{
    public class ApiRate
    {
        private MyRateLimit _rates = new MyRateLimit();

        //private object _lock = new object();
        private object _lock2 = new object();

        public MyRateLimit Rates
        {
            get
            {
                lock (_lock2)
                    return _rates;
            }
            set
            {
                lock (_lock2)
                    _rates = value;
            }
        }

        //public void Add(string region, LolUrlType type, List<LolApiName> apiNames, List<ApiLimit> limits)
        //{
        //    Rates.Add(region, type, apiNames, limits);
        //}

        public void Add(string region, LolUrlType type, RLolApi rla)
        {
            Rates.Add(region, type, rla);
        }

        public RLolApiName FindRate(RateLimitProperties prop)
        {
            return Rates.Find(prop.Platform, prop.UrlType, prop.ApiName);
        }

        public RLolApiName FindRate(string platform, LolUrlType type, LolApiName apiName)
        {
            return Rates.Find(platform, type, apiName);
        }

        public void Handle(RateLimitProperties prop)
        {
            if (ApiSettings.ApiOptions.RateLimitOptions.DisableLimiting == false)
            {
                //DateTime start = DateTime.Now;
                Wait(prop);
                //Debug.WriteLine($"{(DateTime.Now - start).Milliseconds} ms elapsed.");
            }
        }

        public void SetRetryTime(RateLimitProperties prop, RateLimitType limitType, int retryAfterSeconds)
        {
            SetRetryTime(prop.Platform, prop.UrlType, prop.ApiName, limitType, retryAfterSeconds);
        }

        public void SetRetryTime(string region, LolUrlType type, LolApiName name, RateLimitType limitType, int retryAfterSeconds)
        {
            RLolApiName regionLimit = Rates.Find(region, type, name);
            if (regionLimit == null)
            {
                throw new RiotGamesApiException($"Undefined {limitType} limit type for region:{region},type:{type},name:{name}");
            }
            regionLimit.RetryAfter = DateTime.Now.AddSeconds(retryAfterSeconds);
        }

        private void Wait(RateLimitProperties prop)
        {
            TimeSpan currentDelay = TimeSpan.Zero;
            RLolApiName regionLimit = Rates.Find(prop.Platform, prop.UrlType, prop.ApiName);
            if (regionLimit == null)
            {
                var snc = ApiSettings.ApiOptions.RateLimitOptions.All[prop.UrlType];
                Add(prop.Platform, prop.UrlType, snc);
                regionLimit = Rates.Find(prop.Platform, prop.UrlType, prop.ApiName);
            }
            //lock (_lock)
            {
                if (regionLimit.IsRetryActive)
                {
                    currentDelay = (regionLimit.RetryAfter - DateTime.Now);
                    Debug.WriteLine($"UsedRateLimitType: {regionLimit.UsedRateLimitType}");
                }
                foreach (var limit in regionLimit.Limits)
                {
                    //if (!regionLimit.IsRetryActive)
                    //{
                    if (limit.Counter < limit.Limit)
                        continue;
                    //}
                    //else
                    //{
                    //}
                    var largestDelay = limit.ChainStartTime.Add(limit.Time) - DateTime.Now;

                    Debug.WriteLine(
                        $"[{DateTime.Now:MM/dd/yyyy HH:mm:ss.fff}] limit:{limit.Limit}\tregion:{prop.Platform}\ttype:{prop.UrlType}\tapiName:{prop.ApiName}\tmultipler:{limit.Time}\tcount:{limit.Counter}\t\tDelay:{largestDelay}");

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