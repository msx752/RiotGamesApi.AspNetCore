using Microsoft.Extensions.DependencyInjection;
using RiotGamesApi.AspNetCore.Builder;
using RiotGamesApi.AspNetCore.Cache;
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
using Microsoft.AspNetCore.Builder;
using RiotGamesApi.AspNetCore.RiotApi.TournamentEndPoints;
using LobbyEventDTOWrapper = RiotGamesApi.AspNetCore.RiotApi.TournamentStubEndPoints.LobbyEventDTOWrapper;
using MasteryDto = RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Masteries.MasteryDto;
using RuneDto = RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Runes.RuneDto;
using TournamentCodeParameters = RiotGamesApi.AspNetCore.RiotApi.TournamentStubEndPoints.TournamentCodeParameters;

namespace RiotGamesApi.AspNetCore.Extensions
{
    public static class Extension2
    {
        public static LolApiUrl AddApi(this Models.RiotGamesApi option, LolApiName suffix1, double _version)
        {
            LolApiUrl sff1 = new LolApiUrl(suffix1, _version);
            option.RiotGamesApiUrls.Add(sff1);
            return sff1;
        }

        public static LolApiUrl GetMethod(this LolApiUrl option, LolApiMethodName middleType, Type returnType, params LolApiPath[] subApis)
        {
            option.ApiMethods.Add(new Method(middleType, subApis, returnType, ApiMethodType.Get));
            option.LastApiMethodIndex = option.ApiMethods.Count - 1;
            return option;
        }

        public static LolApiUrl PostMethod(this LolApiUrl option, LolApiMethodName middleType, Type returnType, Type bodyValueType, bool IsBodyRequired,
            params LolApiPath[] subApis)
        {
            option.ApiMethods.Add(new Method(middleType, subApis, returnType, ApiMethodType.Post, bodyValueType, IsBodyRequired));
            option.LastApiMethodIndex = option.ApiMethods.Count - 1;
            return option;
        }

        public static LolApiUrl PutMethod(this LolApiUrl option, LolApiMethodName methodName, Type bodyValueType, bool IsBodyRequired,
            params LolApiPath[] subApis)
        {
            option.ApiMethods.Add(new Method(methodName, subApis, typeof(int), ApiMethodType.Put, bodyValueType, IsBodyRequired));
            option.LastApiMethodIndex = option.ApiMethods.Count - 1;
            return option;
        }

