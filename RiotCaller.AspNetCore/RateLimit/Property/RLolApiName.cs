﻿using System;
using System.Collections.Generic;
using System.Linq;
using RiotGamesApi.AspNetCore.Enums;
using Force.DeepCloner;

namespace RiotGamesApi.AspNetCore.RateLimit.Property
{
    public class RLolApiName
    {
        private List<LolApiName> _apiNames;
        private object _lock = new object();
        private DateTime _reTryAfter;
        private List<ApiLimit> _limits;
        private RateLimitType? _usedRateLimitType;

        public RLolApiName(List<LolApiName> names, params ApiLimit[] limit) : this(limit)
        {
            ApiNames = names;
        }

        public RLolApiName(params ApiLimit[] limit) : this()
        {
            AddLimit(limit);
        }

        public RLolApiName()
        {
            Limits = new List<ApiLimit>();
            ApiNames = new List<LolApiName>();
        }

        public List<LolApiName> ApiNames
        {
            get
            {
                lock (_lock)
                {
                    return _apiNames;
                }
            }
            set
            {
                lock (_lock)
                {
                    _apiNames = value;
                }
            }
        }

        public RateLimitType? UsedRateLimitType
        {
            get
            {
                var isActive = IsRetryActive.DeepClone();
                lock (_lock)
                {
                    if (!isActive)
                        _usedRateLimitType = null;
                    return _usedRateLimitType;
                }
            }
            set
            {
                lock (_lock)
                    _usedRateLimitType = value;
            }
        }

        public bool IsRetryActive
        {
            get
            {
                return RetryAfter > DateTime.Now;
            }
        }

        public List<ApiLimit> Limits
        {
            get
            {
                lock (_lock)
                    return _limits;
            }
            private set
            {
                lock (_lock)
                    _limits = value;
            }
        }

        public DateTime RetryAfter
        {
            get
            {
                lock (_lock)
                {
                    return _reTryAfter;
                }
            }
            set
            {
                lock (_lock)
                {
                    _reTryAfter = value;
                }
            }
        }

        public void Add(params LolApiName[] val)
        {
            if (val != null)
                ApiNames.AddRange(val);
        }

        public void AddLimit(params ApiLimit[] limit)
        {
            if (limit == null || !limit.Any()) return;
            Limits.AddRange(limit);
            Limits = Enumerable.OrderByDescending<ApiLimit, TimeSpan>(Limits, p => p.Time).ToList();
        }

        public bool ContainsApiName(LolApiName name)
        {
            return ApiNames.Contains(name);
        }
    }
}