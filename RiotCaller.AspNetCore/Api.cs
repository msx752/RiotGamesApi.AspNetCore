using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.Models;
using RiotGamesApi.AspNetCore.RiotApi.Enums;
using System;
using System.Collections.Generic;

namespace RiotGamesApi.AspNetCore
{
    // ReSharper disable InconsistentNaming
    //AUTO GENERATED CLASS DO NOT MODIFY
    public class Api
    {
        private Status _statusApi;
        public Status StatusApi { get { return _statusApi ?? (_statusApi = new Status()); } }
        private Static _staticApi;
        public Static StaticApi { get { return _staticApi ?? (_staticApi = new Static()); } }
        private NonStatic _nonstaticApi;
        public NonStatic NonStaticApi { get { return _nonstaticApi ?? (_nonstaticApi = new NonStatic()); } }
        private Tournament _tournamentApi;
        public Tournament TournamentApi { get { return _tournamentApi ?? (_tournamentApi = new Tournament()); } }
    }

    //Status API
    //"https://{platformId}.api.riotgames.com/lol
    public class Status
    {
        private Status_v3_1 _Statusv31;
        public Status_v3_1 Statusv31 { get { return _Statusv31 ?? (_Statusv31 = new Status_v3_1()); } }

        //"Status/v3.1
        public class Status_v3_1
        {
            public RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StatusEndPoints.ShardStatus> GetShardData(ServicePlatform platform)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StatusEndPoints.ShardStatus> rit = new ApiCall()
                    .SelectApi<RiotGamesApi.AspNetCore.RiotApi.StatusEndPoints.ShardStatus>(LolApiName.Status, 3.1)
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
    public class Static
    {
        private StaticData_v3 _StaticDatav3;
        public StaticData_v3 StaticDatav3 { get { return _StaticDatav3 ?? (_StaticDatav3 = new StaticData_v3()); } }

        //"StaticData/v3
        public class StaticData_v3
        {
            public RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Champions.ChampionListDto> GetChampions(ServicePlatform platform, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.AspNetCore.RiotApi.Enums.ChampionTag> _tags = null, Boolean _dataById = false)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Champions.ChampionListDto> rit = new ApiCall()
                    .SelectApi<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Champions.ChampionListDto>(LolApiName.StaticData, 3)
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

            public RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Champions.ChampionDto> GetChampionsOnlyId(ServicePlatform platform, Int64 _OnlyId, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.AspNetCore.RiotApi.Enums.ChampionTag> _tags = null, Boolean _dataById = false)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Champions.ChampionDto> rit = new ApiCall()
                    .SelectApi<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Champions.ChampionDto>(LolApiName.StaticData, 3)
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

            public RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Items.ItemListDto> GetItems(ServicePlatform platform, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.AspNetCore.RiotApi.Enums.ItemTag> _tags = null)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Items.ItemListDto> rit = new ApiCall()
                    .SelectApi<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Items.ItemListDto>(LolApiName.StaticData, 3)
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

            public RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Items.ItemDto> GetItemsOnlyId(ServicePlatform platform, Int64 _OnlyId, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.AspNetCore.RiotApi.Enums.ItemTag> _tags = null)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Items.ItemDto> rit = new ApiCall()
                    .SelectApi<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Items.ItemDto>(LolApiName.StaticData, 3)
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

            public RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.LanguageStrings.LanguageStringsDto> GetLanguageStrings(ServicePlatform platform, bool _useCache = false, String _locale = null, String _version = null)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.LanguageStrings.LanguageStringsDto> rit = new ApiCall()
                    .SelectApi<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.LanguageStrings.LanguageStringsDto>(LolApiName.StaticData, 3)
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

            public RiotGamesApi.AspNetCore.Interfaces.IResult<List<System.String>> GetLanguages(ServicePlatform platform, bool _useCache = false)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<List<System.String>> rit = new ApiCall()
                    .SelectApi<List<System.String>>(LolApiName.StaticData, 3)
                    .For(LolApiMethodName.Languages)
                    .AddParameter()
                    .Build(platform)
                    .UseCache(_useCache)
                    .Get();
                return rit;
            }

            public RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Maps.MapDataDto> GetMaps(ServicePlatform platform, bool _useCache = false, String _locale = null, String _version = null)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Maps.MapDataDto> rit = new ApiCall()
                    .SelectApi<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Maps.MapDataDto>(LolApiName.StaticData, 3)
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

