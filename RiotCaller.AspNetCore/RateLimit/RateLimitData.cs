using RiotGamesApi.AspNetCore.Enums;
using System;
using System.Collections.Generic;

namespace RiotGamesApi.AspNetCore.RateLimit
{
    public class RateLimitData
    {
        /// <summary>
        /// disable rate-limiter (default: false) 
        /// </summary>
        public bool DisableLimiting { get; set; } = false;

        private ApiLimit MatchList_XMethodRateLimit { get; set; }

        private List<ApiLimit> XAppRateLimit { get; } = new List<ApiLimit>();

        private List<ApiLimit> XMethodRateLimit { get; } = new List<ApiLimit>();

        /// <summary>
        /// </summary>
        /// <param name="limits">
        /// </param>
        public void AddXAppRateLimits(Dictionary<TimeSpan, int> limits)
        {
            foreach (var li in limits)
            {
                XAppRateLimit.Add(new ApiLimit(li.Key, li.Value, RateLimitType.AppRate));
            }
        }

        public void ClearXAppRateLimits()
        {
            XAppRateLimit.Clear();
        }

        public void ClearXMethodRateLimits()
        {
            XMethodRateLimit.Clear();
        }

        public void AddXMethodRateLimits(Dictionary<TimeSpan, int> limits)
        {
            foreach (var li in limits)
            {
                XMethodRateLimit.Add(new ApiLimit(li.Key, li.Value, RateLimitType.MethodRate));
            }
        }

        public ApiLimit GetMatchList_XMethodRateLimit()
        {
            return MatchList_XMethodRateLimit;
        }

        public List<ApiLimit> GetXAppRateLimit()
        {
            return XAppRateLimit;
        }

        public List<ApiLimit> GetXMethodRateLimit()
        {
            return XMethodRateLimit;
        }

        public List<ApiLimit> MergeNormal()
        {
            List<ApiLimit> newl = new List<ApiLimit>();

            newl.AddRange(GetXAppRateLimit());
            newl.AddRange(GetXMethodRateLimit());

            return newl;
        }

        public List<ApiLimit> MergeWithMatch()
        {
            List<ApiLimit> newl = new List<ApiLimit>();

            newl.AddRange(GetXAppRateLimit());
            newl.Add(GetMatchList_XMethodRateLimit());

            return newl;
        }

        public void ClearMatchApiXMethodRateLimit()
        {
            MatchList_XMethodRateLimit = new ApiLimit(new TimeSpan(0), 9, RateLimitType.MethodRate);
        }

        public void SetMatchApiXMethodRateLimit(TimeSpan ts, int limit)
        {
            MatchList_XMethodRateLimit = new ApiLimit(ts, limit, RateLimitType.MethodRate);
        }
    }
}