using RiotGamesApi.AspNetCore.Enums;
using System.Collections.Generic;
using RiotGamesApi.AspNetCore.Cache;

namespace RiotGamesApi.AspNetCore
{
    public interface IRiotGamesApiOption
    {
        CacheOption CacheOptions { get; set; }
        string NonStaticUrl { get; }
        string RiotApiKey { get; set; }
        Dictionary<UrlType, RiotGamesApiApi> RiotGamesApiApis { get; set; }
        string StaticUrl { get; }
        string StatusUrl { get; }
        string Url { get; set; }
    }
}