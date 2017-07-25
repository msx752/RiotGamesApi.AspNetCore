﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.AspNetCore.Cache
{
    /// <summary>
    /// default of ApiCaching is disabled 
    /// </summary>
    public class CacheOption
    {
        /// <summary>
        /// default value: false 
        /// </summary>
        public bool EnableStaticApiCaching { get; set; } = false;

        /// <summary>
        /// default 30min 
        /// </summary>
        public TimeSpan StaticApiCacheExpiry { get; set; } = new TimeSpan(0, 30, 0);
    }
}