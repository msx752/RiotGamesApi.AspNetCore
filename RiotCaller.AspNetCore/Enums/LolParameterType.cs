using RiotGamesApi.AspNetCore.Attributes;
using RiotGamesApi.AspNetCore.RiotApi.Enums;
using RiotGamesApi.AspNetCore.RiotApi.Enums.GameConstants;

// ReSharper disable InconsistentNaming

namespace RiotGamesApi.AspNetCore.Enums
{
    /// <summary>
    /// url path parameter data 
    /// </summary>
    public enum LolParameterType
    {
        [ParameterType(typeof(ServicePlatform))]
        platformId,

        [ParameterType(typeof(long))]
        summonerId,

        [ParameterType(typeof(long))]
        championId,

        [ParameterType(typeof(long))]
        matchId,

        [ParameterType(typeof(long))]
        accountId,

        [ParameterType(typeof(long))]
        id,

        [ParameterType(typeof(MatchMakingQueue))]
        queue,

        [ParameterType(typeof(string))]
        tournamentCode,

        [ParameterType(typeof(string))]
        summonerName,
    }
}