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
        //Status API
        //"https://{platformId}.api.riotgames.com/lol
        public static class Status
        {
            //"Status/v3
            public static class Status_v3
            {
                public static IResult<ShardStatus> GetShardData(ServicePlatform platform)
                {
                    IResult<ShardStatus> rit = new ApiCall()
                        .SelectApi<ShardStatus>(LolApiName.Status)
                        .For(LolApiMethodName.ShardData)
                        .AddParameter()
                        .Build(platform)
                        .Get();
                    return rit;
                }
            }
        }

        //Static API
        //"https://{platformId}.api.riotgames.com/lol
        public static class Static
        {
            //"StaticData/v3
            public static class StaticData_v3
            {
                public static IResult<ChampionListDto> GetChampions(ServicePlatform platform, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.AspNetCore.RiotApi.Enums.ChampionTag> _tags = null, Boolean _dataById = false)
                {
                    IResult<ChampionListDto> rit = new ApiCall()
                        .SelectApi<ChampionListDto>(LolApiName.StaticData)
                        .For(LolApiMethodName.Champions)
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

                public static IResult<ChampionDto> GetChampionsOnlyId(ServicePlatform platform, Int64 _OnlyId, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.AspNetCore.RiotApi.Enums.ChampionTag> _tags = null, Boolean _dataById = false)
                {
                    IResult<ChampionDto> rit = new ApiCall()
                        .SelectApi<ChampionDto>(LolApiName.StaticData)
                        .For(LolApiMethodName.Champions)
                        .AddParameter(new ApiParameter(LolApiPath.OnlyId, _OnlyId))
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

                public static IResult<ItemListDto> GetItems(ServicePlatform platform, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.AspNetCore.RiotApi.Enums.ItemTag> _tags = null)
                {
                    IResult<ItemListDto> rit = new ApiCall()
                        .SelectApi<ItemListDto>(LolApiName.StaticData)
                        .For(LolApiMethodName.Items)
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

                public static IResult<ItemDto> GetItemsOnlyId(ServicePlatform platform, Int64 _OnlyId, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.AspNetCore.RiotApi.Enums.ItemTag> _tags = null)
                {
                    IResult<ItemDto> rit = new ApiCall()
                        .SelectApi<ItemDto>(LolApiName.StaticData)
                        .For(LolApiMethodName.Items)
                        .AddParameter(new ApiParameter(LolApiPath.OnlyId, _OnlyId))
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

                public static IResult<LanguageStringsDto> GetLanguageStrings(ServicePlatform platform, bool _useCache = false, String _locale = null, String _version = null)
                {
                    IResult<LanguageStringsDto> rit = new ApiCall()
                        .SelectApi<LanguageStringsDto>(LolApiName.StaticData)
                        .For(LolApiMethodName.LanguageStrings)
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

                public static IResult<List<System.String>> GetLanguages(ServicePlatform platform, bool _useCache = false)
                {
                    IResult<List<System.String>> rit = new ApiCall()
                        .SelectApi<List<System.String>>(LolApiName.StaticData)
                        .For(LolApiMethodName.Languages)
                        .AddParameter()
                        .Build(platform)
                        .UseCache(_useCache)
                        .Get();
                    return rit;
                }

                public static IResult<MapDataDto> GetMaps(ServicePlatform platform, bool _useCache = false, String _locale = null, String _version = null)
                {
                    IResult<MapDataDto> rit = new ApiCall()
                        .SelectApi<MapDataDto>(LolApiName.StaticData)
                        .For(LolApiMethodName.Maps)
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

                public static IResult<MasteryListDto> GetMasteries(ServicePlatform platform, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Masteries.MasteryTag> _tags = null)
                {
                    IResult<MasteryListDto> rit = new ApiCall()
                        .SelectApi<MasteryListDto>(LolApiName.StaticData)
                        .For(LolApiMethodName.Masteries)
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

                public static IResult<MasteryDto> GetMasteriesOnlyId(ServicePlatform platform, Int64 _OnlyId, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Masteries.MasteryTag> _tags = null)
                {
                    IResult<MasteryDto> rit = new ApiCall()
                        .SelectApi<MasteryDto>(LolApiName.StaticData)
                        .For(LolApiMethodName.Masteries)
                        .AddParameter(new ApiParameter(LolApiPath.OnlyId, _OnlyId))
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

                public static IResult<ProfileIconDataDto> GetProfileIcons(ServicePlatform platform, bool _useCache = false, String _locale = null, String _version = null)
                {
                    IResult<ProfileIconDataDto> rit = new ApiCall()
                        .SelectApi<ProfileIconDataDto>(LolApiName.StaticData)
                        .For(LolApiMethodName.ProfileIcons)
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

                public static IResult<RealmDto> GetRealms(ServicePlatform platform, bool _useCache = false)
                {
                    IResult<RealmDto> rit = new ApiCall()
                        .SelectApi<RealmDto>(LolApiName.StaticData)
                        .For(LolApiMethodName.Realms)
                        .AddParameter()
                        .Build(platform)
                        .UseCache(_useCache)
                        .Get();
                    return rit;
                }

                public static IResult<RuneListDto> GetRunes(ServicePlatform platform, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Runes.RuneTag> _tags = null)
                {
                    IResult<RuneListDto> rit = new ApiCall()
                        .SelectApi<RuneListDto>(LolApiName.StaticData)
                        .For(LolApiMethodName.Runes)
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

                public static IResult<RuneDto> GetRunesOnlyId(ServicePlatform platform, Int64 _OnlyId, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Runes.RuneTag> _tags = null)
                {
                    IResult<RuneDto> rit = new ApiCall()
                        .SelectApi<RuneDto>(LolApiName.StaticData)
                        .For(LolApiMethodName.Runes)
                        .AddParameter(new ApiParameter(LolApiPath.OnlyId, _OnlyId))
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

                public static IResult<SummonerSpellListDto> GetSummonerSpells(ServicePlatform platform, bool _useCache = false, String _locale = null, String _version = null, Boolean _dataById = false, List<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.SummonerSpell.SummonerSpellTag> _tags = null)
                {
                    IResult<SummonerSpellListDto> rit = new ApiCall()
                        .SelectApi<SummonerSpellListDto>(LolApiName.StaticData)
                        .For(LolApiMethodName.SummonerSpells)
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

                public static IResult<SummonerSpellDto> GetSummonerSpellsOnlyId(ServicePlatform platform, Int64 _OnlyId, bool _useCache = false, String _locale = null, String _version = null, Boolean _dataById = false, List<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.SummonerSpell.SummonerSpellTag> _tags = null)
                {
                    IResult<SummonerSpellDto> rit = new ApiCall()
                        .SelectApi<SummonerSpellDto>(LolApiName.StaticData)
                        .For(LolApiMethodName.SummonerSpells)
                        .AddParameter(new ApiParameter(LolApiPath.OnlyId, _OnlyId))
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

                public static IResult<List<System.String>> GetVersions(ServicePlatform platform, bool _useCache = false)
                {
                    IResult<List<System.String>> rit = new ApiCall()
                        .SelectApi<List<System.String>>(LolApiName.StaticData)
                        .For(LolApiMethodName.Versions)
                        .AddParameter()
                        .Build(platform)
                        .UseCache(_useCache)
                        .Get();
                    return rit;
                }
            }
        }

        //NonStatic API
        //"https://{platformId}.api.riotgames.com/lol
        public static class NonStatic
        {
            //"ChampionMastery/v3
            public static class ChampionMastery_v3
            {
                public static IResult<List<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.ChampionMastery.ChampionMasteryDto>> GetChampionMasteriesBySummoner(ServicePlatform platform, Int64 _BySummoner)
                {
                    IResult<List<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.ChampionMastery.ChampionMasteryDto>> rit = new ApiCall()
                        .SelectApi<List<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.ChampionMastery.ChampionMasteryDto>>(LolApiName.ChampionMastery)
                        .For(LolApiMethodName.ChampionMasteries)
                        .AddParameter(new ApiParameter(LolApiPath.BySummoner, _BySummoner))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<ChampionMasteryDto> GetChampionMasteriesBySummoner(ServicePlatform platform, Int64 _BySummoner, Int64 _ByChampion)
                {
                    IResult<ChampionMasteryDto> rit = new ApiCall()
                        .SelectApi<ChampionMasteryDto>(LolApiName.ChampionMastery)
                        .For(LolApiMethodName.ChampionMasteries)
                        .AddParameter(new ApiParameter(LolApiPath.BySummoner, _BySummoner),
                            new ApiParameter(LolApiPath.ByChampion, _ByChampion))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<Int32> GetScoresBySummoner(ServicePlatform platform, Int64 _BySummoner)
                {
                    IResult<Int32> rit = new ApiCall()
                        .SelectApi<Int32>(LolApiName.ChampionMastery)
                        .For(LolApiMethodName.Scores)
                        .AddParameter(new ApiParameter(LolApiPath.BySummoner, _BySummoner))
                        .Build(platform)
                        .Get();
                    return rit;
                }
            }

            //"Summoner/v3
            public static class Summoner_v3
            {
                public static IResult<SummonerDto> GetSummonersByAccount(ServicePlatform platform, Int64 _ByAccount)
                {
                    IResult<SummonerDto> rit = new ApiCall()
                        .SelectApi<SummonerDto>(LolApiName.Summoner)
                        .For(LolApiMethodName.Summoners)
                        .AddParameter(new ApiParameter(LolApiPath.ByAccount, _ByAccount))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<SummonerDto> GetSummonersByName(ServicePlatform platform, String _ByName)
                {
                    IResult<SummonerDto> rit = new ApiCall()
                        .SelectApi<SummonerDto>(LolApiName.Summoner)
                        .For(LolApiMethodName.Summoners)
                        .AddParameter(new ApiParameter(LolApiPath.ByName, _ByName))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<SummonerDto> GetSummonersOnlySummonerId(ServicePlatform platform, Int64 _OnlySummonerId)
                {
                    IResult<SummonerDto> rit = new ApiCall()
                        .SelectApi<SummonerDto>(LolApiName.Summoner)
                        .For(LolApiMethodName.Summoners)
                        .AddParameter(new ApiParameter(LolApiPath.OnlySummonerId, _OnlySummonerId))
                        .Build(platform)
                        .Get();
                    return rit;
                }
            }

            //"Platform/v3
            public static class Platform_v3
            {
                public static IResult<ChampionListDto> GetChampions(ServicePlatform platform)
                {
                    IResult<ChampionListDto> rit = new ApiCall()
                        .SelectApi<ChampionListDto>(LolApiName.Platform)
                        .For(LolApiMethodName.Champions)
                        .AddParameter()
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<ChampionDto> GetChampionsOnlyId(ServicePlatform platform, Int64 _OnlyId)
                {
                    IResult<ChampionDto> rit = new ApiCall()
                        .SelectApi<ChampionDto>(LolApiName.Platform)
                        .For(LolApiMethodName.Champions)
                        .AddParameter(new ApiParameter(LolApiPath.OnlyId, _OnlyId))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<MasteryPagesDto> GetMasteriesBySummoner(ServicePlatform platform, Int64 _BySummoner)
                {
                    IResult<MasteryPagesDto> rit = new ApiCall()
                        .SelectApi<MasteryPagesDto>(LolApiName.Platform)
                        .For(LolApiMethodName.Masteries)
                        .AddParameter(new ApiParameter(LolApiPath.BySummoner, _BySummoner))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<RunePagesDto> GetRunesBySummoner(ServicePlatform platform, Int64 _BySummoner)
                {
                    IResult<RunePagesDto> rit = new ApiCall()
                        .SelectApi<RunePagesDto>(LolApiName.Platform)
                        .For(LolApiMethodName.Runes)
                        .AddParameter(new ApiParameter(LolApiPath.BySummoner, _BySummoner))
                        .Build(platform)
                        .Get();
                    return rit;
                }
            }

            //"League/v3
            public static class League_v3
            {
                public static IResult<LeagueListDTO> GetChallengerLeaguesByQueue(ServicePlatform platform, Queue _ByQueue)
                {
                    IResult<LeagueListDTO> rit = new ApiCall()
                        .SelectApi<LeagueListDTO>(LolApiName.League)
                        .For(LolApiMethodName.ChallengerLeagues)
                        .AddParameter(new ApiParameter(LolApiPath.ByQueue, _ByQueue))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<List<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League.LeagueListDTO>> GetLeaguesBySummoner(ServicePlatform platform, Int64 _BySummoner)
                {
                    IResult<List<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League.LeagueListDTO>> rit = new ApiCall()
                        .SelectApi<List<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League.LeagueListDTO>>(LolApiName.League)
                        .For(LolApiMethodName.Leagues)
                        .AddParameter(new ApiParameter(LolApiPath.BySummoner, _BySummoner))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<LeagueListDTO> GetMasterLeaguesByQueue(ServicePlatform platform, Queue _ByQueue)
                {
                    IResult<LeagueListDTO> rit = new ApiCall()
                        .SelectApi<LeagueListDTO>(LolApiName.League)
                        .For(LolApiMethodName.MasterLeagues)
                        .AddParameter(new ApiParameter(LolApiPath.ByQueue, _ByQueue))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<List<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League.LeaguePositionDTO>> GetPositionsBySummoner(ServicePlatform platform, Int64 _BySummoner)
                {
                    IResult<List<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League.LeaguePositionDTO>> rit = new ApiCall()
                        .SelectApi<List<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League.LeaguePositionDTO>>(LolApiName.League)
                        .For(LolApiMethodName.Positions)
                        .AddParameter(new ApiParameter(LolApiPath.BySummoner, _BySummoner))
                        .Build(platform)
                        .Get();
                    return rit;
                }
            }

            //"Match/v3
            public static class Match_v3
            {
                public static IResult<MatchDto> GetMatchesOnlyMatchId(ServicePlatform platform, Int64 _OnlyMatchId)
                {
                    IResult<MatchDto> rit = new ApiCall()
                        .SelectApi<MatchDto>(LolApiName.Match)
                        .For(LolApiMethodName.Matches)
                        .AddParameter(new ApiParameter(LolApiPath.OnlyMatchId, _OnlyMatchId))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<MatchlistDto> GetMatchListsByAccount(ServicePlatform platform, Int64 _ByAccount)
                {
                    IResult<MatchlistDto> rit = new ApiCall()
                        .SelectApi<MatchlistDto>(LolApiName.Match)
                        .For(LolApiMethodName.MatchLists)
                        .AddParameter(new ApiParameter(LolApiPath.ByAccount, _ByAccount))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<MatchlistDto> GetMatchListsByAccountRecent(ServicePlatform platform, Int64 _ByAccountRecent)
                {
                    IResult<MatchlistDto> rit = new ApiCall()
                        .SelectApi<MatchlistDto>(LolApiName.Match)
                        .For(LolApiMethodName.MatchLists)
                        .AddParameter(new ApiParameter(LolApiPath.ByAccountRecent, _ByAccountRecent))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<MatchTimelineDto> GetTimelinesByMatch(ServicePlatform platform, Int64 _ByMatch)
                {
                    IResult<MatchTimelineDto> rit = new ApiCall()
                        .SelectApi<MatchTimelineDto>(LolApiName.Match)
                        .For(LolApiMethodName.Timelines)
                        .AddParameter(new ApiParameter(LolApiPath.ByMatch, _ByMatch))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<List<System.Int64>> GetMatchesByTournamentCodeIds(ServicePlatform platform, String _ByTournamentCodeIds)
                {
                    IResult<List<System.Int64>> rit = new ApiCall()
                        .SelectApi<List<System.Int64>>(LolApiName.Match)
                        .For(LolApiMethodName.Matches)
                        .AddParameter(new ApiParameter(LolApiPath.ByTournamentCodeIds, _ByTournamentCodeIds))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<MatchDto> GetMatchesOnlyMatchId(ServicePlatform platform, Int64 _OnlyMatchId, String _ByTournamentCode)
                {
                    IResult<MatchDto> rit = new ApiCall()
                        .SelectApi<MatchDto>(LolApiName.Match)
                        .For(LolApiMethodName.Matches)
                        .AddParameter(new ApiParameter(LolApiPath.OnlyMatchId, _OnlyMatchId),
                            new ApiParameter(LolApiPath.ByTournamentCode, _ByTournamentCode))
                        .Build(platform)
                        .Get();
                    return rit;
                }
            }

            //"Spectator/v3
            public static class Spectator_v3
            {
                public static IResult<CurrentGameInfo> GetActiveGamesBySummoner(ServicePlatform platform, Int64 _BySummoner)
                {
                    IResult<CurrentGameInfo> rit = new ApiCall()
                        .SelectApi<CurrentGameInfo>(LolApiName.Spectator)
                        .For(LolApiMethodName.ActiveGames)
                        .AddParameter(new ApiParameter(LolApiPath.BySummoner, _BySummoner))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static IResult<FeaturedGames> GetFeaturedGames(ServicePlatform platform)
                {
                    IResult<FeaturedGames> rit = new ApiCall()
                        .SelectApi<FeaturedGames>(LolApiName.Spectator)
                        .For(LolApiMethodName.FeaturedGames)
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