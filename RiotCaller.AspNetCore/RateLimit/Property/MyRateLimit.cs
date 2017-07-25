using System.Collections.Concurrent;
using System.Collections.Generic;
using RiotGamesApi.AspNetCore.Enums;

namespace RiotGamesApi.AspNetCore.RateLimit.Property
{
    public class MyRateLimit
    {
        private object _lock = new object();
        private ConcurrentDictionary<string, RUrlType> _regions = new ConcurrentDictionary<string, RUrlType>();

        public ConcurrentDictionary<string, RUrlType> Regions
        {
            get
            {
                lock (_lock)
                {
                    return _regions;
                }
            }
            set
            {
                lock (_lock)
                {
                    _regions = value;
                }
            }
        }

        public void Add(string region, LolUrlType type, List<LolApiName> apiNames, List<ApiLimit> limits)
        {
            var rut = new RUrlType();
            rut.Add(type, new RLolApiName(apiNames, limits.ToArray()));
            Add(region, rut);
        }

        public void Add(string region, LolUrlType type, RLolApi rla)
        {
            var rut = new RUrlType();
            rut.Add(type, rla);
            Add(region, rut);
        }

        public void Add(string region, RUrlType rut)
        {
            Regions.TryAdd(region, rut);
        }

        public bool ContainsUrlTypes(string platform)
        {
            return Regions.ContainsKey(platform);
        }

        public RLolApiName Find(string region, LolUrlType type, LolApiName name)
        {
            RUrlType rut = Find(region);
            RLolApi rla = rut?.Find(type);
            RLolApiName rlan = rla?.Find(name);
            return rlan;
        }

        public RUrlType Find(string region)
        {
            if (ContainsUrlTypes(region))
            {
                return Regions[region];
            }
            else
            {
                return null;
            }
        }
    }
}