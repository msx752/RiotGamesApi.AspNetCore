using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using RiotGamesApi.AspNetCore.Builder;
using RiotGamesApi.AspNetCore.Cache;
using RiotGamesApi.AspNetCore.Enums;
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
using MasteryDto = RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Masteries.MasteryDto;
using RuneDto = RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Runes.RuneDto;

namespace RiotGamesApi.AspNetCore.Extensions
{
    public static class Extension2
    {
        public static void AddRiotGamesApi(this IServiceCollection services, string riotApiKey, Func<CacheOption, CacheOption> cacheOption = null)
        {
            //can convertable to json
            var RiotGamesApiBuilder = new RiotGamesApiBuilder()
                .UseRiotApiKey(riotApiKey)
                .UseApiUrl("api.riotgames.com")
                .UseStatusApi((api) =>
                {
                    api.AddApi(ApiName.Status, 3.0)
                        .SubApi(ApiMiddleName.ShardData, typeof(ShardStatus));
                    return api;
                })
                .UseStaticApi((api) =>
                {
                    api.AddApi(ApiName.StaticData, 3.0)
                        .SubApi(ApiMiddleName.Champions, typeof(ChampionListDto))
                        .HasQueryParameters(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"tags",typeof(List<ChampionTag>)},
                            {"dataById",typeof(bool)},
                        })
                        .SubApi(ApiMiddleName.Champions, typeof(ChampionDto), ApiParam.OnlyId)
                        .HasQueryParameters(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"tags",typeof(List<ChampionTag>)},
                            {"dataById",typeof(bool)},
                        })
                        .SubApi(ApiMiddleName.Items, typeof(ItemListDto))
                        .HasQueryParameters(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"tags",typeof(List<ItemTag>)},
                        })
                        .SubApi(ApiMiddleName.Items, typeof(ItemDto), ApiParam.OnlyId)
                        .HasQueryParameters(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"tags",typeof(List<ItemTag>)},
                        })
                        .SubApi(ApiMiddleName.LanguageStrings, typeof(LanguageStringsDto))
                        .HasQueryParameters(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                        })
                        .SubApi(ApiMiddleName.Languages, typeof(List<string>))
                        .SubApi(ApiMiddleName.Maps, typeof(MapDataDto))
                        .HasQueryParameters(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                        })
                        .SubApi(ApiMiddleName.Masteries, typeof(MasteryListDto)).HasQueryParameters(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"tags",typeof(List<MasteryTag>)},
                        })
                        .SubApi(ApiMiddleName.Masteries, typeof(MasteryDto), ApiParam.OnlyId).HasQueryParameters(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"tags",typeof(List<MasteryTag>)},
                        })
                        .SubApi(ApiMiddleName.ProfileIcons, typeof(ProfileIconDataDto))
                        .HasQueryParameters(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                        })
                        .SubApi(ApiMiddleName.Realms, typeof(RealmDto))
                        .SubApi(ApiMiddleName.Runes, typeof(RuneListDto))
                        .HasQueryParameters(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"tags",typeof(List<RuneTag>)},
                        })
                        .SubApi(ApiMiddleName.Runes, typeof(RuneDto), ApiParam.OnlyId)
                        .HasQueryParameters(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"tags",typeof(List<RuneTag>)},
                        })
                        .SubApi(ApiMiddleName.SummonerSpells, typeof(SummonerSpellListDto))
                        .HasQueryParameters(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"dataById",typeof(bool) },
                            {"tags",typeof(List<SummonerSpellTag>) }
                        })
                        .SubApi(ApiMiddleName.SummonerSpells, typeof(SummonerSpellDto), ApiParam.OnlyId)
                        .HasQueryParameters(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"dataById",typeof(bool) },
                            {"tags",typeof(List<SummonerSpellTag>) }
                        })
                        .SubApi(ApiMiddleName.Versions, typeof(List<string>));
                    return api;
                })
                .UseNonStaticApi(api =>
                {
                    api.AddApi(ApiName.ChampionMastery, 3.0)
                        .SubApi(ApiMiddleName.ChampionMasteries, typeof(List<ChampionMasteryDto>), ApiParam.BySummoner)
                        .SubApi(ApiMiddleName.ChampionMasteries, typeof(ChampionMasteryDto), ApiParam.BySummoner, ApiParam.ByChampion)
                        .SubApi(ApiMiddleName.Scores, typeof(int), ApiParam.BySummoner);

                    api.AddApi(ApiName.Summoner, 3.0)
                        .SubApi(ApiMiddleName.Summoners, typeof(SummonerDto), ApiParam.ByAccount)
                        .SubApi(ApiMiddleName.Summoners, typeof(SummonerDto), ApiParam.ByName)
                        .SubApi(ApiMiddleName.Summoners, typeof(SummonerDto), ApiParam.OnlySummonerId);

                    api.AddApi(ApiName.Platform, 3.0)
                        .SubApi(ApiMiddleName.Champions, typeof(RiotApi.NonStaticEndPoints.Champion.ChampionListDto))
                        .SubApi(ApiMiddleName.Champions, typeof(RiotApi.NonStaticEndPoints.Champion.ChampionDto), ApiParam.OnlyId)
                        .SubApi(ApiMiddleName.Masteries, typeof(MasteryPagesDto), ApiParam.BySummoner)
                        .SubApi(ApiMiddleName.Runes, typeof(RunePagesDto), ApiParam.BySummoner);

                    api.AddApi(ApiName.League, 3.0)
                        .SubApi(ApiMiddleName.ChallengerLeagues, typeof(LeagueListDTO), ApiParam.ByQueue)
                        .SubApi(ApiMiddleName.Leagues, typeof(List<LeagueListDTO>), ApiParam.BySummoner)
                        .SubApi(ApiMiddleName.MasterLeagues, typeof(LeagueListDTO), ApiParam.ByQueue)
                        .SubApi(ApiMiddleName.Positions, typeof(List<LeaguePositionDTO>), ApiParam.BySummoner);

                    //version testing
                    //api.AddApi(ApiName.League, 3.1)
                    //    .SubApi(ApiMiddleName.ChallengerLeagues, typeof(LeagueListDTO), ApiParam.ByQueue);

                    api.AddApi(ApiName.Match, 3.0)
                        .SubApi(ApiMiddleName.Matches, typeof(MatchDto), ApiParam.OnlyMatchId)
                        .SubApi(ApiMiddleName.MatchLists, typeof(MatchlistDto), ApiParam.ByAccount)
                        .SubApi(ApiMiddleName.MatchLists, typeof(MatchlistDto), ApiParam.ByAccountRecent)
                        .SubApi(ApiMiddleName.Timelines, typeof(MatchTimelineDto), ApiParam.ByMatch)
                        .SubApi(ApiMiddleName.Matches, typeof(List<long>), ApiParam.ByTournamentCodeIds)
                        .SubApi(ApiMiddleName.Matches, typeof(MatchDto), ApiParam.OnlyMatchId, ApiParam.ByTournamentCode);

                    api.AddApi(ApiName.Spectator, 3.0)
                        .SubApi(ApiMiddleName.ActiveGames, typeof(CurrentGameInfo), ApiParam.BySummoner)
                        .SubApi(ApiMiddleName.FeaturedGames, typeof(FeaturedGames));
                    return api;
                });

            var RiotGamesApiOption = RiotGamesApiBuilder.Build();

            if (cacheOption != null)
            {
                RiotGamesApiOption.CacheOptions = cacheOption(new CacheOption());//user settings
            }
            else
            {
                RiotGamesApiOption.CacheOptions = new CacheOption();//default settings
            }

            services.AddSingleton<IRiotGamesApiOption>(RiotGamesApiOption);
        }
    }
}