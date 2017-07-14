using RiotGamesApi.AspNetCore.Attributes;
using RiotGamesApi.AspNetCore.RiotApi.Enums;

// ReSharper disable InconsistentNaming

namespace RiotGamesApi.AspNetCore.Enums
{
    public enum ApiParameterType
    {
        [ParameterType(typeof(Platform))]
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

        [ParameterType(typeof(Queue))]
        queue,

        [ParameterType(typeof(string))]
        tournamentCode,

        [ParameterType(typeof(string))]
        summonerName,
    }
}