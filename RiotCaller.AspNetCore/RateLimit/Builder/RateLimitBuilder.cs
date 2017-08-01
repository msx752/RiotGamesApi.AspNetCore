using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.RateLimit.Property;

namespace RiotGamesApi.AspNetCore.RateLimit.Builder
{
    public class RateLimitBuilder
    {
        public RateLimitBuilder()
        {
            Limits = new ConcurrentDictionary<LolUrlType, RLolApi>();
        }

        public ConcurrentDictionary<LolUrlType, RLolApi> Limits { get; private set; }

        /// <exception cref="ArgumentNullException">
        /// <paramref name="key" /> is null. 
        /// </exception>
        /// <exception cref="KeyNotFoundException">
        /// The property is retrieved and <paramref name="key" /> does not exist in the collection. 
        /// </exception>
        /// <exception cref="OverflowException">
        /// The dictionary already contains the maximum number of elements ( <see cref="F:System.Int32.MaxValue" />). 
        /// </exception>
        public RateLimitBuilder AddRateLimitFor(LolUrlType type, List<LolApiName> names, List<ApiLimit> limits)
        {
            var rla = new RLolApi();
            var rlan = new RLolApiName();
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