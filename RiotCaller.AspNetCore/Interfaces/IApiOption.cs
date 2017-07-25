using System.Collections.Concurrent;
using RiotGamesApi.AspNetCore.Cache;
using RiotGamesApi.AspNetCore.Enums;
using System.Collections.Generic;
using RiotGamesApi.AspNetCore.RateLimit;

namespace RiotGamesApi.AspNetCore.Interfaces
{ /// <summary>
  /// global RiotGamesApi Options </summary>
    public interface IApiOption
    { /// <summary>
      /// Rate-Limiting options </summary>
        RateLimitOption RateLimitOptions { get; }

        /// <summary>
        /// Api Caching options 
        /// </summary>
        CacheOption CacheOptions { get; set; }

        string NonStaticUrl { get; }
        string RiotApiKey { get; set; }
        Dictionary<LolUrlType, Models.RiotGamesApi> RiotGamesApis { get; set; }
        string StaticUrl { get; }
        string TournamentUrl { get; }
        string StatusUrl { get; }

        /// <summary>
        /// main api request url 
        /// </summary>
        string Url { get; set; }
    }
}