using System.Collections.Generic;
using RiotGamesApi.AspNetCore.Cache;
using RiotGamesApi.AspNetCore.Enums;

namespace RiotGamesApi.AspNetCore.Interfaces
{
    public interface IRiotGamesApiOption
    {
        CacheOption CacheOptions { get; set; }
        string NonStaticUrl { get; }
        string RiotApiKey { get; set; }
        Dictionary<UrlType, RiotGamesApi> RiotGamesApis { get; set; }
        string StaticUrl { get; }
        string StatusUrl { get; }
        string Url { get; set; }
    }
}