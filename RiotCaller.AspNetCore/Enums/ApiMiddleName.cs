using RiotGamesApi.AspNetCore.Attributes;

namespace RiotGamesApi.AspNetCore.Enums
{
    public enum ApiMiddleName
    {
        [StringValue("champion-masteries")]
        ChampionMasteries,

        //[StringValue("scores")]
        Scores,

        //[StringValue("summoners")]
        Summoners,

        Champions,

        //[StringValue("challengerleagues")]
        ChallengerLeagues,

        //[StringValue("leagues")]
        Leagues,

        //[StringValue("masterleagues")]
        MasterLeagues,

        //[StringValue("positions")]
        Positions,

        //[StringValue("masteries")]
        Masteries,

        //[StringValue("matches")]
        Matches,

        //[StringValue("matchlists")]
        MatchLists,

        //[StringValue("timelines")]
        Timelines,

        //[StringValue("runes")]
        Runes,

        [StringValue("active-games")]
        ActiveGames,

        [StringValue("featured-games")]
        FeaturedGames,

        [StringValue("items")]
        Items,

        [StringValue("language-strings")]
        LanguageStrings,

        Languages,

        Maps,

        [StringValue("profile-icons")]
        ProfileIcons,

        Realms,

        [StringValue("summoner-spells")]
        SummonerSpells,

        Versions,

        Codes,

        [StringValue("lobby-events")]
        LobbyEvents,

        ShardData,
        Providers,

        Tournaments,
    }
}