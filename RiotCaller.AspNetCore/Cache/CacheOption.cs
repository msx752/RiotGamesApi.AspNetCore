using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RiotGamesApi.AspNetCore.Enums;

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
        /// custom api rules for type of non-static api (default value: false) 
        /// </summary>
        public bool EnableCustomApiCaching { get; set; } = false;

        private List<CustomCacheRule> CustomCacheRules { get; } = new List<CustomCacheRule>();

        /// <summary>
        /// add cache rule for non-static api (only calls in Startup.cs) 
        /// </summary>
        /// <param name="urlType">
        /// api url type 
        /// </param>
        /// <param name="apiName">
        /// api method name 
        /// </param>
        /// <param name="expiryTime">
        /// expiry time (max-limit: 1 hour) 
        /// </param>
        public void AddCacheRule(LolUrlType urlType, LolApiName apiName, TimeSpan expiryTime)
        {
            if (urlType != LolUrlType.Static)
            {
                if (expiryTime.Hours >= 1)
                    expiryTime = new TimeSpan(1, 0, 0);

                var found = FindCacheRule(urlType, apiName);
                if (found == null)
                    CustomCacheRules.Add(new CustomCacheRule(urlType, apiName, expiryTime));
                else
                    found.ExpiryTime = expiryTime;
            }
        }

        /// <summary>
        /// [FOR DEVELOPERS] clears all cache rules (only calls in Startup.cs) 
        /// </summary>
        public void ClearCacheRules()
        {
            CustomCacheRules.Clear();
        }

        /// <summary>
        /// finds exists cache rules 
        /// </summary>
        /// <param name="urlType">
        /// </param>
        /// <param name="apiName">
        /// </param>
        /// <returns>
        /// </returns>
        public CustomCacheRule FindCacheRule(LolUrlType urlType, LolApiName apiName)
        {
            var found = CustomCacheRules.FirstOrDefault(p => p.UrlType == urlType && p.ApiName == apiName);
            return found;
        }

        /// <summary>
        /// default expiry time: 30min 
        /// </summary>
        public TimeSpan StaticApiCacheExpiry { get; set; } = new TimeSpan(0, 30, 0);
    }
}