            public RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Masteries.MasteryListDto> GetMasteries(ServicePlatform platform, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Masteries.MasteryTag> _tags = null)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Masteries.MasteryListDto> rit = new ApiCall()
                    .SelectApi<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Masteries.MasteryListDto>(LolApiName.StaticData, 3)
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

            public RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Masteries.MasteryDto> GetMasteriesOnlyId(ServicePlatform platform, Int64 _OnlyId, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Masteries.MasteryTag> _tags = null)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Masteries.MasteryDto> rit = new ApiCall()
                    .SelectApi<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Masteries.MasteryDto>(LolApiName.StaticData, 3)
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

            public RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Profile.ProfileIconDataDto> GetProfileIcons(ServicePlatform platform, bool _useCache = false, String _locale = null, String _version = null)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Profile.ProfileIconDataDto> rit = new ApiCall()
                    .SelectApi<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Profile.ProfileIconDataDto>(LolApiName.StaticData, 3)
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

            public RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Realms.RealmDto> GetRealms(ServicePlatform platform, bool _useCache = false)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Realms.RealmDto> rit = new ApiCall()
                    .SelectApi<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Realms.RealmDto>(LolApiName.StaticData, 3)
                    .For(LolApiMethodName.Realms)
                    .AddParameter()
                    .Build(platform)
                    .UseCache(_useCache)
                    .Get();
                return rit;
            }

            public RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Runes.RuneListDto> GetRunes(ServicePlatform platform, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Runes.RuneTag> _tags = null)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Runes.RuneListDto> rit = new ApiCall()
                    .SelectApi<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Runes.RuneListDto>(LolApiName.StaticData, 3)
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

            public RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Runes.RuneDto> GetRunesOnlyId(ServicePlatform platform, Int64 _OnlyId, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Runes.RuneTag> _tags = null)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Runes.RuneDto> rit = new ApiCall()
                    .SelectApi<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Runes.RuneDto>(LolApiName.StaticData, 3)
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

            public RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.SummonerSpell.SummonerSpellListDto> GetSummonerSpells(ServicePlatform platform, bool _useCache = false, String _locale = null, String _version = null, Boolean _dataById = false, List<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.SummonerSpell.SummonerSpellTag> _tags = null)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.SummonerSpell.SummonerSpellListDto> rit = new ApiCall()
                    .SelectApi<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.SummonerSpell.SummonerSpellListDto>(LolApiName.StaticData, 3)
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

            public RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.SummonerSpell.SummonerSpellDto> GetSummonerSpellsOnlyId(ServicePlatform platform, Int64 _OnlyId, bool _useCache = false, String _locale = null, String _version = null, Boolean _dataById = false, List<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.SummonerSpell.SummonerSpellTag> _tags = null)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.SummonerSpell.SummonerSpellDto> rit = new ApiCall()
                    .SelectApi<RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.SummonerSpell.SummonerSpellDto>(LolApiName.StaticData, 3)
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

            public RiotGamesApi.AspNetCore.Interfaces.IResult<List<System.String>> GetVersions(ServicePlatform platform, bool _useCache = false)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<List<System.String>> rit = new ApiCall()
                    .SelectApi<List<System.String>>(LolApiName.StaticData, 3)
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
    public class NonStatic
    {
        private ChampionMastery_v3 _ChampionMasteryv3;
        public ChampionMastery_v3 ChampionMasteryv3 { get { return _ChampionMasteryv3 ?? (_ChampionMasteryv3 = new ChampionMastery_v3()); } }

        //"ChampionMastery/v3
        public class ChampionMastery_v3
        {
            public RiotGamesApi.AspNetCore.Interfaces.IResult<List<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.ChampionMastery.ChampionMasteryDto>> GetChampionMasteriesBySummoner(ServicePlatform platform, Int64 _BySummoner)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<List<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.ChampionMastery.ChampionMasteryDto>> rit = new ApiCall()
                    .SelectApi<List<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.ChampionMastery.ChampionMasteryDto>>(LolApiName.ChampionMastery, 3)
                    .For(LolApiMethodName.ChampionMasteries)
                    .AddParameter(new ApiParameter(LolApiPath.BySummoner, _BySummoner))
                    .Build(platform)
                    .Get();
                return rit;
            }

