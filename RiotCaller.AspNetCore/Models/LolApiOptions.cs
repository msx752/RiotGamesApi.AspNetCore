using System.Collections.Concurrent;
using RiotGamesApi.AspNetCore.Cache;
using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.Interfaces;
using System.Collections.Generic;
using RiotGamesApi.AspNetCore.RateLimit;

namespace RiotGamesApi.AspNetCore.Models
{
    /// <summary>
    /// global RiotGamesApi Options 
    /// </summary>
    public class LolApiOptions : IApiOption
    {
        private string _url = "";

        public LolApiOptions()
        {
            RiotGamesApis = new Dictionary<LolUrlType, Models.RiotGamesApi>();
            RateLimitOptions = new RateLimitOption();
        }

        /// <summary>
        /// Rate-Limiting options 
        /// </summary>
        public RateLimitOption RateLimitOptions { get; internal set; }

        /// <summary>
        /// Api Caching options 
        /// </summary>
        public CacheOption CacheOptions { get; set; }

        public string NonStaticUrl { get { return $"{Url}/lol"; }/* set { _nonStaticUrl = value; }*/ }
        public string RiotApiKey { get; set; }
        public Dictionary<LolUrlType, Models.RiotGamesApi> RiotGamesApis { get; set; }
        public string StaticUrl { get { return $"{NonStaticUrl}"; }/* set { _staticUrl = value; } */}

        public string TournamentUrl { get { return $"{Url}/lol"; } }
        public string StatusUrl { get { return $"{Url}/lol"; } }

        /// <summary>
        /// main api request url 
        /// </summary>
        public string Url { get { return _url; } set { _url = value; } }

        //private string _staticUrl;
        //private string _nonStaticUrl;
    }
}