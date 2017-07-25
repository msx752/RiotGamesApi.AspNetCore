using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using RiotGamesApi.AspNetCore.Builder;
using RiotGamesApi.AspNetCore.Cache;
using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.Interfaces;
using RiotGamesApi.AspNetCore.RateLimit;
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
using RiotGamesApi.AspNetCore.RiotApi.TournamentEndPoints;
using System;
using System.Collections.Generic;
using RiotGamesApi.AspNetCore.RateLimit.Builder;
using LobbyEventDTOWrapper = RiotGamesApi.AspNetCore.RiotApi.TournamentEndPoints.LobbyEventDTOWrapper;
using MasteryDto = RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Masteries.MasteryDto;
using RuneDto = RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Runes.RuneDto;
using TournamentCodeParameters = RiotGamesApi.AspNetCore.RiotApi.TournamentEndPoints.TournamentCodeParameters;

namespace RiotGamesApi.AspNetCore.Extensions
{
    public static class Extension2
    {
        public static void AddLeagueOfLegendsApi(this IServiceCollection services, string riotApiKey)
        {
            AddLeagueOfLegendsApi(services, riotApiKey, null);
        }

        public static void AddLeagueOfLegendsApi(this IServiceCollection services, string riotApiKey,
            Func<CacheOption, CacheOption> cacheOption = null)
        {
            AddLeagueOfLegendsApi(services, riotApiKey, cacheOption, null);
        }

        public static void AddLeagueOfLegendsApi(this IServiceCollection services, string riotApiKey,
            Func<CacheOption, CacheOption> cacheOption = null,
            Func<RateLimitData, RateLimitData> rateLimitOption2 = null)
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
                riotGamesApiOption.CacheOptions = cacheOption(new CacheOption());//user settings
            else
                riotGamesApiOption.CacheOptions = new CacheOption();//default settings

            RateLimitData limits = new RateLimitData();
            if (rateLimitOption2 != null)
            {
                limits = rateLimitOption2(new RateLimitData()); //user settings
            }
            else
            {
                limits.DisableLimiting = false;
                limits.AddXAppRateLimits(new Dictionary<TimeSpan, int>()
                {
                    {new TimeSpan(0, 2, 0), 100 },
                    {new TimeSpan(0, 0, 1), 20 }
                });

                limits.AddXMethodRateLimits(new Dictionary<TimeSpan, int>()
                {
                    {new TimeSpan(0, 10, 0), 1200000 },
                    {new TimeSpan(0, 0, 10), 20000 }
                });

                limits.SetMatchApiXMethodRateLimit(new TimeSpan(0, 0, 10), 500);
            }

            RateLimitBuilder rlb = new RateLimitBuilder()
            .AddRateLimitFor(LolUrlType.Status, new List<LolApiName>()
            {
                LolApiName.Status
            }, limits.GetXMethodRateLimit())
            .AddRateLimitFor(LolUrlType.Static, new List<LolApiName>()
            {
                LolApiName.StaticData
            }, limits.GetXMethodRateLimit())
            .AddRateLimitFor(LolUrlType.NonStatic, new List<LolApiName>()
            {
                LolApiName.Match
            }, limits.MergeWithMatch())
            .AddRateLimitFor(LolUrlType.Tournament, new List<LolApiName>()
                {
                LolApiName.Tournament,
                LolApiName.TournamentStub
            }, limits.MergeNormal())
            .AddRateLimitFor(LolUrlType.NonStatic, new List<LolApiName>()
            {
                LolApiName.ChampionMastery,
                LolApiName.Platform,
                LolApiName.League,
                LolApiName.Spectator,
                LolApiName.Summoner
            }, limits.MergeNormal());

            riotGamesApiOption.RateLimitOptions.All = rlb.Build();
            riotGamesApiOption.RateLimitOptions.DisableLimiting = limits.DisableLimiting;
            services.AddSingleton<IApiOption>(riotGamesApiOption);
            services.AddMemoryCache();
            services.AddSingleton<IApiCache>(new ApiCache());
            services.AddSingleton<Api>(new Api());
            services.AddSingleton<ApiRate>(new ApiRate());
        }

        public static IApplicationBuilder UseRiotGamesApi(this IApplicationBuilder app)
        {
            var sProvider = app.ApplicationServices;
            ApiSettings.ServiceProvider = sProvider;
            return app;
        }
    }
}