            public RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.ChampionMastery.ChampionMasteryDto> GetChampionMasteriesBySummoner(ServicePlatform platform, Int64 _BySummoner, Int64 _ByChampion)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.ChampionMastery.ChampionMasteryDto> rit = new ApiCall()
                    .SelectApi<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.ChampionMastery.ChampionMasteryDto>(LolApiName.ChampionMastery, 3)
                    .For(LolApiMethodName.ChampionMasteries)
                    .AddParameter(new ApiParameter(LolApiPath.BySummoner, _BySummoner),
                        new ApiParameter(LolApiPath.ByChampion, _ByChampion))
                    .Build(platform)
                    .Get();
                return rit;
            }

            public RiotGamesApi.AspNetCore.Interfaces.IResult<Int32> GetScoresBySummoner(ServicePlatform platform, Int64 _BySummoner)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<Int32> rit = new ApiCall()
                    .SelectApi<Int32>(LolApiName.ChampionMastery, 3)
                    .For(LolApiMethodName.Scores)
                    .AddParameter(new ApiParameter(LolApiPath.BySummoner, _BySummoner))
                    .Build(platform)
                    .Get();
                return rit;
            }
        }

        private Summoner_v3 _Summonerv3;
        public Summoner_v3 Summonerv3 { get { return _Summonerv3 ?? (_Summonerv3 = new Summoner_v3()); } }

        //"Summoner/v3
        public class Summoner_v3
        {
            public RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Summoner.SummonerDto> GetSummonersByAccount(ServicePlatform platform, Int64 _ByAccount)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Summoner.SummonerDto> rit = new ApiCall()
                    .SelectApi<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Summoner.SummonerDto>(LolApiName.Summoner, 3)
                    .For(LolApiMethodName.Summoners)
                    .AddParameter(new ApiParameter(LolApiPath.ByAccount, _ByAccount))
                    .Build(platform)
                    .Get();
                return rit;
            }

