using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RiotGamesApi.AspNetCore.Enums;

namespace RiotGamesApi.AspNetCore.RateLimit
{
    public class RateLimitProperties
    {
        public string Platform { get; set; }
        public LolUrlType UrlType { get; set; }
        public LolApiName ApiName { get; set; }

        public override string ToString()
        {
            return $"{Platform}:{UrlType}:{ApiName}";
        }
    }

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
            Regions.TryAdd(region, rut);
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

    public class RUrlType
    {
        private object _lock = new object();
        private ConcurrentDictionary<LolUrlType, RLolApi> _urlTypes = new ConcurrentDictionary<LolUrlType, RLolApi>();

        public ConcurrentDictionary<LolUrlType, RLolApi> UrlTypes
        {
            get
            {
                lock (_lock)
                {
                    return _urlTypes;
                }
            }
            set
            {
                lock (_lock)
                {
                    _urlTypes = value;
                }
            }
        }

        public RLolApi Find(LolUrlType type)
        {
            if (ContainsUrlTypes(type))
            {
                return UrlTypes[type];
            }
            else
            {
                return null;
            }
        }

        public void Add(LolUrlType val, RLolApiName rlan)
        {
            UrlTypes.TryAdd(val, new RLolApi(rlan));
        }

        public void Add(LolUrlType val, RLolApi rlan)
        {
            UrlTypes.TryAdd(val, rlan);
        }

        public bool ContainsUrlTypes(LolUrlType name)
        {
            return UrlTypes.ContainsKey(name);
        }
    }

    public class RLolApi
    {
        private List<RLolApiName> _names;
        private object _lock = new object();

        public RLolApi(RLolApiName rlan) : this()
        {
            Add(rlan);
        }

        public RLolApi()
        {
            Names = new List<RLolApiName>();
        }

        public List<RLolApiName> Names
        {
            get
            {
                lock (_lock)
                    return _names;
            }
            set
            {
                lock (_lock)
                    _names = value;
            }
        }

        public void Add(RLolApiName val)
        {
            Names.Add(val);
        }

        public RLolApiName Find(LolApiName name)
        {
            return Names.FirstOrDefault(p => p.ContainsApiName(name));
        }
    }

    public class RLolApiName
    {
        private object _lock = new object();
        private List<LolApiName> _apiNames;

        public RLolApiName(List<LolApiName> names, params ApiLimit[] limit) : this(limit)
        {
            ApiNames = names;
        }

        public RLolApiName(params ApiLimit[] limit) : this()
        {
            AddLimit(limit);
        }

        public RLolApiName()
        {
            Limits = new List<ApiLimit>();
            ApiNames = new List<LolApiName>();
        }

        public void AddLimit(params ApiLimit[] limit)
        {
            if (limit == null) return;
            Limits.AddRange(limit);
            Limits = Limits.OrderByDescending(p => p.Time).ToList();
        }

        public RLolApiName DeepCopy()
        {
            RLolApiName other = (RLolApiName)this.MemberwiseClone();
            return other;
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

        public void Add(params LolApiName[] val)
        {
            if (val != null)
                ApiNames.AddRange(val);
        }

        public bool ContainsApiName(LolApiName name)
        {
            return ApiNames.Contains(name);
        }

        public List<LolApiName> ApiNames
        {
            get
            {
                lock (_lock)
                {
                    return _apiNames;
                }
            }
            set
            {
                lock (_lock)
                {
                    _apiNames = value;
                }
            }
        }

        public List<ApiLimit> Limits { get; private set; }
    }
}