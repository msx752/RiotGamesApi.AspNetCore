﻿using RiotGamesApi.AspNetCore.Cache;
using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.Interfaces;
using System.Collections.Generic;

namespace RiotGamesApi.AspNetCore.Models
{
    public class RiotGamesApiOptions : IApiOption
    {
        private string _url = "";

        public RiotGamesApiOptions()
        {
            RiotGamesApis = new Dictionary<UrlType, Models.RiotGamesApi>();
        }

        public CacheOption CacheOptions { get; set; }
        public string NonStaticUrl { get { return $"{Url}/lol"; }/* set { _nonStaticUrl = value; }*/ }
        public string RiotApiKey { get; set; }
        public Dictionary<UrlType, Models.RiotGamesApi> RiotGamesApis { get; set; }
        public string StaticUrl { get { return $"{NonStaticUrl}"; }/* set { _staticUrl = value; } */}

        public string StatusUrl { get { return $"{Url}/lol"; } }

        public string Url { get { return _url; } set { _url = value; } }

        //private string _staticUrl;
        //private string _nonStaticUrl;
    }
}