using RiotGamesApi.AspNetCore.Attributes;

namespace RiotGamesApi.AspNetCore.Enums
{
    public enum ApiName
    {
        [UrlType(UrlType.NonStatic)]
        [StringValue("summoner")]
        Summoner,

        [UrlType(UrlType.NonStatic)]
        [StringValue("champion-mastery")]
        ChampionMastery,

        [UrlType(UrlType.NonStatic)]
        //[StringValue("platform")]
        Platform,

        [UrlType(UrlType.NonStatic)]
        //[StringValue("league")]
        League,

        [UrlType(UrlType.NonStatic)]
        //[StringValue("match")]
        Match,

        [UrlType(UrlType.NonStatic)]
        //[StringValue("spectator")]
        Spectator,

        [UrlType(UrlType.Static)]
        [StringValue("static-data")]
        StaticData,

        [UrlType(UrlType.Status)]
        Status,
    }
}