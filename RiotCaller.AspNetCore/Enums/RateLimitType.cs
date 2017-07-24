using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.AspNetCore.Enums
{
    public enum RateLimitType
    {
        AppRate = 0,
        MethodRate = 1,
        ServiceRate = 2,
    }
}