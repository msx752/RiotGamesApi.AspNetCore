using RiotGamesApi.AspNetCore.Cache;
using RiotGamesApi.AspNetCore.Enums;
using System.Collections.Generic;

namespace RiotGamesApi.AspNetCore.Interfaces
{
    public interface IApiOption
    {
        CacheOption CacheOptions { get; set; }
        string NonStaticUrl { get; }
        string RiotApiKey { get; set; }
        Dictionary<LolUrlType, Models.RiotGamesApi> RiotGamesApis { get; set; }
        string StaticUrl { get; }
        string TournamentUrl { get; }
        string StatusUrl { get; }
        string Url { get; set; }
    }
}