            public RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Summoner.SummonerDto> GetSummonersByName(ServicePlatform platform, String _ByName)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Summoner.SummonerDto> rit = new ApiCall()
                    .SelectApi<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Summoner.SummonerDto>(LolApiName.Summoner, 3)
                    .For(LolApiMethodName.Summoners)
                    .AddParameter(new ApiParameter(LolApiPath.ByName, _ByName))
                    .Build(platform)
                    .Get();
                return rit;
            }

            public RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Summoner.SummonerDto> GetSummonersOnlySummonerId(ServicePlatform platform, Int64 _OnlySummonerId)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Summoner.SummonerDto> rit = new ApiCall()
                    .SelectApi<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Summoner.SummonerDto>(LolApiName.Summoner, 3)
                    .For(LolApiMethodName.Summoners)
                    .AddParameter(new ApiParameter(LolApiPath.OnlySummonerId, _OnlySummonerId))
                    .Build(platform)
                    .Get();
                return rit;
            }
        }

        private Platform_v3 _Platformv3;
        public Platform_v3 Platformv3 { get { return _Platformv3 ?? (_Platformv3 = new Platform_v3()); } }

        //"Platform/v3
        public class Platform_v3
        {
            public RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Champion.ChampionListDto> GetChampions(ServicePlatform platform)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Champion.ChampionListDto> rit = new ApiCall()
                    .SelectApi<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Champion.ChampionListDto>(LolApiName.Platform, 3)
                    .For(LolApiMethodName.Champions)
                    .AddParameter()
                    .Build(platform)
                    .Get();
                return rit;
            }

            public RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Champion.ChampionDto> GetChampionsOnlyId(ServicePlatform platform, Int64 _OnlyId)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Champion.ChampionDto> rit = new ApiCall()
                    .SelectApi<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Champion.ChampionDto>(LolApiName.Platform, 3)
                    .For(LolApiMethodName.Champions)
                    .AddParameter(new ApiParameter(LolApiPath.OnlyId, _OnlyId))
                    .Build(platform)
                    .Get();
                return rit;
            }

            public RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Mastery.MasteryPagesDto> GetMasteriesBySummoner(ServicePlatform platform, Int64 _BySummoner)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Mastery.MasteryPagesDto> rit = new ApiCall()
                    .SelectApi<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Mastery.MasteryPagesDto>(LolApiName.Platform, 3)
                    .For(LolApiMethodName.Masteries)
                    .AddParameter(new ApiParameter(LolApiPath.BySummoner, _BySummoner))
                    .Build(platform)
                    .Get();
                return rit;
            }

            public RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Rune.RunePagesDto> GetRunesBySummoner(ServicePlatform platform, Int64 _BySummoner)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Rune.RunePagesDto> rit = new ApiCall()
                    .SelectApi<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Rune.RunePagesDto>(LolApiName.Platform, 3)
                    .For(LolApiMethodName.Runes)
                    .AddParameter(new ApiParameter(LolApiPath.BySummoner, _BySummoner))
                    .Build(platform)
                    .Get();
                return rit;
            }
        }

        private League_v3 _Leaguev3;
        public League_v3 Leaguev3 { get { return _Leaguev3 ?? (_Leaguev3 = new League_v3()); } }

        //"League/v3
        public class League_v3
        {
            public RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League.LeagueListDTO> GetChallengerLeaguesByQueue(ServicePlatform platform, Queue _ByQueue)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League.LeagueListDTO> rit = new ApiCall()
                    .SelectApi<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League.LeagueListDTO>(LolApiName.League, 3)
                    .For(LolApiMethodName.ChallengerLeagues)
                    .AddParameter(new ApiParameter(LolApiPath.ByQueue, _ByQueue))
                    .Build(platform)
                    .Get();
                return rit;
            }

            public RiotGamesApi.AspNetCore.Interfaces.IResult<List<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League.LeagueListDTO>> GetLeaguesBySummoner(ServicePlatform platform, Int64 _BySummoner)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<List<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League.LeagueListDTO>> rit = new ApiCall()
                    .SelectApi<List<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League.LeagueListDTO>>(LolApiName.League, 3)
                    .For(LolApiMethodName.Leagues)
                    .AddParameter(new ApiParameter(LolApiPath.BySummoner, _BySummoner))
                    .Build(platform)
                    .Get();
                return rit;
            }

            public RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League.LeagueListDTO> GetMasterLeaguesByQueue(ServicePlatform platform, Queue _ByQueue)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League.LeagueListDTO> rit = new ApiCall()
                    .SelectApi<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League.LeagueListDTO>(LolApiName.League, 3)
                    .For(LolApiMethodName.MasterLeagues)
                    .AddParameter(new ApiParameter(LolApiPath.ByQueue, _ByQueue))
                    .Build(platform)
                    .Get();
                return rit;
            }

            public RiotGamesApi.AspNetCore.Interfaces.IResult<List<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League.LeaguePositionDTO>> GetPositionsBySummoner(ServicePlatform platform, Int64 _BySummoner)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<List<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League.LeaguePositionDTO>> rit = new ApiCall()
                    .SelectApi<List<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League.LeaguePositionDTO>>(LolApiName.League, 3)
                    .For(LolApiMethodName.Positions)
                    .AddParameter(new ApiParameter(LolApiPath.BySummoner, _BySummoner))
                    .Build(platform)
                    .Get();
                return rit;
            }
        }

        private Match_v3 _Matchv3;
        public Match_v3 Matchv3 { get { return _Matchv3 ?? (_Matchv3 = new Match_v3()); } }

        //"Match/v3
        public class Match_v3
        {
            public RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Match.MatchDto> GetMatchesOnlyMatchId(ServicePlatform platform, Int64 _OnlyMatchId)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Match.MatchDto> rit = new ApiCall()
                    .SelectApi<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Match.MatchDto>(LolApiName.Match, 3)
                    .For(LolApiMethodName.Matches)
                    .AddParameter(new ApiParameter(LolApiPath.OnlyMatchId, _OnlyMatchId))
                    .Build(platform)
                    .Get();
                return rit;
            }

            public RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Match.MatchlistDto> GetMatchListsByAccount(ServicePlatform platform, Int64 _ByAccount)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Match.MatchlistDto> rit = new ApiCall()
                    .SelectApi<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Match.MatchlistDto>(LolApiName.Match, 3)
                    .For(LolApiMethodName.MatchLists)
                    .AddParameter(new ApiParameter(LolApiPath.ByAccount, _ByAccount))
                    .Build(platform)
                    .Get();
                return rit;
            }

            public RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Match.MatchlistDto> GetMatchListsByAccountRecent(ServicePlatform platform, Int64 _ByAccountRecent)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Match.MatchlistDto> rit = new ApiCall()
                    .SelectApi<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Match.MatchlistDto>(LolApiName.Match, 3)
                    .For(LolApiMethodName.MatchLists)
                    .AddParameter(new ApiParameter(LolApiPath.ByAccountRecent, _ByAccountRecent))
                    .Build(platform)
                    .Get();
                return rit;
            }

            public RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Match.MatchTimelineDto> GetTimelinesByMatch(ServicePlatform platform, Int64 _ByMatch)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Match.MatchTimelineDto> rit = new ApiCall()
                    .SelectApi<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Match.MatchTimelineDto>(LolApiName.Match, 3)
                    .For(LolApiMethodName.Timelines)
                    .AddParameter(new ApiParameter(LolApiPath.ByMatch, _ByMatch))
                    .Build(platform)
                    .Get();
                return rit;
            }

            public RiotGamesApi.AspNetCore.Interfaces.IResult<List<System.Int64>> GetMatchesByTournamentCodeIds(ServicePlatform platform, String _ByTournamentCodeIds)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<List<System.Int64>> rit = new ApiCall()
                    .SelectApi<List<System.Int64>>(LolApiName.Match, 3)
                    .For(LolApiMethodName.Matches)
                    .AddParameter(new ApiParameter(LolApiPath.ByTournamentCodeIds, _ByTournamentCodeIds))
                    .Build(platform)
                    .Get();
                return rit;
            }

            public RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Match.MatchDto> GetMatchesOnlyMatchId(ServicePlatform platform, Int64 _OnlyMatchId, String _ByTournamentCode)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Match.MatchDto> rit = new ApiCall()
                    .SelectApi<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Match.MatchDto>(LolApiName.Match, 3)
                    .For(LolApiMethodName.Matches)
                    .AddParameter(new ApiParameter(LolApiPath.OnlyMatchId, _OnlyMatchId),
                        new ApiParameter(LolApiPath.ByTournamentCode, _ByTournamentCode))
                    .Build(platform)
                    .Get();
                return rit;
            }
        }

        private Spectator_v3 _Spectatorv3;
        public Spectator_v3 Spectatorv3 { get { return _Spectatorv3 ?? (_Spectatorv3 = new Spectator_v3()); } }

        //"Spectator/v3
        public class Spectator_v3
        {
            public RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Spectator.CurrentGameInfo> GetActiveGamesBySummoner(ServicePlatform platform, Int64 _BySummoner)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Spectator.CurrentGameInfo> rit = new ApiCall()
                    .SelectApi<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Spectator.CurrentGameInfo>(LolApiName.Spectator, 3)
                    .For(LolApiMethodName.ActiveGames)
                    .AddParameter(new ApiParameter(LolApiPath.BySummoner, _BySummoner))
                    .Build(platform)
                    .Get();
                return rit;
            }

            public RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Spectator.FeaturedGames> GetFeaturedGames(ServicePlatform platform)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Spectator.FeaturedGames> rit = new ApiCall()
                    .SelectApi<RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Spectator.FeaturedGames>(LolApiName.Spectator, 3)
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
    public class Tournament
    {
        private TournamentStub_v3 _TournamentStubv3;
        public TournamentStub_v3 TournamentStubv3 { get { return _TournamentStubv3 ?? (_TournamentStubv3 = new TournamentStub_v3()); } }

        //"TournamentStub/v3
        public class TournamentStub_v3
        {
            public RiotGamesApi.AspNetCore.Interfaces.IResult<List<System.String>> PostCodes(PhysicalRegion platform, Int32? _count = null, Int32? _tournamentId = null, RiotGamesApi.AspNetCore.RiotApi.TournamentStubEndPoints.TournamentCodeParameters _tournamentcodeparameters = null)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<List<System.String>> rit = new ApiCall()
                    .SelectApi<List<System.String>>(LolApiName.TournamentStub, 3)
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

            public RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.TournamentStubEndPoints.LobbyEventDTOWrapper> GetLobbyEventsByCode(PhysicalRegion platform, String _ByCode)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.TournamentStubEndPoints.LobbyEventDTOWrapper> rit = new ApiCall()
                    .SelectApi<RiotGamesApi.AspNetCore.RiotApi.TournamentStubEndPoints.LobbyEventDTOWrapper>(LolApiName.TournamentStub, 3)
                    .For(LolApiMethodName.LobbyEvents)
                    .AddParameter(new ApiParameter(LolApiPath.ByCode, _ByCode))
                    .Build(platform)
                    .Get();
                return rit;
            }

            public RiotGamesApi.AspNetCore.Interfaces.IResult<Int32> PostProviders(PhysicalRegion platform, RiotGamesApi.AspNetCore.RiotApi.TournamentEndPoints.ProviderRegistrationParameters _providerregistrationparameters)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<Int32> rit = new ApiCall()
                    .SelectApi<Int32>(LolApiName.TournamentStub, 3)
                    .For(LolApiMethodName.Providers)
                    .AddParameter()
                    .Build(platform)
                    .Post(_providerregistrationparameters);
                return rit;
            }

            public RiotGamesApi.AspNetCore.Interfaces.IResult<Int32> PostTournaments(PhysicalRegion platform, RiotGamesApi.AspNetCore.RiotApi.TournamentEndPoints.TournamentRegistrationParameters _tournamentregistrationparameters)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<Int32> rit = new ApiCall()
                    .SelectApi<Int32>(LolApiName.TournamentStub, 3)
                    .For(LolApiMethodName.Tournaments)
                    .AddParameter()
                    .Build(platform)
                    .Post(_tournamentregistrationparameters);
                return rit;
            }
        }

        private Tournament_v3 _Tournamentv3;
        public Tournament_v3 Tournamentv3 { get { return _Tournamentv3 ?? (_Tournamentv3 = new Tournament_v3()); } }

        //"Tournament/v3
        public class Tournament_v3
        {
            public RiotGamesApi.AspNetCore.Interfaces.IResult<List<System.String>> PostCodes(PhysicalRegion platform, RiotGamesApi.AspNetCore.RiotApi.TournamentEndPoints.TournamentCodeParameters _tournamentcodeparameters, Int32? _count = null, Int32? _tournamentId = null)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<List<System.String>> rit = new ApiCall()
                    .SelectApi<List<System.String>>(LolApiName.Tournament, 3)
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

            public RiotGamesApi.AspNetCore.Interfaces.IResult<Int32> PutCodesOnlyTournamentCode(PhysicalRegion platform, String _OnlyTournamentCode, RiotGamesApi.AspNetCore.RiotApi.TournamentEndPoints.TournamentCodeUpdateParameters _tournamentcodeupdateparameters = null)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<Int32> rit = new ApiCall()
                    .SelectApi<Int32>(LolApiName.Tournament, 3)
                    .For(LolApiMethodName.Codes)
                    .AddParameter(new ApiParameter(LolApiPath.OnlyTournamentCode, _OnlyTournamentCode))
                    .Build(platform)
                    .Put(_tournamentcodeupdateparameters);
                return rit;
            }

            public RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.TournamentEndPoints.TournamentCodeDTO> GetCodesOnlyTournamentCode(PhysicalRegion platform, String _OnlyTournamentCode)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.TournamentEndPoints.TournamentCodeDTO> rit = new ApiCall()
                    .SelectApi<RiotGamesApi.AspNetCore.RiotApi.TournamentEndPoints.TournamentCodeDTO>(LolApiName.Tournament, 3)
                    .For(LolApiMethodName.Codes)
                    .AddParameter(new ApiParameter(LolApiPath.OnlyTournamentCode, _OnlyTournamentCode))
                    .Build(platform)
                    .Get();
                return rit;
            }

            public RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.TournamentEndPoints.LobbyEventDTOWrapper> GetLobbyEventsByCode(PhysicalRegion platform, String _ByCode)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<RiotGamesApi.AspNetCore.RiotApi.TournamentEndPoints.LobbyEventDTOWrapper> rit = new ApiCall()
                    .SelectApi<RiotGamesApi.AspNetCore.RiotApi.TournamentEndPoints.LobbyEventDTOWrapper>(LolApiName.Tournament, 3)
                    .For(LolApiMethodName.LobbyEvents)
                    .AddParameter(new ApiParameter(LolApiPath.ByCode, _ByCode))
                    .Build(platform)
                    .Get();
                return rit;
            }

            public RiotGamesApi.AspNetCore.Interfaces.IResult<Int32> PostProviders(PhysicalRegion platform, RiotGamesApi.AspNetCore.RiotApi.TournamentEndPoints.ProviderRegistrationParameters _providerregistrationparameters)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<Int32> rit = new ApiCall()
                    .SelectApi<Int32>(LolApiName.Tournament, 3)
                    .For(LolApiMethodName.Providers)
                    .AddParameter()
                    .Build(platform)
                    .Post(_providerregistrationparameters);
                return rit;
            }

            public RiotGamesApi.AspNetCore.Interfaces.IResult<Int32> PostTournaments(PhysicalRegion platform, RiotGamesApi.AspNetCore.RiotApi.TournamentEndPoints.TournamentRegistrationParameters _tournamentregistrationparameters)
            {
                RiotGamesApi.AspNetCore.Interfaces.IResult<Int32> rit = new ApiCall()
                    .SelectApi<Int32>(LolApiName.Tournament, 3)
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