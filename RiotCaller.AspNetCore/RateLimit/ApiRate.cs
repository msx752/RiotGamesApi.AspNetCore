using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using RiotGamesApi.AspNetCore.Extensions;
using RiotGamesApi.AspNetCore.RiotApi.Enums;

namespace RiotGamesApi.AspNetCore.RateLimit
{
    public class ApiRate
    {
        private static object _lock3 = new object();

        public ConcurrentDictionary<string, RegionLimit> RegionLimits { get; set; } = new ConcurrentDictionary<string, RegionLimit>();

        public void Handle(PhysicalRegion region)
        {
            Handle(region.ToString());
        }

        public void Handle(ServicePlatform region)
        {
            Handle(region.ToString());
        }

        public void Handle(string region)
        {
            Wait(region);
        }

        public void SetRetryTime(PhysicalRegion region, DateTime retryAfter)
        {
            SetRetryTime(region.ToString(), retryAfter);
        }

        public void SetRetryTime(ServicePlatform region, DateTime retryAfter)
        {
            SetRetryTime(region.ToString(), retryAfter);
        }

        public void SetRetryTime(string region, DateTime retryAfter)
        {
            var selected = SelectedRegionLimits(region);
            selected.ReTryAfter = retryAfter;
        }

        private RegionLimit SelectedRegionLimits(string region)
        {
            lock (_lock3)
            {
                RegionLimit regionLimit;
                if (RegionLimits.TryGetValue(region, out regionLimit) == false)
                {
                    regionLimit = new RegionLimit();
                    regionLimit.AddLimits(ApiSettings.RateOptions.RateLimits);
                    RegionLimits.TryAdd(region, regionLimit);
                }
                return regionLimit;
            }
        }

        private void Wait(string region)
        {
            TimeSpan currentDelay = TimeSpan.Zero;
            RegionLimit regionLimit = SelectedRegionLimits(region);
            if (regionLimit.IsRetryActive)
                currentDelay = (regionLimit.ReTryAfter - DateTime.Now);
            foreach (var v in regionLimit.Limits)
            {
                if (v.Counter < v.Limit) continue;

                var largestDelay = v.ChainStartTime.Add(v.Time) - DateTime.Now;
#if DEBUG
                Debug.WriteLine($"[{DateTime.Now:MM/dd/yyyy HH:mm:ss.fff}] limit:{v.Limit}\tmultipler:{v.Time}\tcount:{v.Counter}\t\tDelay:{largestDelay}");
#endif
                if (largestDelay > currentDelay)
                    currentDelay = largestDelay;

                break;
            }
            regionLimit.Limits.ForEach((v) =>
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