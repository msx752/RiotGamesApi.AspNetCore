using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.Interfaces;
using RiotGamesApi.AspNetCore.Models;
using RiotGamesApi.AspNetCore.RiotApi.Enums;
using RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.ChampionMastery;
using RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League;
using RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Mastery;
using RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Match;
using RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Rune;
using RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Spectator;
using RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Summoner;
using RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Champions;
using RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Items;
using RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.LanguageStrings;
using RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Maps;
using RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Masteries;
using RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Profile;
using RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Realms;
using RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Runes;
using RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.SummonerSpell;
using RiotGamesApi.AspNetCore.RiotApi.StatusEndPoints;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using MasteryDto = RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Masteries.MasteryDto;
using RuneDto = RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Runes.RuneDto;

namespace RiotGamesApi.AspNetCore
{
    // ReSharper disable InconsistentNaming
    //AUTO GENERATED CLASS DO NOT MODIFY
    public static class Api
    {
        //Class1

        //"https://{platformId}.api.riotgames.com/lol
        public static class Status
        {
            //"Status/v3
            public static class Status_v3
            {
                public static IResult<ShardStatus> GetShardData(Platform platform)
                {
                    var rit = new ApiCall()
                        .SelectApi<ShardStatus>(ApiName.Status)
                        .For(ApiMiddleName.ShardData)
                        .AddParameter().Build(platform)
                        .Get();
                    return rit;
                }
            }
        }

        //Class2

