using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.Extensions;
using RiotGamesApi.AspNetCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Caching.Memory;
using RiotGamesApi.AspNetCore.Cache;
using RiotGamesApi.AspNetCore.Models;
using RiotGamesApi.AspNetCore.RateLimit;
using RiotGamesApi.AspNetCore.RiotApi.Enums;

namespace RiotGamesApi.AspNetCore
{
    public static class ApiSettings
    {
        private static IServiceProvider _serviceProvider = null;

        /// <summary>
        /// ApiCache controller 
        /// </summary>
        public static IApiCache ApiCache
        {
            get
            {
                return (IApiCache)ServiceProvider.GetService(typeof(IApiCache));
            }
        }

        /// <summary>
        /// RiotGamesApi all Options 
        /// </summary>
        public static IApiOption ApiOptions
        {
            get
            {
                return (IApiOption)ServiceProvider.GetService(typeof(IApiOption));
            }
        }

        //public static RateLimitOption RateOptions
        //{
        //    get { return ApiOptions.; }
        //}

        //public static ApiRate RateLimiter
        //{
        //    get
        //    {
        //        return (ApiRate)ServiceProvider.GetService(typeof(ApiRate));
        //    }
        //}

        /// <summary>
        /// RiotGamesApi Rate-Limiter 
        /// </summary>
        public static ApiRate ApiRate
        {
            get
            {
                return (ApiRate)ServiceProvider.GetService(typeof(ApiRate));
            }
        }

        /// <summary>
        /// .net core dependency injection 
        /// </summary>
        public static IServiceProvider ServiceProvider
        {
            get { return _serviceProvider; }
            set
            {
                if (_serviceProvider == null)
                    _serviceProvider = value;
            }
        }

        /// <summary>
        /// .net core controller of memory caching 
        /// </summary>
        internal static IMemoryCache MemoryCache
        {
            get
            {
                return (IMemoryCache)ServiceProvider.GetService(typeof(IMemoryCache));
            }
        }
    }
}