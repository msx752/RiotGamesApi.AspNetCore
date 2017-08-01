using RiotGamesApi.AspNetCore.Enums;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace RiotGamesApi.AspNetCore.RateLimit.Property
{
    public class MyRateLimit
    {
        private readonly object _lock = new object();
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

        /// <exception cref="OverflowException">
        /// The dictionary already contains the maximum number of elements ( <see cref="F:System.Int32.MaxValue" />). 
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="key" /> is null. 
        /// </exception>
        public void Add(string region, LolUrlType type, List<LolApiName> apiNames, List<ApiLimit> limits)
        {
            var rut = new RUrlType();
            rut.Add(type, new RLolApiName(apiNames, limits.ToArray()));
            Add(region, rut);
        }

        /// <exception cref="OverflowException">
        /// The dictionary already contains the maximum number of elements ( <see cref="F:System.Int32.MaxValue" />). 
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="key" /> is null. 
        /// </exception>
        public void Add(string region, LolUrlType type, RLolApi rla)
        {
            var rut = new RUrlType();
            rut.Add(type, rla);
            Add(region, rut);
        }

        /// <exception cref="OverflowException">
        /// The dictionary already contains the maximum number of elements ( <see cref="F:System.Int32.MaxValue" />). 
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="key" /> is null. 
        /// </exception>
        public void Add(string region, RUrlType rut)
        {
            Regions.TryAdd(region, rut);
        }

        /// <exception cref="ArgumentNullException">
        /// <paramref name="key" /> is null. 
        /// </exception>
        public bool ContainsUrlTypes(string platform)
        {
            return Regions.ContainsKey(platform);
        }

        /// <exception cref="KeyNotFoundException">
        /// The property is retrieved and <paramref name="key" /> does not exist in the collection. 
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="key" /> is null. 
        /// </exception>
        public RLolApiName Find(string region, LolUrlType type, LolApiName name)
        {
            var rut = Find(region);
            var rla = rut?.Find(type);
            var rlan = rla?.Find(name);
            return rlan;
        }

        /// <exception cref="KeyNotFoundException">
        /// The property is retrieved and <paramref name="key" /> does not exist in the collection. 
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="key" /> is null. 
        /// </exception>
        public RUrlType Find(string region)
        {
            return ContainsUrlTypes(region) ? Regions[region] : null;
        }
    }
}