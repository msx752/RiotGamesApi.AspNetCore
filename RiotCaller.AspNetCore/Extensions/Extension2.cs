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
        public static RiotGamesApiUrl AddApi(this Models.RiotGamesApi option, ApiName suffix1, double _version)
        {
            RiotGamesApiUrl sff1 = new RiotGamesApiUrl(suffix1, _version);
            option.RiotGamesApiUrls.Add(sff1);
            return sff1;
        }

        public static RiotGamesApiUrl GetMethod(this RiotGamesApiUrl option, ApiMethodName middleType, Type returnType, params ApiPath[] subApis)
        {
            option.ApiMethods.Add(new Method(middleType, subApis, returnType, ApiMethodType.GET));
            option.LastApiMethodIndex = option.ApiMethods.Count - 1;
            return option;
        }

        public static RiotGamesApiUrl PostMethod(this RiotGamesApiUrl option, ApiMethodName middleType, Type returnType, Type bodyValueType, bool IsBodyRequired,
            params ApiPath[] subApis)
        {
            option.ApiMethods.Add(new Method(middleType, subApis, returnType, ApiMethodType.POST, bodyValueType, IsBodyRequired));
            option.LastApiMethodIndex = option.ApiMethods.Count - 1;
            return option;
        }

        public static RiotGamesApiUrl PutMethod(this RiotGamesApiUrl option, ApiMethodName methodName, Type bodyValueType, bool IsBodyRequired,
            params ApiPath[] subApis)
        {
            option.ApiMethods.Add(new Method(methodName, subApis, null, ApiMethodType.PUT, bodyValueType, IsBodyRequired));
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
        public static RiotGamesApiUrl AddQueryParameter(this RiotGamesApiUrl option, Dictionary<string, Type> queryParameterTypes)
        {
            try
            {
                if (option.ApiName == ApiName.StaticData ||
                    option.ApiName == ApiName.Tournament ||
                    option.ApiName == ApiName.TournamentStub)
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

        public static void AddRiotGamesApi(this IServiceCollection services, string riotApiKey, Func<CacheOption, CacheOption> cacheOption = null)
        {
            //can convertable to json
            var riotGamesApiBuilder = new RiotGamesApiBuilder()
                .UseRiotApiKey(riotApiKey)
                .UseApiUrl("api.riotgames.com")
                .UseStatusApi((apis) =>
                {
                    apis.AddApi(ApiName.Status, 3.0)
                        .GetMethod(ApiMethodName.ShardData, typeof(ShardStatus));
                    return apis;
                })
                .UseStaticApi((apis) =>
                {
                    apis.AddApi(ApiName.StaticData, 3.0)
                        .GetMethod(ApiMethodName.Champions, typeof(ChampionListDto))
                        .AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"tags",typeof(List<ChampionTag>)},
                            {"dataById",typeof(bool)},
                        })
                        .GetMethod(ApiMethodName.Champions, typeof(ChampionDto), ApiPath.OnlyId)
                        .AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"tags",typeof(List<ChampionTag>)},
                            {"dataById",typeof(bool)},
                        })
                        .GetMethod(ApiMethodName.Items, typeof(ItemListDto))
                        .AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"tags",typeof(List<ItemTag>)},
                        })
                        .GetMethod(ApiMethodName.Items, typeof(ItemDto), ApiPath.OnlyId)
                        .AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"tags",typeof(List<ItemTag>)},
                        })
                        .GetMethod(ApiMethodName.LanguageStrings, typeof(LanguageStringsDto))
                        .AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                        })
                        .GetMethod(ApiMethodName.Languages, typeof(List<string>))
                        .GetMethod(ApiMethodName.Maps, typeof(MapDataDto))
                        .AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                        })
                        .GetMethod(ApiMethodName.Masteries, typeof(MasteryListDto)).AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"tags",typeof(List<MasteryTag>)},
                        })
                        .GetMethod(ApiMethodName.Masteries, typeof(MasteryDto), ApiPath.OnlyId).AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"tags",typeof(List<MasteryTag>)},
                        })
                        .GetMethod(ApiMethodName.ProfileIcons, typeof(ProfileIconDataDto))
                        .AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                        })
                        .GetMethod(ApiMethodName.Realms, typeof(RealmDto))
                        .GetMethod(ApiMethodName.Runes, typeof(RuneListDto))
                        .AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"tags",typeof(List<RuneTag>)},
                        })
                        .GetMethod(ApiMethodName.Runes, typeof(RuneDto), ApiPath.OnlyId)
                        .AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"tags",typeof(List<RuneTag>)},
                        })
                        .GetMethod(ApiMethodName.SummonerSpells, typeof(SummonerSpellListDto))
                        .AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"dataById",typeof(bool) },
                            {"tags",typeof(List<SummonerSpellTag>) }
                        })
                        .GetMethod(ApiMethodName.SummonerSpells, typeof(SummonerSpellDto), ApiPath.OnlyId)
                        .AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"dataById",typeof(bool) },
                            {"tags",typeof(List<SummonerSpellTag>) }
                        })
                        .GetMethod(ApiMethodName.Versions, typeof(List<string>));
                    return apis;
                })
                .UseNonStaticApi(apis =>
                {
                    apis.AddApi(ApiName.ChampionMastery, 3.0)
                        .GetMethod(ApiMethodName.ChampionMasteries, typeof(List<ChampionMasteryDto>), ApiPath.BySummoner)
                        .GetMethod(ApiMethodName.ChampionMasteries, typeof(ChampionMasteryDto), ApiPath.BySummoner, ApiPath.ByChampion)
                        .GetMethod(ApiMethodName.Scores, typeof(int), ApiPath.BySummoner);

                    apis.AddApi(ApiName.Summoner, 3.0)
                        .GetMethod(ApiMethodName.Summoners, typeof(SummonerDto), ApiPath.ByAccount)
                        .GetMethod(ApiMethodName.Summoners, typeof(SummonerDto), ApiPath.ByName)
                        .GetMethod(ApiMethodName.Summoners, typeof(SummonerDto), ApiPath.OnlySummonerId);

                    apis.AddApi(ApiName.Platform, 3.0)
                        .GetMethod(ApiMethodName.Champions, typeof(RiotApi.NonStaticEndPoints.Champion.ChampionListDto))
                        .GetMethod(ApiMethodName.Champions, typeof(RiotApi.NonStaticEndPoints.Champion.ChampionDto), ApiPath.OnlyId)
                        .GetMethod(ApiMethodName.Masteries, typeof(MasteryPagesDto), ApiPath.BySummoner)
                        .GetMethod(ApiMethodName.Runes, typeof(RunePagesDto), ApiPath.BySummoner);

                    apis.AddApi(ApiName.League, 3.0)
                        .GetMethod(ApiMethodName.ChallengerLeagues, typeof(LeagueListDTO), ApiPath.ByQueue)
                        .GetMethod(ApiMethodName.Leagues, typeof(List<LeagueListDTO>), ApiPath.BySummoner)
                        .GetMethod(ApiMethodName.MasterLeagues, typeof(LeagueListDTO), ApiPath.ByQueue)
                        .GetMethod(ApiMethodName.Positions, typeof(List<LeaguePositionDTO>), ApiPath.BySummoner);

                    //version testing
                    //apis.AddApi(ApiName.League, 3.1)
                    //    .SubApi(ApiMiddleName.ChallengerLeagues, typeof(LeagueListDTO), ApiParam.ByQueue);

                    apis.AddApi(ApiName.Match, 3.0)
                        .GetMethod(ApiMethodName.Matches, typeof(MatchDto), ApiPath.OnlyMatchId)
                        .GetMethod(ApiMethodName.MatchLists, typeof(MatchlistDto), ApiPath.ByAccount)
                        .GetMethod(ApiMethodName.MatchLists, typeof(MatchlistDto), ApiPath.ByAccountRecent)
                        .GetMethod(ApiMethodName.Timelines, typeof(MatchTimelineDto), ApiPath.ByMatch)
                        .GetMethod(ApiMethodName.Matches, typeof(List<long>), ApiPath.ByTournamentCodeIds)
                        .GetMethod(ApiMethodName.Matches, typeof(MatchDto), ApiPath.OnlyMatchId, ApiPath.ByTournamentCode);

                    apis.AddApi(ApiName.Spectator, 3.0)
                        .GetMethod(ApiMethodName.ActiveGames, typeof(CurrentGameInfo), ApiPath.BySummoner)
                        .GetMethod(ApiMethodName.FeaturedGames, typeof(FeaturedGames));

                    return apis;
                })
                .UseTournamentApi((apis) =>
                {
                    apis.AddApi(ApiName.TournamentStub, 3.0)
                        .PostMethod(ApiMethodName.Codes, typeof(List<string>), typeof(TournamentCodeParameters), false)
                        .AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"count", typeof(int)},
                            {"tournamentId", typeof(int)}
                        })
                        .GetMethod(ApiMethodName.LobbyEvents, typeof(LobbyEventDTOWrapper), ApiPath.ByCode)
                        .PostMethod(ApiMethodName.Providers, typeof(int), typeof(ProviderRegistrationParameters), true)
                        .PostMethod(ApiMethodName.Tournaments, typeof(int), typeof(TournamentRegistrationParameters), true);

                    apis.AddApi(ApiName.Tournament, 3.0)
                        .PostMethod(ApiMethodName.Codes, typeof(List<string>), typeof(TournamentCodeParameters), true)
                        .AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"count", typeof(int)},
                            {"tournamentId", typeof(int)}
                        })
                        .PutMethod(ApiMethodName.Codes, typeof(TournamentCodeUpdateParameters), false, ApiPath.OnlyTournamentCode)
                        .GetMethod(ApiMethodName.Codes, typeof(TournamentCodeDTO), ApiPath.OnlyTournamentCode)
                        .GetMethod(ApiMethodName.LobbyEvents, typeof(LobbyEventDTOWrapper), ApiPath.ByCode)
                        .PostMethod(ApiMethodName.Providers, typeof(int), typeof(ProviderRegistrationParameters), true)
                        .PostMethod(ApiMethodName.Tournaments, typeof(int), typeof(TournamentRegistrationParameters), true);

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
        }
    }
}