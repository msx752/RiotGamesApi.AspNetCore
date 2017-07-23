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
        private static object _lock = new object();

        public ConcurrentDictionary<string, List<RLimit>> RegionLimits { get; } =
            new ConcurrentDictionary<string, List<RLimit>>();

        private DateTime ReTry { get; set; }

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
            lock (_lock)
            {
                //Debug.WriteLine($"{Task.CurrentId}");
                Wait(region);
            }
        }

        private bool IsRetryActive
        {
            get { return ReTry > DateTime.Now; }
        }

        private List<RLimit> SelectedRegionLimits(string region)
        {
            List<RLimit> regionLimit;
            if (RegionLimits.TryGetValue(region, out regionLimit) == false)
            {
                var _rlimits = ApiSettings.RateOptions.RateLimits;
                regionLimit = _rlimits.Select(r => r.DeepCopy()).ToList();
                RegionLimits.TryAdd(region, regionLimit);
            }
            return regionLimit;
        }

        private void Wait(string region)
        {
            List<RLimit> regionLimit = SelectedRegionLimits(region);

            TimeSpan currentDelay = TimeSpan.Zero;
            if (IsRetryActive)
                currentDelay = (ReTry - DateTime.Now);

            foreach (var v in regionLimit)
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
            regionLimit.ForEach((v) =>
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