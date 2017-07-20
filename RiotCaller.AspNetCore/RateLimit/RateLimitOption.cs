using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.AspNetCore.RateLimit
{
    public class RateLimitOption
    {
        public int Every1Seconds { get; set; } = 10;
        public int Every2Minutes { get; set; } = 100;
    }
}