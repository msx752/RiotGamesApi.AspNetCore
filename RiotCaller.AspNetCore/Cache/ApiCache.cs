using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Caching.Memory;
using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.Interfaces;
using RiotGamesApi.AspNetCore.Models;

namespace RiotGamesApi.AspNetCore.Cache
{
    public class ApiCache : IApiCache
    {
        private CacheOption _cacheOption;
        private IMemoryCache _memoryCache;

        public CacheOption CacheOption
        {
            get
            {
                return (_cacheOption ?? ApiSettings.ApiOptions.CacheOptions);
            }
            set { _cacheOption = value; }
        }

        internal IMemoryCache MemoryCache
        {
            get
            {
                return (_memoryCache ?? ApiSettings.MemoryCache);
            }
            set { _memoryCache = value; }
        }

        public void Add<T>(IProperty<T> data) where T : new()
        {
            Remove<T>(data);
            var cacheEntryOptions = new MemoryCacheEntryOptions();
            //if (data.UrlType == LolUrlType.Static)
            {
                cacheEntryOptions.SlidingExpiration = CacheOption.StaticApiCacheExpiry;
            }
            //else
            {
                // throw new RiotGamesApiException("cache works with static api for now!");
            }

            MemoryCache.Set(data.CacheKey, data.RiotResult.Result, cacheEntryOptions);
        }

        public bool Get<T>(IProperty<T> data, out T cachedData) where T : new()
        {
            return MemoryCache.TryGetValue<T>(data.CacheKey, out cachedData);
        }

        public void Remove<T>(IProperty<T> data) where T : new()
        {
            MemoryCache.Remove(data.CacheKey);
        }
    }
}