        //"https://{platformId}.api.riotgames.com/lol
        public static class Static
        {
            //"StaticData/v3
            public static class StaticData_v3
            {
                public static IResult<ChampionListDto> GetChampions(Platform platform)
                {
                    var rit = new ApiCall()
                        .SelectApi<ChampionListDto>(ApiName.StaticData)
                        .For(ApiMiddleName.Champions)
                        .AddParameter().Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<ChampionDto> GetChampionsOnlyId(Platform platform, Int64 onlyıd)
                {
                    var rit = new ApiCall()
                        .SelectApi<ChampionDto>(ApiName.StaticData)
                        .For(ApiMiddleName.Champions)
                        .AddParameter(new ApiParameter(ApiParam.OnlyId, onlyıd)).Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<ItemListDto> GetItems(Platform platform)
                {
                    var rit = new ApiCall()
                        .SelectApi<ItemListDto>(ApiName.StaticData)
                        .For(ApiMiddleName.Items)
                        .AddParameter().Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<ItemDto> GetItemsOnlyId(Platform platform, Int64 onlyıd)
                {
                    var rit = new ApiCall()
                        .SelectApi<ItemDto>(ApiName.StaticData)
                        .For(ApiMiddleName.Items)
                        .AddParameter(new ApiParameter(ApiParam.OnlyId, onlyıd)).Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<LanguageStringsDto> GetLanguageStrings(Platform platform)
                {
                    var rit = new ApiCall()
                        .SelectApi<LanguageStringsDto>(ApiName.StaticData)
                        .For(ApiMiddleName.LanguageStrings)
                        .AddParameter().Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<List<System.String>> GetLanguages(Platform platform)
                {
                    var rit = new ApiCall()
                        .SelectApi<List<System.String>>(ApiName.StaticData)
                        .For(ApiMiddleName.Languages)
                        .AddParameter().Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<MapDataDto> GetMaps(Platform platform)
                {
                    var rit = new ApiCall()
                        .SelectApi<MapDataDto>(ApiName.StaticData)
                        .For(ApiMiddleName.Maps)
                        .AddParameter().Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<MasteryListDto> GetMasteries(Platform platform)
                {
                    var rit = new ApiCall()
                        .SelectApi<MasteryListDto>(ApiName.StaticData)
                        .For(ApiMiddleName.Masteries)
                        .AddParameter().Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<MasteryDto> GetMasteriesOnlyId(Platform platform, Int64 onlyıd)
                {
                    var rit = new ApiCall()
                        .SelectApi<MasteryDto>(ApiName.StaticData)
                        .For(ApiMiddleName.Masteries)
                        .AddParameter(new ApiParameter(ApiParam.OnlyId, onlyıd)).Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<ProfileIconDataDto> GetProfileIcons(Platform platform)
                {
                    var rit = new ApiCall()
                        .SelectApi<ProfileIconDataDto>(ApiName.StaticData)
                        .For(ApiMiddleName.ProfileIcons)
                        .AddParameter().Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<RealmDto> GetRealms(Platform platform)
                {
                    var rit = new ApiCall()
                        .SelectApi<RealmDto>(ApiName.StaticData)
                        .For(ApiMiddleName.Realms)
                        .AddParameter().Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<RuneListDto> GetRunes(Platform platform)
                {
                    var rit = new ApiCall()
                        .SelectApi<RuneListDto>(ApiName.StaticData)
                        .For(ApiMiddleName.Runes)
                        .AddParameter().Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<RuneDto> GetRunesOnlyId(Platform platform, Int64 onlyıd)
                {
                    var rit = new ApiCall()
                        .SelectApi<RuneDto>(ApiName.StaticData)
                        .For(ApiMiddleName.Runes)
                        .AddParameter(new ApiParameter(ApiParam.OnlyId, onlyıd)).Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<SummonerSpellListDto> GetSummonerSpells(Platform platform)
                {
                    var rit = new ApiCall()
                        .SelectApi<SummonerSpellListDto>(ApiName.StaticData)
                        .For(ApiMiddleName.SummonerSpells)
                        .AddParameter().Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<SummonerSpellDto> GetSummonerSpellsOnlyId(Platform platform, Int64 onlyıd)
                {
                    var rit = new ApiCall()
                        .SelectApi<SummonerSpellDto>(ApiName.StaticData)
                        .For(ApiMiddleName.SummonerSpells)
                        .AddParameter(new ApiParameter(ApiParam.OnlyId, onlyıd)).Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<List<System.String>> GetVersions(Platform platform)
                {
                    var rit = new ApiCall()
                        .SelectApi<List<System.String>>(ApiName.StaticData)
                        .For(ApiMiddleName.Versions)
                        .AddParameter().Build(platform)
                        .Get();
                    return rit;
                }
            }
        }

        //Class3

        //"https://{platformId}.api.riotgames.com/lol
        public static class NonStatic
        {
            //"ChampionMastery/v3
            public static class ChampionMastery_v3
            {
                public static IResult<List<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.ChampionMastery.ChampionMasteryDto>> GetChampionMasteriesBySummoner(Platform platform, Int64 bysummoner)
                {
                    var rit = new ApiCall()
                        .SelectApi<List<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.ChampionMastery.ChampionMasteryDto>>(ApiName.ChampionMastery)
                        .For(ApiMiddleName.ChampionMasteries)
                        .AddParameter(new ApiParameter(ApiParam.BySummoner, bysummoner)).Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<ChampionMasteryDto> GetChampionMasteriesBySummoner(Platform platform, Int64 bysummoner, Int64 bychampion)
                {
                    var rit = new ApiCall()
                        .SelectApi<ChampionMasteryDto>(ApiName.ChampionMastery)
                        .For(ApiMiddleName.ChampionMasteries)
                        .AddParameter(new ApiParameter(ApiParam.BySummoner, bysummoner),
                            new ApiParameter(ApiParam.ByChampion, bychampion)).Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<Int32> GetScoresBySummoner(Platform platform, Int64 bysummoner)
                {
                    var rit = new ApiCall()
                        .SelectApi<Int32>(ApiName.ChampionMastery)
                        .For(ApiMiddleName.Scores)
                        .AddParameter(new ApiParameter(ApiParam.BySummoner, bysummoner)).Build(platform)
                        .Get();
                    return rit;
                }
            }

            //"Summoner/v3
            public static class Summoner_v3
            {
                public static IResult<SummonerDto> GetSummonersByAccount(Platform platform, Int64 byaccount)
                {
                    var rit = new ApiCall()
                        .SelectApi<SummonerDto>(ApiName.Summoner)
                        .For(ApiMiddleName.Summoners)
                        .AddParameter(new ApiParameter(ApiParam.ByAccount, byaccount)).Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<SummonerDto> GetSummonersByName(Platform platform, String byname)
                {
                    var rit = new ApiCall()
                        .SelectApi<SummonerDto>(ApiName.Summoner)
                        .For(ApiMiddleName.Summoners)
                        .AddParameter(new ApiParameter(ApiParam.ByName, byname)).Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<SummonerDto> GetSummonersOnlySummonerId(Platform platform, Int64 onlysummonerıd)
                {
                    var rit = new ApiCall()
                        .SelectApi<SummonerDto>(ApiName.Summoner)
                        .For(ApiMiddleName.Summoners)
                        .AddParameter(new ApiParameter(ApiParam.OnlySummonerId, onlysummonerıd)).Build(platform)
                        .Get();
                    return rit;
                }
            }

            //"Platform/v3
            public static class Platform_v3
            {
                public static IResult<ChampionListDto> GetChampions(Platform platform)
                {
                    var rit = new ApiCall()
                        .SelectApi<ChampionListDto>(ApiName.Platform)
                        .For(ApiMiddleName.Champions)
                        .AddParameter().Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<ChampionDto> GetChampionsOnlyId(Platform platform, Int64 onlyıd)
                {
                    var rit = new ApiCall()
                        .SelectApi<ChampionDto>(ApiName.Platform)
                        .For(ApiMiddleName.Champions)
                        .AddParameter(new ApiParameter(ApiParam.OnlyId, onlyıd)).Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<MasteryPagesDto> GetMasteriesBySummoner(Platform platform, Int64 bysummoner)
                {
                    var rit = new ApiCall()
                        .SelectApi<MasteryPagesDto>(ApiName.Platform)
                        .For(ApiMiddleName.Masteries)
                        .AddParameter(new ApiParameter(ApiParam.BySummoner, bysummoner)).Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<RunePagesDto> GetRunesBySummoner(Platform platform, Int64 bysummoner)
                {
                    var rit = new ApiCall()
                        .SelectApi<RunePagesDto>(ApiName.Platform)
                        .For(ApiMiddleName.Runes)
                        .AddParameter(new ApiParameter(ApiParam.BySummoner, bysummoner)).Build(platform)
                        .Get();
                    return rit;
                }
            }

            //"League/v3
            public static class League_v3
            {
                public static IResult<LeagueListDTO> GetChallengerLeaguesByQueue(Platform platform, Queue byqueue)
                {
                    var rit = new ApiCall()
                        .SelectApi<LeagueListDTO>(ApiName.League)
                        .For(ApiMiddleName.ChallengerLeagues)
                        .AddParameter(new ApiParameter(ApiParam.ByQueue, byqueue)).Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<List<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League.LeagueListDTO>> GetLeaguesBySummoner(Platform platform, Int64 bysummoner)
                {
                    var rit = new ApiCall()
                        .SelectApi<List<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League.LeagueListDTO>>(ApiName.League)
                        .For(ApiMiddleName.Leagues)
                        .AddParameter(new ApiParameter(ApiParam.BySummoner, bysummoner)).Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<LeagueListDTO> GetMasterLeaguesByQueue(Platform platform, Queue byqueue)
                {
                    var rit = new ApiCall()
                        .SelectApi<LeagueListDTO>(ApiName.League)
                        .For(ApiMiddleName.MasterLeagues)
                        .AddParameter(new ApiParameter(ApiParam.ByQueue, byqueue)).Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<List<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League.LeaguePositionDTO>> GetPositionsBySummoner(Platform platform, Int64 bysummoner)
                {
                    var rit = new ApiCall()
                        .SelectApi<List<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League.LeaguePositionDTO>>(ApiName.League)
                        .For(ApiMiddleName.Positions)
                        .AddParameter(new ApiParameter(ApiParam.BySummoner, bysummoner)).Build(platform)
                        .Get();
                    return rit;
                }
            }

            //"Match/v3
            public static class Match_v3
            {
                public static IResult<MatchDto> GetMatchesOnlyMatchId(Platform platform, Int64 onlymatchıd)
                {
                    var rit = new ApiCall()
                        .SelectApi<MatchDto>(ApiName.Match)
                        .For(ApiMiddleName.Matches)
                        .AddParameter(new ApiParameter(ApiParam.OnlyMatchId, onlymatchıd)).Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<MatchlistDto> GetMatchListsByAccount(Platform platform, Int64 byaccount)
                {
                    var rit = new ApiCall()
                        .SelectApi<MatchlistDto>(ApiName.Match)
                        .For(ApiMiddleName.MatchLists)
                        .AddParameter(new ApiParameter(ApiParam.ByAccount, byaccount)).Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<MatchlistDto> GetMatchListsByAccountRecent(Platform platform, Int64 byaccountrecent)
                {
                    var rit = new ApiCall()
                        .SelectApi<MatchlistDto>(ApiName.Match)
                        .For(ApiMiddleName.MatchLists)
                        .AddParameter(new ApiParameter(ApiParam.ByAccountRecent, byaccountrecent)).Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<MatchTimelineDto> GetTimelinesByMatch(Platform platform, Int64 bymatch)
                {
                    var rit = new ApiCall()
                        .SelectApi<MatchTimelineDto>(ApiName.Match)
                        .For(ApiMiddleName.Timelines)
                        .AddParameter(new ApiParameter(ApiParam.ByMatch, bymatch)).Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<List<System.Int64>> GetMatchesByTournamentCodeIds(Platform platform, String bytournamentcodeıds)
                {
                    var rit = new ApiCall()
                        .SelectApi<List<System.Int64>>(ApiName.Match)
                        .For(ApiMiddleName.Matches)
                        .AddParameter(new ApiParameter(ApiParam.ByTournamentCodeIds, bytournamentcodeıds)).Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<MatchDto> GetMatchesOnlyMatchId(Platform platform, Int64 onlymatchıd, String bytournamentcode)
                {
                    var rit = new ApiCall()
                        .SelectApi<MatchDto>(ApiName.Match)
                        .For(ApiMiddleName.Matches)
                        .AddParameter(new ApiParameter(ApiParam.OnlyMatchId, onlymatchıd),
                            new ApiParameter(ApiParam.ByTournamentCode, bytournamentcode)).Build(platform)
                        .Get();
                    return rit;
                }
            }

            //"Spectator/v3
            public static class Spectator_v3
            {
                public static IResult<CurrentGameInfo> GetActiveGamesBySummoner(Platform platform, Int64 bysummoner)
                {
                    var rit = new ApiCall()
                        .SelectApi<CurrentGameInfo>(ApiName.Spectator)
                        .For(ApiMiddleName.ActiveGames)
                        .AddParameter(new ApiParameter(ApiParam.BySummoner, bysummoner)).Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<FeaturedGames> GetFeaturedGames(Platform platform)
                {
                    var rit = new ApiCall()
                        .SelectApi<FeaturedGames>(ApiName.Spectator)
                        .For(ApiMiddleName.FeaturedGames)
                        .AddParameter().Build(platform)
                        .Get();
                    return rit;
                }
            }
        }

        //
    }

    //
}