        /// <summary>
        /// </summary>
        /// <param name="option">
        /// </param>
        /// <param name="queryParameterTypes">
        /// NAME,TYPE 
        /// </param>
        /// <returns>
        /// </returns>
        public static LolApiUrl AddQueryParameter(this LolApiUrl option, Dictionary<string, Type> queryParameterTypes)
        {
            try
            {
                if (option.ApiName == LolApiName.StaticData ||
                    option.ApiName == LolApiName.Tournament ||
                    option.ApiName == LolApiName.TournamentStub)
                {
                    option.ApiMethods[option.LastApiMethodIndex].TypesOfQueryParameter = queryParameterTypes;
                }
                else
                {
                    throw new Exception("QueryParameters only for static-data and tournament");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return option;
        }

        public static IApplicationBuilder UseRiotGamesApi(this IApplicationBuilder app)
        {
            var sProvider = app.ApplicationServices;
            ApiSettings.ServiceProvider = sProvider;
            return app;
        }

        public static void AddLeagueOfLegendsApi(this IServiceCollection services, string riotApiKey, Func<CacheOption, CacheOption> cacheOption = null)
        {
            //can convertable to json
            var riotGamesApiBuilder = new RiotGamesApiBuilder()
                .UseRiotApiKey(riotApiKey)
                .UseApiUrl("api.riotgames.com")
                .UseStatusApi((apis) =>
                {
                    apis.AddApi(LolApiName.Status, 3)
                        .GetMethod(LolApiMethodName.ShardData, typeof(ShardStatus));
                    return apis;
                })
                .UseStaticApi((apis) =>
                {
                    apis.AddApi(LolApiName.StaticData, 3.0)
                        .GetMethod(LolApiMethodName.Champions, typeof(ChampionListDto))
                        .AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"tags",typeof(List<ChampionTag>)},
                            {"dataById",typeof(bool)},
                        })
                        .GetMethod(LolApiMethodName.Champions, typeof(ChampionDto), LolApiPath.OnlyId)
                        .AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"tags",typeof(List<ChampionTag>)},
                            {"dataById",typeof(bool)},
                        })
                        .GetMethod(LolApiMethodName.Items, typeof(ItemListDto))
                        .AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"tags",typeof(List<ItemTag>)},
                        })
                        .GetMethod(LolApiMethodName.Items, typeof(ItemDto), LolApiPath.OnlyId)
                        .AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"tags",typeof(List<ItemTag>)},
                        })
                        .GetMethod(LolApiMethodName.LanguageStrings, typeof(LanguageStringsDto))
                        .AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                        })
                        .GetMethod(LolApiMethodName.Languages, typeof(List<string>))
                        .GetMethod(LolApiMethodName.Maps, typeof(MapDataDto))
                        .AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                        })
                        .GetMethod(LolApiMethodName.Masteries, typeof(MasteryListDto)).AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"tags",typeof(List<MasteryTag>)},
                        })
                        .GetMethod(LolApiMethodName.Masteries, typeof(MasteryDto), LolApiPath.OnlyId).AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"tags",typeof(List<MasteryTag>)},
                        })
                        .GetMethod(LolApiMethodName.ProfileIcons, typeof(ProfileIconDataDto))
                        .AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                        })
                        .GetMethod(LolApiMethodName.Realms, typeof(RealmDto))
                        .GetMethod(LolApiMethodName.Runes, typeof(RuneListDto))
                        .AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"tags",typeof(List<RuneTag>)},
                        })
                        .GetMethod(LolApiMethodName.Runes, typeof(RuneDto), LolApiPath.OnlyId)
                        .AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"tags",typeof(List<RuneTag>)},
                        })
                        .GetMethod(LolApiMethodName.SummonerSpells, typeof(SummonerSpellListDto))
                        .AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"dataById",typeof(bool) },
                            {"tags",typeof(List<SummonerSpellTag>) }
                        })
                        .GetMethod(LolApiMethodName.SummonerSpells, typeof(SummonerSpellDto), LolApiPath.OnlyId)
                        .AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"dataById",typeof(bool) },
                            {"tags",typeof(List<SummonerSpellTag>) }
                        })
                        .GetMethod(LolApiMethodName.Versions, typeof(List<string>));
                    return apis;
                })
                .UseNonStaticApi(apis =>
                {
                    apis.AddApi(LolApiName.ChampionMastery, 3.0)
                        .GetMethod(LolApiMethodName.ChampionMasteries, typeof(List<ChampionMasteryDto>), LolApiPath.BySummoner)
                        .GetMethod(LolApiMethodName.ChampionMasteries, typeof(ChampionMasteryDto), LolApiPath.BySummoner, LolApiPath.ByChampion)
                        .GetMethod(LolApiMethodName.Scores, typeof(int), LolApiPath.BySummoner);

                    apis.AddApi(LolApiName.Summoner, 3.0)
                        .GetMethod(LolApiMethodName.Summoners, typeof(SummonerDto), LolApiPath.ByAccount)
                        .GetMethod(LolApiMethodName.Summoners, typeof(SummonerDto), LolApiPath.ByName)
                        .GetMethod(LolApiMethodName.Summoners, typeof(SummonerDto), LolApiPath.OnlySummonerId);

                    apis.AddApi(LolApiName.Platform, 3.0)
                        .GetMethod(LolApiMethodName.Champions, typeof(RiotApi.NonStaticEndPoints.Champion.ChampionListDto))
                        .GetMethod(LolApiMethodName.Champions, typeof(RiotApi.NonStaticEndPoints.Champion.ChampionDto), LolApiPath.OnlyId)
                        .GetMethod(LolApiMethodName.Masteries, typeof(MasteryPagesDto), LolApiPath.BySummoner)
                        .GetMethod(LolApiMethodName.Runes, typeof(RunePagesDto), LolApiPath.BySummoner);

                    apis.AddApi(LolApiName.League, 3.0)
                        .GetMethod(LolApiMethodName.ChallengerLeagues, typeof(LeagueListDTO), LolApiPath.ByQueue)
                        .GetMethod(LolApiMethodName.Leagues, typeof(List<LeagueListDTO>), LolApiPath.BySummoner)
                        .GetMethod(LolApiMethodName.MasterLeagues, typeof(LeagueListDTO), LolApiPath.ByQueue)
                        .GetMethod(LolApiMethodName.Positions, typeof(List<LeaguePositionDTO>), LolApiPath.BySummoner);

                    //version testing
                    //apis.AddApi(ApiName.League, 3.1)
                    //    .SubApi(ApiMiddleName.ChallengerLeagues, typeof(LeagueListDTO), ApiParam.ByQueue);

                    apis.AddApi(LolApiName.Match, 3.0)
                        .GetMethod(LolApiMethodName.Matches, typeof(MatchDto), LolApiPath.OnlyMatchId)
                        .GetMethod(LolApiMethodName.MatchLists, typeof(MatchlistDto), LolApiPath.ByAccount)
                        .GetMethod(LolApiMethodName.MatchLists, typeof(MatchlistDto), LolApiPath.ByAccountRecent)
                        .GetMethod(LolApiMethodName.Timelines, typeof(MatchTimelineDto), LolApiPath.ByMatch)
                        .GetMethod(LolApiMethodName.Matches, typeof(List<long>), LolApiPath.ByTournamentCodeIds)
                        .GetMethod(LolApiMethodName.Matches, typeof(MatchDto), LolApiPath.OnlyMatchId, LolApiPath.ByTournamentCode);

                    apis.AddApi(LolApiName.Spectator, 3.0)
                        .GetMethod(LolApiMethodName.ActiveGames, typeof(CurrentGameInfo), LolApiPath.BySummoner)
                        .GetMethod(LolApiMethodName.FeaturedGames, typeof(FeaturedGames));

                    return apis;
                })
                .UseTournamentApi((apis) =>
                {
                    apis.AddApi(LolApiName.TournamentStub, 3.0)
                        .PostMethod(LolApiMethodName.Codes, typeof(List<string>), typeof(TournamentCodeParameters), false)
                        .AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"count", typeof(int)},
                            {"tournamentId", typeof(int)}
                        })
                        .GetMethod(LolApiMethodName.LobbyEvents, typeof(LobbyEventDTOWrapper), LolApiPath.ByCode)
                        .PostMethod(LolApiMethodName.Providers, typeof(int), typeof(ProviderRegistrationParameters), true)
                        .PostMethod(LolApiMethodName.Tournaments, typeof(int), typeof(TournamentRegistrationParameters), true);

                    apis.AddApi(LolApiName.Tournament, 3.0)
                        .PostMethod(LolApiMethodName.Codes, typeof(List<string>), typeof(RiotGamesApi.AspNetCore.RiotApi.TournamentEndPoints.TournamentCodeParameters), true)
                        .AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"count", typeof(int)},
                            {"tournamentId", typeof(int)}
                        })
                        .PutMethod(LolApiMethodName.Codes, typeof(TournamentCodeUpdateParameters), false, LolApiPath.OnlyTournamentCode)
                        .GetMethod(LolApiMethodName.Codes, typeof(TournamentCodeDTO), LolApiPath.OnlyTournamentCode)
                        .GetMethod(LolApiMethodName.LobbyEvents, typeof(RiotGamesApi.AspNetCore.RiotApi.TournamentEndPoints.LobbyEventDTOWrapper), LolApiPath.ByCode)
                        .PostMethod(LolApiMethodName.Providers, typeof(int), typeof(RiotGamesApi.AspNetCore.RiotApi.TournamentEndPoints.ProviderRegistrationParameters), true)
                        .PostMethod(LolApiMethodName.Tournaments, typeof(int), typeof(RiotGamesApi.AspNetCore.RiotApi.TournamentEndPoints.TournamentRegistrationParameters), true);

                    return apis;
                });

            var riotGamesApiOption = riotGamesApiBuilder.Build();

            if (cacheOption != null)
            {
                riotGamesApiOption.CacheOptions = cacheOption(new CacheOption());//user settings
            }
            else
            {
                riotGamesApiOption.CacheOptions = new CacheOption();//default settings
            }

            services.AddSingleton<IApiOption>(riotGamesApiOption);
            services.AddMemoryCache();
            services.AddSingleton<IApiCache>(new ApiCache());
            services.AddSingleton<Api>(new Api());
        }
    }
}