using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.Models;
using RiotGamesApi.AspNetCore.RiotApi.Enums;
using System;
using System.Collections.Generic;

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
                public static RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StatusEndPoints.ShardStatus> GetShardData(ServicePlatform platform)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StatusEndPoints.ShardStatus> rit = new ApiCall()
                        .SelectApi<RiotGamesApi.AspNetCore.RiotApi.StatusEndPoints.ShardStatus>(LolApiName.Status)
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
                public static RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Champions.ChampionListDto> GetChampions(ServicePlatform platform, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.AspNetCore.RiotApi.Enums.ChampionTag> _tags = null, Boolean _dataById = false)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Champions.ChampionListDto> rit = new ApiCall()
                        .SelectApi<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Champions.ChampionListDto>(LolApiName.StaticData)
                        .For(LolApiMethodName.Champions)
                        .AddParameter()
                        .Build(platform)
                        .UseCache(_useCache)
                        .Get(new Dictionary<string, object>()
                            {
                                {"locale",_locale },
                                {"version",_version },
                                {"tags",string.Join("&tags=", _tags  ?? new List<RiotGamesApi.AspNetCore.RiotApi.Enums.ChampionTag>()) },
                                {"dataById",_dataById.ToString().ToLower() },
                            }
                        );
                    return rit;
                }

                public static RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Champions.ChampionDto> GetChampionsOnlyId(ServicePlatform platform, Int64 _OnlyId, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.AspNetCore.RiotApi.Enums.ChampionTag> _tags = null, Boolean _dataById = false)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Champions.ChampionDto> rit = new ApiCall()
                        .SelectApi<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Champions.ChampionDto>(LolApiName.StaticData)
                        .For(LolApiMethodName.Champions)
                        .AddParameter(new ApiParameter(LolApiPath.OnlyId, _OnlyId))
                        .Build(platform)
                        .UseCache(_useCache)
                        .Get(new Dictionary<string, object>()
                            {
                                {"locale",_locale },
                                {"version",_version },
                                {"tags",string.Join("&tags=", _tags  ?? new List<RiotGamesApi.AspNetCore.RiotApi.Enums.ChampionTag>()) },
                                {"dataById",_dataById.ToString().ToLower() },
                            }
                        );
                    return rit;
                }

                public static RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Items.ItemListDto> GetItems(ServicePlatform platform, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.AspNetCore.RiotApi.Enums.ItemTag> _tags = null)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Items.ItemListDto> rit = new ApiCall()
                        .SelectApi<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Items.ItemListDto>(LolApiName.StaticData)
                        .For(LolApiMethodName.Items)
                        .AddParameter()
                        .Build(platform)
                        .UseCache(_useCache)
                        .Get(new Dictionary<string, object>()
                            {
                                {"locale",_locale },
                                {"version",_version },
                                {"tags",string.Join("&tags=", _tags  ?? new List<RiotGamesApi.AspNetCore.RiotApi.Enums.ItemTag>()) },
                            }
                        );
                    return rit;
                }

                public static RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Items.ItemDto> GetItemsOnlyId(ServicePlatform platform, Int64 _OnlyId, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.AspNetCore.RiotApi.Enums.ItemTag> _tags = null)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Items.ItemDto> rit = new ApiCall()
                        .SelectApi<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Items.ItemDto>(LolApiName.StaticData)
                        .For(LolApiMethodName.Items)
                        .AddParameter(new ApiParameter(LolApiPath.OnlyId, _OnlyId))
                        .Build(platform)
                        .UseCache(_useCache)
                        .Get(new Dictionary<string, object>()
                            {
                                {"locale",_locale },
                                {"version",_version },
                                {"tags",string.Join("&tags=", _tags  ?? new List<RiotGamesApi.AspNetCore.RiotApi.Enums.ItemTag>()) },
                            }
                        );
                    return rit;
                }

                public static RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.LanguageStrings.LanguageStringsDto> GetLanguageStrings(ServicePlatform platform, bool _useCache = false, String _locale = null, String _version = null)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.LanguageStrings.LanguageStringsDto> rit = new ApiCall()
                        .SelectApi<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.LanguageStrings.LanguageStringsDto>(LolApiName.StaticData)
                        .For(LolApiMethodName.LanguageStrings)
                        .AddParameter()
                        .Build(platform)
                        .UseCache(_useCache)
                        .Get(new Dictionary<string, object>()
                            {
                                {"locale",_locale },
                                {"version",_version },
                            }
                        );
                    return rit;
                }

                public static RiotGamesApi.AspNetCore.Interfaces.IResult<List<System.String>> GetLanguages(ServicePlatform platform, bool _useCache = false)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<List<System.String>> rit = new ApiCall()
                        .SelectApi<List<System.String>>(LolApiName.StaticData)
                        .For(LolApiMethodName.Languages)
                        .AddParameter()
                        .Build(platform)
                        .UseCache(_useCache)
                        .Get();
                    return rit;
                }

                public static RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Maps.MapDataDto> GetMaps(ServicePlatform platform, bool _useCache = false, String _locale = null, String _version = null)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Maps.MapDataDto> rit = new ApiCall()
                        .SelectApi<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Maps.MapDataDto>(LolApiName.StaticData)
                        .For(LolApiMethodName.Maps)
                        .AddParameter()
                        .Build(platform)
                        .UseCache(_useCache)
                        .Get(new Dictionary<string, object>()
                            {
                                {"locale",_locale },
                                {"version",_version },
                            }
                        );
                    return rit;
                }

                public static RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Masteries.MasteryListDto> GetMasteries(ServicePlatform platform, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Masteries.MasteryTag> _tags = null)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Masteries.MasteryListDto> rit = new ApiCall()
                        .SelectApi<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Masteries.MasteryListDto>(LolApiName.StaticData)
                        .For(LolApiMethodName.Masteries)
                        .AddParameter()
                        .Build(platform)
                        .UseCache(_useCache)
                        .Get(new Dictionary<string, object>()
                            {
                                {"locale",_locale },
                                {"version",_version },
                                {"tags",string.Join("&tags=", _tags  ?? new List<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Masteries.MasteryTag>()) },
                            }
                        );
                    return rit;
                }

                public static RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Masteries.MasteryDto> GetMasteriesOnlyId(ServicePlatform platform, Int64 _OnlyId, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Masteries.MasteryTag> _tags = null)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Masteries.MasteryDto> rit = new ApiCall()
                        .SelectApi<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Masteries.MasteryDto>(LolApiName.StaticData)
                        .For(LolApiMethodName.Masteries)
                        .AddParameter(new ApiParameter(LolApiPath.OnlyId, _OnlyId))
                        .Build(platform)
                        .UseCache(_useCache)
                        .Get(new Dictionary<string, object>()
                            {
                                {"locale",_locale },
                                {"version",_version },
                                {"tags",string.Join("&tags=", _tags  ?? new List<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Masteries.MasteryTag>()) },
                            }
                        );
                    return rit;
                }

                public static RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Profile.ProfileIconDataDto> GetProfileIcons(ServicePlatform platform, bool _useCache = false, String _locale = null, String _version = null)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Profile.ProfileIconDataDto> rit = new ApiCall()
                        .SelectApi<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Profile.ProfileIconDataDto>(LolApiName.StaticData)
                        .For(LolApiMethodName.ProfileIcons)
                        .AddParameter()
                        .Build(platform)
                        .UseCache(_useCache)
                        .Get(new Dictionary<string, object>()
                            {
                                {"locale",_locale },
                                {"version",_version },
                            }
                        );
                    return rit;
                }

                public static RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Realms.RealmDto> GetRealms(ServicePlatform platform, bool _useCache = false)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Realms.RealmDto> rit = new ApiCall()
                        .SelectApi<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Realms.RealmDto>(LolApiName.StaticData)
                        .For(LolApiMethodName.Realms)
                        .AddParameter()
                        .Build(platform)
                        .UseCache(_useCache)
                        .Get();
                    return rit;
                }

                public static RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Runes.RuneListDto> GetRunes(ServicePlatform platform, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Runes.RuneTag> _tags = null)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Runes.RuneListDto> rit = new ApiCall()
                        .SelectApi<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Runes.RuneListDto>(LolApiName.StaticData)
                        .For(LolApiMethodName.Runes)
                        .AddParameter()
                        .Build(platform)
                        .UseCache(_useCache)
                        .Get(new Dictionary<string, object>()
                            {
                                {"locale",_locale },
                                {"version",_version },
                                {"tags",string.Join("&tags=", _tags  ?? new List<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Runes.RuneTag>()) },
                            }
                        );
                    return rit;
                }

                public static RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Runes.RuneDto> GetRunesOnlyId(ServicePlatform platform, Int64 _OnlyId, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Runes.RuneTag> _tags = null)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Runes.RuneDto> rit = new ApiCall()
                        .SelectApi<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Runes.RuneDto>(LolApiName.StaticData)
                        .For(LolApiMethodName.Runes)
                        .AddParameter(new ApiParameter(LolApiPath.OnlyId, _OnlyId))
                        .Build(platform)
                        .UseCache(_useCache)
                        .Get(new Dictionary<string, object>()
                            {
                                {"locale",_locale },
                                {"version",_version },
                                {"tags",string.Join("&tags=", _tags  ?? new List<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Runes.RuneTag>()) },
                            }
                        );
                    return rit;
                }

                public static RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.SummonerSpell.SummonerSpellListDto> GetSummonerSpells(ServicePlatform platform, bool _useCache = false, String _locale = null, String _version = null, Boolean _dataById = false, List<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.SummonerSpell.SummonerSpellTag> _tags = null)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.SummonerSpell.SummonerSpellListDto> rit = new ApiCall()
                        .SelectApi<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.SummonerSpell.SummonerSpellListDto>(LolApiName.StaticData)
                        .For(LolApiMethodName.SummonerSpells)
                        .AddParameter()
                        .Build(platform)
                        .UseCache(_useCache)
                        .Get(new Dictionary<string, object>()
                            {
                                {"locale",_locale },
                                {"version",_version },
                                {"dataById",_dataById.ToString().ToLower() },
                                {"tags",string.Join("&tags=", _tags  ?? new List<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.SummonerSpell.SummonerSpellTag>()) },
                            }
                        );
                    return rit;
                }

                public static RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.SummonerSpell.SummonerSpellDto> GetSummonerSpellsOnlyId(ServicePlatform platform, Int64 _OnlyId, bool _useCache = false, String _locale = null, String _version = null, Boolean _dataById = false, List<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.SummonerSpell.SummonerSpellTag> _tags = null)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.SummonerSpell.SummonerSpellDto> rit = new ApiCall()
                        .SelectApi<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.SummonerSpell.SummonerSpellDto>(LolApiName.StaticData)
                        .For(LolApiMethodName.SummonerSpells)
                        .AddParameter(new ApiParameter(LolApiPath.OnlyId, _OnlyId))
                        .Build(platform)
                        .UseCache(_useCache)
                        .Get(new Dictionary<string, object>()
                            {
                                {"locale",_locale },
                                {"version",_version },
                                {"dataById",_dataById.ToString().ToLower() },
                                {"tags",string.Join("&tags=", _tags  ?? new List<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.SummonerSpell.SummonerSpellTag>()) },
                            }
                        );
                    return rit;
                }

                public static RiotGamesApi.AspNetCore.Interfaces.IResult<List<System.String>> GetVersions(ServicePlatform platform, bool _useCache = false)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<List<System.String>> rit = new ApiCall()
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
                public static RiotGamesApi.AspNetCore.Interfaces.IResult<List<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.ChampionMastery.ChampionMasteryDto>> GetChampionMasteriesBySummoner(ServicePlatform platform, Int64 _BySummoner)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<List<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.ChampionMastery.ChampionMasteryDto>> rit = new ApiCall()
                        .SelectApi<List<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.ChampionMastery.ChampionMasteryDto>>(LolApiName.ChampionMastery)
                        .For(LolApiMethodName.ChampionMasteries)
                        .AddParameter(new ApiParameter(LolApiPath.BySummoner, _BySummoner))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.ChampionMastery.ChampionMasteryDto> GetChampionMasteriesBySummoner(ServicePlatform platform, Int64 _BySummoner, Int64 _ByChampion)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.ChampionMastery.ChampionMasteryDto> rit = new ApiCall()
                        .SelectApi<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.ChampionMastery.ChampionMasteryDto>(LolApiName.ChampionMastery)
                        .For(LolApiMethodName.ChampionMasteries)
                        .AddParameter(new ApiParameter(LolApiPath.BySummoner, _BySummoner),
                            new ApiParameter(LolApiPath.ByChampion, _ByChampion))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static RiotGamesApi.AspNetCore.Interfaces.IResult<Int32> GetScoresBySummoner(ServicePlatform platform, Int64 _BySummoner)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<Int32> rit = new ApiCall()
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
                public static RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Summoner.SummonerDto> GetSummonersByAccount(ServicePlatform platform, Int64 _ByAccount)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Summoner.SummonerDto> rit = new ApiCall()
                        .SelectApi<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Summoner.SummonerDto>(LolApiName.Summoner)
                        .For(LolApiMethodName.Summoners)
                        .AddParameter(new ApiParameter(LolApiPath.ByAccount, _ByAccount))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Summoner.SummonerDto> GetSummonersByName(ServicePlatform platform, String _ByName)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Summoner.SummonerDto> rit = new ApiCall()
                        .SelectApi<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Summoner.SummonerDto>(LolApiName.Summoner)
                        .For(LolApiMethodName.Summoners)
                        .AddParameter(new ApiParameter(LolApiPath.ByName, _ByName))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Summoner.SummonerDto> GetSummonersOnlySummonerId(ServicePlatform platform, Int64 _OnlySummonerId)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Summoner.SummonerDto> rit = new ApiCall()
                        .SelectApi<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Summoner.SummonerDto>(LolApiName.Summoner)
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
                public static RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Champion.ChampionListDto> GetChampions(ServicePlatform platform)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Champion.ChampionListDto> rit = new ApiCall()
                        .SelectApi<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Champion.ChampionListDto>(LolApiName.Platform)
                        .For(LolApiMethodName.Champions)
                        .AddParameter()
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Champion.ChampionDto> GetChampionsOnlyId(ServicePlatform platform, Int64 _OnlyId)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Champion.ChampionDto> rit = new ApiCall()
                        .SelectApi<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Champion.ChampionDto>(LolApiName.Platform)
                        .For(LolApiMethodName.Champions)
                        .AddParameter(new ApiParameter(LolApiPath.OnlyId, _OnlyId))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Mastery.MasteryPagesDto> GetMasteriesBySummoner(ServicePlatform platform, Int64 _BySummoner)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Mastery.MasteryPagesDto> rit = new ApiCall()
                        .SelectApi<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Mastery.MasteryPagesDto>(LolApiName.Platform)
                        .For(LolApiMethodName.Masteries)
                        .AddParameter(new ApiParameter(LolApiPath.BySummoner, _BySummoner))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Rune.RunePagesDto> GetRunesBySummoner(ServicePlatform platform, Int64 _BySummoner)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Rune.RunePagesDto> rit = new ApiCall()
                        .SelectApi<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Rune.RunePagesDto>(LolApiName.Platform)
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
                public static RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League.LeagueListDTO> GetChallengerLeaguesByQueue(ServicePlatform platform, Queue _ByQueue)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League.LeagueListDTO> rit = new ApiCall()
                        .SelectApi<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League.LeagueListDTO>(LolApiName.League)
                        .For(LolApiMethodName.ChallengerLeagues)
                        .AddParameter(new ApiParameter(LolApiPath.ByQueue, _ByQueue))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static RiotGamesApi.AspNetCore.Interfaces.IResult<List<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League.LeagueListDTO>> GetLeaguesBySummoner(ServicePlatform platform, Int64 _BySummoner)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<List<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League.LeagueListDTO>> rit = new ApiCall()
                        .SelectApi<List<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League.LeagueListDTO>>(LolApiName.League)
                        .For(LolApiMethodName.Leagues)
                        .AddParameter(new ApiParameter(LolApiPath.BySummoner, _BySummoner))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League.LeagueListDTO> GetMasterLeaguesByQueue(ServicePlatform platform, Queue _ByQueue)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League.LeagueListDTO> rit = new ApiCall()
                        .SelectApi<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League.LeagueListDTO>(LolApiName.League)
                        .For(LolApiMethodName.MasterLeagues)
                        .AddParameter(new ApiParameter(LolApiPath.ByQueue, _ByQueue))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static RiotGamesApi.AspNetCore.Interfaces.IResult<List<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League.LeaguePositionDTO>> GetPositionsBySummoner(ServicePlatform platform, Int64 _BySummoner)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<List<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League.LeaguePositionDTO>> rit = new ApiCall()
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
                public static RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Match.MatchDto> GetMatchesOnlyMatchId(ServicePlatform platform, Int64 _OnlyMatchId)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Match.MatchDto> rit = new ApiCall()
                        .SelectApi<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Match.MatchDto>(LolApiName.Match)
                        .For(LolApiMethodName.Matches)
                        .AddParameter(new ApiParameter(LolApiPath.OnlyMatchId, _OnlyMatchId))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Match.MatchlistDto> GetMatchListsByAccount(ServicePlatform platform, Int64 _ByAccount)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Match.MatchlistDto> rit = new ApiCall()
                        .SelectApi<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Match.MatchlistDto>(LolApiName.Match)
                        .For(LolApiMethodName.MatchLists)
                        .AddParameter(new ApiParameter(LolApiPath.ByAccount, _ByAccount))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Match.MatchlistDto> GetMatchListsByAccountRecent(ServicePlatform platform, Int64 _ByAccountRecent)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Match.MatchlistDto> rit = new ApiCall()
                        .SelectApi<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Match.MatchlistDto>(LolApiName.Match)
                        .For(LolApiMethodName.MatchLists)
                        .AddParameter(new ApiParameter(LolApiPath.ByAccountRecent, _ByAccountRecent))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Match.MatchTimelineDto> GetTimelinesByMatch(ServicePlatform platform, Int64 _ByMatch)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Match.MatchTimelineDto> rit = new ApiCall()
                        .SelectApi<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Match.MatchTimelineDto>(LolApiName.Match)
                        .For(LolApiMethodName.Timelines)
                        .AddParameter(new ApiParameter(LolApiPath.ByMatch, _ByMatch))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static RiotGamesApi.AspNetCore.Interfaces.IResult<List<System.Int64>> GetMatchesByTournamentCodeIds(ServicePlatform platform, String _ByTournamentCodeIds)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<List<System.Int64>> rit = new ApiCall()
                        .SelectApi<List<System.Int64>>(LolApiName.Match)
                        .For(LolApiMethodName.Matches)
                        .AddParameter(new ApiParameter(LolApiPath.ByTournamentCodeIds, _ByTournamentCodeIds))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Match.MatchDto> GetMatchesOnlyMatchId(ServicePlatform platform, Int64 _OnlyMatchId, String _ByTournamentCode)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Match.MatchDto> rit = new ApiCall()
                        .SelectApi<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Match.MatchDto>(LolApiName.Match)
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
                public static RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Spectator.CurrentGameInfo> GetActiveGamesBySummoner(ServicePlatform platform, Int64 _BySummoner)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Spectator.CurrentGameInfo> rit = new ApiCall()
                        .SelectApi<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Spectator.CurrentGameInfo>(LolApiName.Spectator)
                        .For(LolApiMethodName.ActiveGames)
                        .AddParameter(new ApiParameter(LolApiPath.BySummoner, _BySummoner))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Spectator.FeaturedGames> GetFeaturedGames(ServicePlatform platform)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Spectator.FeaturedGames> rit = new ApiCall()
                        .SelectApi<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Spectator.FeaturedGames>(LolApiName.Spectator)
                        .For(LolApiMethodName.FeaturedGames)
                        .AddParameter()
                        .Build(platform)
                        .Get();
                    return rit;
                }
            }
        }

        //Tournament API
        //"https://{platformId}.api.riotgames.com/lol
        public static class Tournament
        {
            //"TournamentStub/v3
            public static class TournamentStub_v3
            {
                public static RiotGamesApi.AspNetCore.Interfaces.IResult<List<System.String>> PostCodes(PhysicalRegion platform, Int32? _count = null, Int32? _tournamentId = null, RiotGamesApi.AspNetCore.RiotApi.TournamentStubEndPoints.TournamentCodeParameters _tournamentcodeparameters = null)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<List<System.String>> rit = new ApiCall()
                        .SelectApi<List<System.String>>(LolApiName.TournamentStub)
                        .For(LolApiMethodName.Codes)
                        .AddParameter()
                        .Build(platform)
                        .Post(new Dictionary<string, object>()
                            {
                                {"count",_count },
                                {"tournamentId",_tournamentId },
                            }
                            , _tournamentcodeparameters);
                    return rit;
                }

                public static RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.TournamentStubEndPoints.LobbyEventDTOWrapper> GetLobbyEventsByCode(PhysicalRegion platform, String _ByCode)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.TournamentStubEndPoints.LobbyEventDTOWrapper> rit = new ApiCall()
                        .SelectApi<RiotGamesApi.AspNetCore.RiotApi.TournamentStubEndPoints.LobbyEventDTOWrapper>(LolApiName.TournamentStub)
                        .For(LolApiMethodName.LobbyEvents)
                        .AddParameter(new ApiParameter(LolApiPath.ByCode, _ByCode))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static RiotGamesApi.AspNetCore.Interfaces.IResult<Int32> PostProviders(PhysicalRegion platform, RiotGamesApi.AspNetCore.RiotApi.TournamentEndPoints.ProviderRegistrationParameters _providerregistrationparameters)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<Int32> rit = new ApiCall()
                        .SelectApi<Int32>(LolApiName.TournamentStub)
                        .For(LolApiMethodName.Providers)
                        .AddParameter()
                        .Build(platform)
                        .Post(_providerregistrationparameters);
                    return rit;
                }

                public static RiotGamesApi.AspNetCore.Interfaces.IResult<Int32> PostTournaments(PhysicalRegion platform, RiotGamesApi.AspNetCore.RiotApi.TournamentEndPoints.TournamentRegistrationParameters _tournamentregistrationparameters)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<Int32> rit = new ApiCall()
                        .SelectApi<Int32>(LolApiName.TournamentStub)
                        .For(LolApiMethodName.Tournaments)
                        .AddParameter()
                        .Build(platform)
                        .Post(_tournamentregistrationparameters);
                    return rit;
                }
            }

            //"Tournament/v3
            public static class Tournament_v3
            {
                public static RiotGamesApi.AspNetCore.Interfaces.IResult<List<System.String>> PostCodes(PhysicalRegion platform, RiotGamesApi.AspNetCore.RiotApi.TournamentEndPoints.TournamentCodeParameters _tournamentcodeparameters, Int32? _count = null, Int32? _tournamentId = null)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<List<System.String>> rit = new ApiCall()
                        .SelectApi<List<System.String>>(LolApiName.Tournament)
                        .For(LolApiMethodName.Codes)
                        .AddParameter()
                        .Build(platform)
                        .Post(new Dictionary<string, object>()
                            {
                                {"count",_count },
                                {"tournamentId",_tournamentId },
                            }
                            , _tournamentcodeparameters);
                    return rit;
                }

                public static RiotGamesApi.AspNetCore.Interfaces.IResult<Int32> PutCodesOnlyTournamentCode(PhysicalRegion platform, String _OnlyTournamentCode, RiotGamesApi.AspNetCore.RiotApi.TournamentEndPoints.TournamentCodeUpdateParameters _tournamentcodeupdateparameters = null)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<Int32> rit = new ApiCall()
                        .SelectApi<Int32>(LolApiName.Tournament)
                        .For(LolApiMethodName.Codes)
                        .AddParameter(new ApiParameter(LolApiPath.OnlyTournamentCode, _OnlyTournamentCode))
                        .Build(platform)
                        .Put(_tournamentcodeupdateparameters);
                    return rit;
                }

                public static RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.TournamentEndPoints.TournamentCodeDTO> GetCodesOnlyTournamentCode(PhysicalRegion platform, String _OnlyTournamentCode)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.TournamentEndPoints.TournamentCodeDTO> rit = new ApiCall()
                        .SelectApi<RiotGamesApi.AspNetCore.RiotApi.TournamentEndPoints.TournamentCodeDTO>(LolApiName.Tournament)
                        .For(LolApiMethodName.Codes)
                        .AddParameter(new ApiParameter(LolApiPath.OnlyTournamentCode, _OnlyTournamentCode))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.TournamentEndPoints.LobbyEventDTOWrapper> GetLobbyEventsByCode(PhysicalRegion platform, String _ByCode)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.TournamentEndPoints.LobbyEventDTOWrapper> rit = new ApiCall()
                        .SelectApi<RiotGamesApi.AspNetCore.RiotApi.TournamentEndPoints.LobbyEventDTOWrapper>(LolApiName.Tournament)
                        .For(LolApiMethodName.LobbyEvents)
                        .AddParameter(new ApiParameter(LolApiPath.ByCode, _ByCode))
                        .Build(platform)
                        .Get();
                    return rit;
                }

                public static RiotGamesApi.AspNetCore.Interfaces.IResult<Int32> PostProviders(PhysicalRegion platform, RiotGamesApi.AspNetCore.RiotApi.TournamentEndPoints.ProviderRegistrationParameters _providerregistrationparameters)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<Int32> rit = new ApiCall()
                        .SelectApi<Int32>(LolApiName.Tournament)
                        .For(LolApiMethodName.Providers)
                        .AddParameter()
                        .Build(platform)
                        .Post(_providerregistrationparameters);
                    return rit;
                }

                public static RiotGamesApi.AspNetCore.Interfaces.IResult<Int32> PostTournaments(PhysicalRegion platform, RiotGamesApi.AspNetCore.RiotApi.TournamentEndPoints.TournamentRegistrationParameters _tournamentregistrationparameters)
                {
                    RiotGamesApi.AspNetCore.Interfaces.IResult<Int32> rit = new ApiCall()
                        .SelectApi<Int32>(LolApiName.Tournament)
                        .For(LolApiMethodName.Tournaments)
                        .AddParameter()
                        .Build(platform)
                        .Post(_tournamentregistrationparameters);
                    return rit;
                }
            }
        }

        //
    }

    //
}