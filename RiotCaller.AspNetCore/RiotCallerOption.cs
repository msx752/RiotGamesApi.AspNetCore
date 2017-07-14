using RiotGamesApi.AspNetCore.Enums;
using System.Collections.Generic;
using RiotGamesApi.AspNetCore.Cache;

namespace RiotGamesApi.AspNetCore
{
    public class RiotGamesApiOptions : IRiotGamesApiOption
    {
        private string _url = "";

        public RiotGamesApiOptions()
        {
            RiotGamesApiApis = new Dictionary<UrlType, RiotGamesApiApi>();
        }

        public CacheOption CacheOptions { get; set; }
        public string NonStaticUrl { get { return $"{Url}/lol"; }/* set { _nonStaticUrl = value; }*/ }
        public string RiotApiKey { get; set; }
        public Dictionary<UrlType, RiotGamesApiApi> RiotGamesApiApis { get; set; }
        public string StaticUrl { get { return $"{NonStaticUrl}"; }/* set { _staticUrl = value; } */}

        public string StatusUrl { get { return $"{Url}/lol"; } }

        public string Url { get { return _url; } set { _url = value; } }

        //private string _staticUrl;
        //private string _nonStaticUrl;
    }
}