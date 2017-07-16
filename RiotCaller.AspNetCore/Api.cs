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
                    IResult<ShardStatus> rit = new ApiCall()
                        .SelectApi<ShardStatus>(ApiName.Status)
                        .For(ApiMiddleName.ShardData)
                        .AddParameter()
                        .Build(platform)
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
                public static IResult<ChampionListDto> GetChampions(Platform platform, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.AspNetCore.RiotApi.Enums.ChampionTag> _tags = null, Boolean _dataById = false)
                {
                    IResult<ChampionListDto> rit = new ApiCall()
                        .SelectApi<ChampionListDto>(ApiName.StaticData)
                        .For(ApiMiddleName.Champions)
                        .AddParameter()
                        .Build(platform)
                        .UseCache(_useCache)
                        .Get(new Dictionary<string, string>()
                            {
                                {"locale",_locale },
                                {"version",_version },
                                {"tags",string.Join("&tags=", _tags  ?? new List<RiotGamesApi.AspNetCore.RiotApi.Enums.ChampionTag>()) },
                                {"dataById",_dataById.ToString().ToLower() },
                            }
                        );
                    return rit;
                }

                public static IResult<ChampionDto> GetChampionsOnlyId(Platform platform, Int64 _OnlyId, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.AspNetCore.RiotApi.Enums.ChampionTag> _tags = null, Boolean _dataById = false)
                {
                    IResult<ChampionDto> rit = new ApiCall()
                        .SelectApi<ChampionDto>(ApiName.StaticData)
                        .For(ApiMiddleName.Champions)
                        .AddParameter(new ApiParameter(ApiParam.OnlyId, _OnlyId))
                        .Build(platform)
                        .UseCache(_useCache)
                        .Get(new Dictionary<string, string>()
                            {
                                {"locale",_locale },
                                {"version",_version },
                                {"tags",string.Join("&tags=", _tags  ?? new List<RiotGamesApi.AspNetCore.RiotApi.Enums.ChampionTag>()) },
                                {"dataById",_dataById.ToString().ToLower() },
                            }
                        );
                    return rit;
                }

                public static IResult<ItemListDto> GetItems(Platform platform, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.AspNetCore.RiotApi.Enums.ItemTag> _tags = null)
                {
                    IResult<ItemListDto> rit = new ApiCall()
                        .SelectApi<ItemListDto>(ApiName.StaticData)
                        .For(ApiMiddleName.Items)
                        .AddParameter()
                        .Build(platform)
                        .UseCache(_useCache)
                        .Get(new Dictionary<string, string>()
                            {
                                {"locale",_locale },
                                {"version",_version },
                                {"tags",string.Join("&tags=", _tags  ?? new List<RiotGamesApi.AspNetCore.RiotApi.Enums.ItemTag>()) },
                            }
                        );
                    return rit;
                }

                public static IResult<ItemDto> GetItemsOnlyId(Platform platform, Int64 _OnlyId, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.AspNetCore.RiotApi.Enums.ItemTag> _tags = null)
                {
                    IResult<ItemDto> rit = new ApiCall()
                        .SelectApi<ItemDto>(ApiName.StaticData)
                        .For(ApiMiddleName.Items)
                        .AddParameter(new ApiParameter(ApiParam.OnlyId, _OnlyId))
                        .Build(platform)
                        .UseCache(_useCache)
                        .Get(new Dictionary<string, string>()
                            {
                                {"locale",_locale },
                                {"version",_version },
                                {"tags",string.Join("&tags=", _tags  ?? new List<RiotGamesApi.AspNetCore.RiotApi.Enums.ItemTag>()) },
                            }
                        );
                    return rit;
                }

                public static IResult<LanguageStringsDto> GetLanguageStrings(Platform platform, bool _useCache = false, String _locale = null, String _version = null)
                {
                    IResult<LanguageStringsDto> rit = new ApiCall()
                        .SelectApi<LanguageStringsDto>(ApiName.StaticData)
                        .For(ApiMiddleName.LanguageStrings)
                        .AddParameter()
                        .Build(platform)
                        .UseCache(_useCache)
                        .Get(new Dictionary<string, string>()
                            {
                                {"locale",_locale },
                                {"version",_version },
                            }
                        );
                    return rit;
                }

                public static IResult<List<System.String>> GetLanguages(Platform platform, bool _useCache = false)
                {
                    IResult<List<System.String>> rit = new ApiCall()
                        .SelectApi<List<System.String>>(ApiName.StaticData)
                        .For(ApiMiddleName.Languages)
                        .AddParameter()
                        .Build(platform)
                        .UseCache(_useCache)
                        .Get();
                    return rit;
                }

                public static IResult<MapDataDto> GetMaps(Platform platform, bool _useCache = false, String _locale = null, String _version = null)
                {
                    IResult<MapDataDto> rit = new ApiCall()
                        .SelectApi<MapDataDto>(ApiName.StaticData)
                        .For(ApiMiddleName.Maps)
                        .AddParameter()
                        .Build(platform)
                        .UseCache(_useCache)
                        .Get(new Dictionary<string, string>()
                            {
                                {"locale",_locale },
                                {"version",_version },
                            }
                        );
                    return rit;
                }

                public static IResult<MasteryListDto> GetMasteries(Platform platform, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Masteries.MasteryTag> _tags = null)
                {
                    IResult<MasteryListDto> rit = new ApiCall()
                        .SelectApi<MasteryListDto>(ApiName.StaticData)
                        .For(ApiMiddleName.Masteries)
                        .AddParameter()
                        .Build(platform)
                        .UseCache(_useCache)
                        .Get(new Dictionary<string, string>()
                            {
                                {"locale",_locale },
                                {"version",_version },
                                {"tags",string.Join("&tags=", _tags  ?? new List<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Masteries.MasteryTag>()) },
                            }
                        );
                    return rit;
                }

                public static IResult<MasteryDto> GetMasteriesOnlyId(Platform platform, Int64 _OnlyId, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Masteries.MasteryTag> _tags = null)
                {
                    IResult<MasteryDto> rit = new ApiCall()
                        .SelectApi<MasteryDto>(ApiName.StaticData)
                        .For(ApiMiddleName.Masteries)
                        .AddParameter(new ApiParameter(ApiParam.OnlyId, _OnlyId))
                        .Build(platform)
                        .UseCache(_useCache)
                        .Get(new Dictionary<string, string>()
                            {
                                {"locale",_locale },
                                {"version",_version },
                                {"tags",string.Join("&tags=", _tags  ?? new List<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Masteries.MasteryTag>()) },
                            }
                        );
                    return rit;
                }

                public static IResult<ProfileIconDataDto> GetProfileIcons(Platform platform, bool _useCache = false, String _locale = null, String _version = null)
                {
                    IResult<ProfileIconDataDto> rit = new ApiCall()
                        .SelectApi<ProfileIconDataDto>(ApiName.StaticData)
                        .For(ApiMiddleName.ProfileIcons)
                        .AddParameter()
                        .Build(platform)
                        .UseCache(_useCache)
                        .Get(new Dictionary<string, string>()
                            {
                                {"locale",_locale },
                                {"version",_version },
                            }
                        );
                    return rit;
                }

                public static IResult<RealmDto> GetRealms(Platform platform, bool _useCache = false)
                {
                    IResult<RealmDto> rit = new ApiCall()
                        .SelectApi<RealmDto>(ApiName.StaticData)
                        .For(ApiMiddleName.Realms)
                        .AddParameter()
                        .Build(platform)
                        .UseCache(_useCache)
                        .Get();
                    return rit;
                }

                public static IResult<RuneListDto> GetRunes(Platform platform, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Runes.RuneTag> _tags = null)
                {
                    IResult<RuneListDto> rit = new ApiCall()
                        .SelectApi<RuneListDto>(ApiName.StaticData)
                        .For(ApiMiddleName.Runes)
                        .AddParameter()
                        .Build(platform)
                        .UseCache(_useCache)
                        .Get(new Dictionary<string, string>()
                            {
                                {"locale",_locale },
                                {"version",_version },
                                {"tags",string.Join("&tags=", _tags  ?? new List<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Runes.RuneTag>()) },
                            }
                        );
                    return rit;
                }

                public static IResult<RuneDto> GetRunesOnlyId(Platform platform, Int64 _OnlyId, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Runes.RuneTag> _tags = null)
                {
                    IResult<RuneDto> rit = new ApiCall()
                        .SelectApi<RuneDto>(ApiName.StaticData)
                        .For(ApiMiddleName.Runes)
                        .AddParameter(new ApiParameter(ApiParam.OnlyId, _OnlyId))
                        .Build(platform)
                        .UseCache(_useCache)
                        .Get(new Dictionary<string, string>()
                            {
                                {"locale",_locale },
                                {"version",_version },
                                {"tags",string.Join("&tags=", _tags  ?? new List<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Runes.RuneTag>()) },
                            }
                        );
                    return rit;
                }

                public static IResult<SummonerSpellListDto> GetSummonerSpells(Platform platform, bool _useCache = false, String _locale = null, String _version = null, Boolean _dataById = false, List<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.SummonerSpell.SummonerSpellTag> _tags = null)
                {
                    IResult<SummonerSpellListDto> rit = new ApiCall()
                        .SelectApi<SummonerSpellListDto>(ApiName.StaticData)
                        .For(ApiMiddleName.SummonerSpells)
                        .AddParameter()
                        .Build(platform)
                        .UseCache(_useCache)
                        .Get(new Dictionary<string, string>()
                            {
                                {"locale",_locale },
                                {"version",_version },
                                {"dataById",_dataById.ToString().ToLower() },
                                {"tags",string.Join("&tags=", _tags  ?? new List<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.SummonerSpell.SummonerSpellTag>()) },
                            }
                        );
                    return rit;
                }

                public static IResult<SummonerSpellDto> GetSummonerSpellsOnlyId(Platform platform, Int64 _OnlyId, bool _useCache = false, String _locale = null, String _version = null, Boolean _dataById = false, List<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.SummonerSpell.SummonerSpellTag> _tags = null)
                {
                    IResult<SummonerSpellDto> rit = new ApiCall()
                        .SelectApi<SummonerSpellDto>(ApiName.StaticData)
                        .For(ApiMiddleName.SummonerSpells)
                        .AddParameter(new ApiParameter(ApiParam.OnlyId, _OnlyId))
                        .Build(platform)
                        .UseCache(_useCache)
                        .Get(new Dictionary<string, string>()
                            {
                                {"locale",_locale },
                                {"version",_version },
                                {"dataById",_dataById.ToString().ToLower() },
                                {"tags",string.Join("&tags=", _tags  ?? new List<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.SummonerSpell.SummonerSpellTag>()) },
                            }
                        );
                    return rit;
                }

                public static IResult<List<System.String>> GetVersions(Platform platform, bool _useCache = false)
                {
                    IResult<List<System.String>> rit = new ApiCall()
                        .SelectApi<List<System.String>>(ApiName.StaticData)
                        .For(ApiMiddleName.Versions)
                        .AddParameter()
                        .Build(platform)
                        .UseCache(_useCache)
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
                public static IResult<List<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.ChampionMastery.ChampionMasteryDto>> GetChampionMasteriesBySummoner(Platform platform, Int64 _BySummoner)
                {
                    IResult<List<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.ChampionMastery.ChampionMasteryDto>> rit = new ApiCall()
                        .SelectApi<List<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.ChampionMastery.ChampionMasteryDto>>(ApiName.ChampionMastery)
                        .For(ApiMiddleName.ChampionMasteries)
                        .AddParameter(new ApiParameter(ApiParam.BySummoner, _BySummoner))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<ChampionMasteryDto> GetChampionMasteriesBySummoner(Platform platform, Int64 _BySummoner, Int64 _ByChampion)
                {
                    IResult<ChampionMasteryDto> rit = new ApiCall()
                        .SelectApi<ChampionMasteryDto>(ApiName.ChampionMastery)
                        .For(ApiMiddleName.ChampionMasteries)
                        .AddParameter(new ApiParameter(ApiParam.BySummoner, _BySummoner),
                            new ApiParameter(ApiParam.ByChampion, _ByChampion))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<Int32> GetScoresBySummoner(Platform platform, Int64 _BySummoner)
                {
                    IResult<Int32> rit = new ApiCall()
                        .SelectApi<Int32>(ApiName.ChampionMastery)
                        .For(ApiMiddleName.Scores)
                        .AddParameter(new ApiParameter(ApiParam.BySummoner, _BySummoner))
                        .Build(platform)
                        .Get();
                    return rit;
                }
            }

            //"Summoner/v3
            public static class Summoner_v3
            {
                public static IResult<SummonerDto> GetSummonersByAccount(Platform platform, Int64 _ByAccount)
                {
                    IResult<SummonerDto> rit = new ApiCall()
                        .SelectApi<SummonerDto>(ApiName.Summoner)
                        .For(ApiMiddleName.Summoners)
                        .AddParameter(new ApiParameter(ApiParam.ByAccount, _ByAccount))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<SummonerDto> GetSummonersByName(Platform platform, String _ByName)
                {
                    IResult<SummonerDto> rit = new ApiCall()
                        .SelectApi<SummonerDto>(ApiName.Summoner)
                        .For(ApiMiddleName.Summoners)
                        .AddParameter(new ApiParameter(ApiParam.ByName, _ByName))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<SummonerDto> GetSummonersOnlySummonerId(Platform platform, Int64 _OnlySummonerId)
                {
                    IResult<SummonerDto> rit = new ApiCall()
                        .SelectApi<SummonerDto>(ApiName.Summoner)
                        .For(ApiMiddleName.Summoners)
                        .AddParameter(new ApiParameter(ApiParam.OnlySummonerId, _OnlySummonerId))
                        .Build(platform)
                        .Get();
                    return rit;
                }
            }

            //"Platform/v3
            public static class Platform_v3
            {
                public static IResult<ChampionListDto> GetChampions(Platform platform)
                {
                    IResult<ChampionListDto> rit = new ApiCall()
                        .SelectApi<ChampionListDto>(ApiName.Platform)
                        .For(ApiMiddleName.Champions)
                        .AddParameter()
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<ChampionDto> GetChampionsOnlyId(Platform platform, Int64 _OnlyId)
                {
                    IResult<ChampionDto> rit = new ApiCall()
                        .SelectApi<ChampionDto>(ApiName.Platform)
                        .For(ApiMiddleName.Champions)
                        .AddParameter(new ApiParameter(ApiParam.OnlyId, _OnlyId))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<MasteryPagesDto> GetMasteriesBySummoner(Platform platform, Int64 _BySummoner)
                {
                    IResult<MasteryPagesDto> rit = new ApiCall()
                        .SelectApi<MasteryPagesDto>(ApiName.Platform)
                        .For(ApiMiddleName.Masteries)
                        .AddParameter(new ApiParameter(ApiParam.BySummoner, _BySummoner))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<RunePagesDto> GetRunesBySummoner(Platform platform, Int64 _BySummoner)
                {
                    IResult<RunePagesDto> rit = new ApiCall()
                        .SelectApi<RunePagesDto>(ApiName.Platform)
                        .For(ApiMiddleName.Runes)
                        .AddParameter(new ApiParameter(ApiParam.BySummoner, _BySummoner))
                        .Build(platform)
                        .Get();
                    return rit;
                }
            }

            //"League/v3
            public static class League_v3
            {
                public static IResult<LeagueListDTO> GetChallengerLeaguesByQueue(Platform platform, Queue _ByQueue)
                {
                    IResult<LeagueListDTO> rit = new ApiCall()
                        .SelectApi<LeagueListDTO>(ApiName.League)
                        .For(ApiMiddleName.ChallengerLeagues)
                        .AddParameter(new ApiParameter(ApiParam.ByQueue, _ByQueue))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<List<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League.LeagueListDTO>> GetLeaguesBySummoner(Platform platform, Int64 _BySummoner)
                {
                    IResult<List<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League.LeagueListDTO>> rit = new ApiCall()
                        .SelectApi<List<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League.LeagueListDTO>>(ApiName.League)
                        .For(ApiMiddleName.Leagues)
                        .AddParameter(new ApiParameter(ApiParam.BySummoner, _BySummoner))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<LeagueListDTO> GetMasterLeaguesByQueue(Platform platform, Queue _ByQueue)
                {
                    IResult<LeagueListDTO> rit = new ApiCall()
                        .SelectApi<LeagueListDTO>(ApiName.League)
                        .For(ApiMiddleName.MasterLeagues)
                        .AddParameter(new ApiParameter(ApiParam.ByQueue, _ByQueue))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<List<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League.LeaguePositionDTO>> GetPositionsBySummoner(Platform platform, Int64 _BySummoner)
                {
                    IResult<List<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League.LeaguePositionDTO>> rit = new ApiCall()
                        .SelectApi<List<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League.LeaguePositionDTO>>(ApiName.League)
                        .For(ApiMiddleName.Positions)
                        .AddParameter(new ApiParameter(ApiParam.BySummoner, _BySummoner))
                        .Build(platform)
                        .Get();
                    return rit;
                }
            }

            //"Match/v3
            public static class Match_v3
            {
                public static IResult<MatchDto> GetMatchesOnlyMatchId(Platform platform, Int64 _OnlyMatchId)
                {
                    IResult<MatchDto> rit = new ApiCall()
                        .SelectApi<MatchDto>(ApiName.Match)
                        .For(ApiMiddleName.Matches)
                        .AddParameter(new ApiParameter(ApiParam.OnlyMatchId, _OnlyMatchId))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<MatchlistDto> GetMatchListsByAccount(Platform platform, Int64 _ByAccount)
                {
                    IResult<MatchlistDto> rit = new ApiCall()
                        .SelectApi<MatchlistDto>(ApiName.Match)
                        .For(ApiMiddleName.MatchLists)
                        .AddParameter(new ApiParameter(ApiParam.ByAccount, _ByAccount))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<MatchlistDto> GetMatchListsByAccountRecent(Platform platform, Int64 _ByAccountRecent)
                {
                    IResult<MatchlistDto> rit = new ApiCall()
                        .SelectApi<MatchlistDto>(ApiName.Match)
                        .For(ApiMiddleName.MatchLists)
                        .AddParameter(new ApiParameter(ApiParam.ByAccountRecent, _ByAccountRecent))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<MatchTimelineDto> GetTimelinesByMatch(Platform platform, Int64 _ByMatch)
                {
                    IResult<MatchTimelineDto> rit = new ApiCall()
                        .SelectApi<MatchTimelineDto>(ApiName.Match)
                        .For(ApiMiddleName.Timelines)
                        .AddParameter(new ApiParameter(ApiParam.ByMatch, _ByMatch))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<List<System.Int64>> GetMatchesByTournamentCodeIds(Platform platform, String _ByTournamentCodeIds)
                {
                    IResult<List<System.Int64>> rit = new ApiCall()
                        .SelectApi<List<System.Int64>>(ApiName.Match)
                        .For(ApiMiddleName.Matches)
                        .AddParameter(new ApiParameter(ApiParam.ByTournamentCodeIds, _ByTournamentCodeIds))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<MatchDto> GetMatchesOnlyMatchId(Platform platform, Int64 _OnlyMatchId, String _ByTournamentCode)
                {
                    IResult<MatchDto> rit = new ApiCall()
                        .SelectApi<MatchDto>(ApiName.Match)
                        .For(ApiMiddleName.Matches)
                        .AddParameter(new ApiParameter(ApiParam.OnlyMatchId, _OnlyMatchId),
                            new ApiParameter(ApiParam.ByTournamentCode, _ByTournamentCode))
                        .Build(platform)
                        .Get();
                    return rit;
                }
            }

            //"Spectator/v3
            public static class Spectator_v3
            {
                public static IResult<CurrentGameInfo> GetActiveGamesBySummoner(Platform platform, Int64 _BySummoner)
                {
                    IResult<CurrentGameInfo> rit = new ApiCall()
                        .SelectApi<CurrentGameInfo>(ApiName.Spectator)
                        .For(ApiMiddleName.ActiveGames)
                        .AddParameter(new ApiParameter(ApiParam.BySummoner, _BySummoner))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<FeaturedGames> GetFeaturedGames(Platform platform)
                {
                    IResult<FeaturedGames> rit = new ApiCall()
                        .SelectApi<FeaturedGames>(ApiName.Spectator)
                        .For(ApiMiddleName.FeaturedGames)
                        .AddParameter()
                        .Build(platform)
                        .Get();
                    return rit;
                }
            }
        }

        //
    }

    //
}