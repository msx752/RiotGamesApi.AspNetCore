using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Force.DeepCloner;
using RiotGamesApi.AspNetCore.Enums;

namespace RiotGamesApi.AspNetCore.RateLimit
{
    public class RateLimitData
    {
        public List<ApiLimit> MergeNormal()
        {
            List<ApiLimit> newl = new List<ApiLimit>();

            newl.AddRange(GetXAppRateLimit());
            newl.AddRange(GetXMethodRateLimit());

            return newl;
        }

        public List<ApiLimit> GetXAppRateLimit()
        {
            return XAppRateLimit;
        }

        public List<ApiLimit> GetXMethodRateLimit()
        {
            return XMethodRateLimit;
        }

        public ApiLimit GetMatchList_XMethodRateLimit()
        {
            return MatchList_XMethodRateLimit;
        }

        public List<ApiLimit> MergeWithMatch()
        {
            List<ApiLimit> newl = new List<ApiLimit>();

            newl.AddRange(GetXAppRateLimit());
            newl.Add(GetMatchList_XMethodRateLimit());

            return newl;
        }

        /// <summary>
        /// default false 
        /// </summary>
        public bool DisableLimiting { get; set; } = false;

        private List<ApiLimit> XAppRateLimit { get; } = new List<ApiLimit>();

        private List<ApiLimit> XMethodRateLimit { get; } = new List<ApiLimit>();

        private ApiLimit MatchList_XMethodRateLimit { get; set; }

        public void AddXAppRateLimits(Dictionary<TimeSpan, int> limits)
        {
            foreach (var li in limits)
            {
                XAppRateLimit.Add(new ApiLimit(li.Key, li.Value));
            }
        }

        //public void AddXAppRateLimit(TimeSpan ts, int limit)
        //{
        //    int index = XAppRateLimit.FindIndex(p => p.Time == ts && p.LimitType == RateLimitType.AppRate);
        //    if (index != -1)
        //        XAppRateLimit.RemoveAt(index);

        //    XAppRateLimit.Add(new ApiLimit(ts, limit, RateLimitType.AppRate));
        //}

        public void AddXMethodRateLimits(Dictionary<TimeSpan, int> limits)
        {
            foreach (var li in limits)
            {
                XMethodRateLimit.Add(new ApiLimit(li.Key, li.Value));
            }
        }

        //public void AddXMethodRateLimit(TimeSpan ts, int limit)
        //{
        //    int index = XMethodRateLimit.FindIndex(p => p.Time == ts && p.LimitType == RateLimitType.MethodRate);
        //    if (index != -1)
        //        XMethodRateLimit.RemoveAt(index);

        //    XMethodRateLimit.Add(new ApiLimit(ts, limit, RateLimitType.MethodRate));
        //}

        public void SetMatchXMethodRateLimit(TimeSpan ts, int limit)
        {
            MatchList_XMethodRateLimit = new ApiLimit(ts, limit, RateLimitType.MethodRate);
        }
    }
}