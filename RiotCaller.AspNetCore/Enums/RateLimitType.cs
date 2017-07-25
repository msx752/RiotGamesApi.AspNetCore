﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.AspNetCore.Enums
{
    /// <summary>
    /// RiotGames X-Rate-Limit-Type 
    /// </summary>
    public enum RateLimitType
    {
        AppRate = 0,
        MethodRate = 1,
        ServiceRate = 2,
    }
}