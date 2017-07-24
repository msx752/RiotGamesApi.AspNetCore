using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RiotGamesApi.AspNetCore.Enums;

namespace RiotGamesApi.AspNetCore.RateLimit
{
    public class RateLimitBuilder
    {
        public RateLimitBuilder()
        {
            Limits = new ConcurrentDictionary<LolUrlType, RLolApi>();
        }

        public ConcurrentDictionary<LolUrlType, RLolApi> Limits { get; private set; }
            = new ConcurrentDictionary<LolUrlType, RLolApi>();

        public RateLimitBuilder AddRateLimitFor(LolUrlType type, List<LolApiName> names, List<ApiLimit> limits)
        {
            RLolApi rla = new RLolApi();
            RLolApiName rlan = new RLolApiName();
            rlan.Add(names.Distinct().ToArray());
            rlan.AddLimit(limits.ToArray());
            rla.Add(rlan);
            if (!Limits.ContainsKey(type))
            {
                Limits.TryAdd(type, rla);
            }
            else
            {
                Limits[type].Add(rlan);
            }
            return this;
        }

        public ConcurrentDictionary<LolUrlType, RLolApi> Build()
        {
            return Limits;
        }
    }
}