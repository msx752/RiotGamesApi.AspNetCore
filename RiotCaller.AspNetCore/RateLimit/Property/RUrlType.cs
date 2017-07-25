using System.Collections.Concurrent;
using RiotGamesApi.AspNetCore.Enums;

namespace RiotGamesApi.AspNetCore.RateLimit.Property
{
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
    }
}