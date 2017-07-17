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

        public static RiotGamesApiUrl GetApi(this RiotGamesApiUrl option, ApiMiddleName middleType, Type returnType, params ApiParam[] subApis)
        {
            option.SubUrls.Add(new SubUrl(middleType, subApis, returnType, ApiRequestType.GET));
            option.LastSubUrlIndex = option.SubUrls.Count - 1;
            return option;
        }

        public static RiotGamesApiUrl PostApi(this RiotGamesApiUrl option, ApiMiddleName middleType, Type returnType, Type bodyValueType, bool IsBodyRequired,
            params ApiParam[] subApis)
        {
            option.SubUrls.Add(new SubUrl(middleType, subApis, returnType, ApiRequestType.POST, bodyValueType, IsBodyRequired));
            option.LastSubUrlIndex = option.SubUrls.Count - 1;
            return option;
        }

        public static RiotGamesApiUrl PutApi(this RiotGamesApiUrl option, ApiMiddleName middleType, Type bodyValueType, bool IsBodyRequired,
            params ApiParam[] subApis)
        {
            option.SubUrls.Add(new SubUrl(middleType, subApis, null, ApiRequestType.PUT, bodyValueType, IsBodyRequired));
            option.LastSubUrlIndex = option.SubUrls.Count - 1;
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
        public static RiotGamesApiUrl HasQueryParameters(this RiotGamesApiUrl option, Dictionary<string, Type> queryParameterTypes)
        {
            try
            {
                if (option.SubUrl == ApiName.StaticData ||
                    option.SubUrl == ApiName.Tournament ||
                    option.SubUrl == ApiName.TournamentStub)
                {
                    option.SubUrls[option.LastSubUrlIndex].QueryParameterTypes = queryParameterTypes;
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

        public static void AddRiotGamesApi(this IServiceCollection services, string riotApiKey, Func<CacheOption, CacheOption> cacheOption = null)
        {
            //can convertable to json
            var riotGamesApiBuilder = new RiotGamesApiBuilder()
                .UseRiotApiKey(riotApiKey)
                .UseApiUrl("api.riotgames.com")
                .UseStatusApi((apis) =>
                {
                    apis.AddApi(ApiName.Status, 3.0)
                        .GetApi(ApiMiddleName.ShardData, typeof(ShardStatus));
                    return apis;
                })
                .UseStaticApi((apis) =>
                {
                    apis.AddApi(ApiName.StaticData, 3.0)
                        .GetApi(ApiMiddleName.Champions, typeof(ChampionListDto))
                        .HasQueryParameters(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"tags",typeof(List<ChampionTag>)},
                            {"dataById",typeof(bool)},
                        })
                        .GetApi(ApiMiddleName.Champions, typeof(ChampionDto), ApiParam.OnlyId)
                        .HasQueryParameters(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"tags",typeof(List<ChampionTag>)},
                            {"dataById",typeof(bool)},
                        })
                        .GetApi(ApiMiddleName.Items, typeof(ItemListDto))
                        .HasQueryParameters(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"tags",typeof(List<ItemTag>)},
                        })
                        .GetApi(ApiMiddleName.Items, typeof(ItemDto), ApiParam.OnlyId)
                        .HasQueryParameters(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"tags",typeof(List<ItemTag>)},
                        })
                        .GetApi(ApiMiddleName.LanguageStrings, typeof(LanguageStringsDto))
                        .HasQueryParameters(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                        })
                        .GetApi(ApiMiddleName.Languages, typeof(List<string>))
                        .GetApi(ApiMiddleName.Maps, typeof(MapDataDto))
                        .HasQueryParameters(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                        })
                        .GetApi(ApiMiddleName.Masteries, typeof(MasteryListDto)).HasQueryParameters(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"tags",typeof(List<MasteryTag>)},
                        })
                        .GetApi(ApiMiddleName.Masteries, typeof(MasteryDto), ApiParam.OnlyId).HasQueryParameters(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"tags",typeof(List<MasteryTag>)},
                        })
                        .GetApi(ApiMiddleName.ProfileIcons, typeof(ProfileIconDataDto))
                        .HasQueryParameters(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                        })
                        .GetApi(ApiMiddleName.Realms, typeof(RealmDto))
                        .GetApi(ApiMiddleName.Runes, typeof(RuneListDto))
                        .HasQueryParameters(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"tags",typeof(List<RuneTag>)},
                        })
                        .GetApi(ApiMiddleName.Runes, typeof(RuneDto), ApiParam.OnlyId)
                        .HasQueryParameters(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"tags",typeof(List<RuneTag>)},
                        })
                        .GetApi(ApiMiddleName.SummonerSpells, typeof(SummonerSpellListDto))
                        .HasQueryParameters(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"dataById",typeof(bool) },
                            {"tags",typeof(List<SummonerSpellTag>) }
                        })
                        .GetApi(ApiMiddleName.SummonerSpells, typeof(SummonerSpellDto), ApiParam.OnlyId)
                        .HasQueryParameters(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"dataById",typeof(bool) },
                            {"tags",typeof(List<SummonerSpellTag>) }
                        })
                        .GetApi(ApiMiddleName.Versions, typeof(List<string>));
                    return apis;
                })
                .UseNonStaticApi(apis =>
                {
                    apis.AddApi(ApiName.ChampionMastery, 3.0)
                        .GetApi(ApiMiddleName.ChampionMasteries, typeof(List<ChampionMasteryDto>), ApiParam.BySummoner)
                        .GetApi(ApiMiddleName.ChampionMasteries, typeof(ChampionMasteryDto), ApiParam.BySummoner, ApiParam.ByChampion)
                        .GetApi(ApiMiddleName.Scores, typeof(int), ApiParam.BySummoner);

                    apis.AddApi(ApiName.Summoner, 3.0)
                        .GetApi(ApiMiddleName.Summoners, typeof(SummonerDto), ApiParam.ByAccount)
                        .GetApi(ApiMiddleName.Summoners, typeof(SummonerDto), ApiParam.ByName)
                        .GetApi(ApiMiddleName.Summoners, typeof(SummonerDto), ApiParam.OnlySummonerId);

                    apis.AddApi(ApiName.Platform, 3.0)
                        .GetApi(ApiMiddleName.Champions, typeof(RiotApi.NonStaticEndPoints.Champion.ChampionListDto))
                        .GetApi(ApiMiddleName.Champions, typeof(RiotApi.NonStaticEndPoints.Champion.ChampionDto), ApiParam.OnlyId)
                        .GetApi(ApiMiddleName.Masteries, typeof(MasteryPagesDto), ApiParam.BySummoner)
                        .GetApi(ApiMiddleName.Runes, typeof(RunePagesDto), ApiParam.BySummoner);

                    apis.AddApi(ApiName.League, 3.0)
                        .GetApi(ApiMiddleName.ChallengerLeagues, typeof(LeagueListDTO), ApiParam.ByQueue)
                        .GetApi(ApiMiddleName.Leagues, typeof(List<LeagueListDTO>), ApiParam.BySummoner)
                        .GetApi(ApiMiddleName.MasterLeagues, typeof(LeagueListDTO), ApiParam.ByQueue)
                        .GetApi(ApiMiddleName.Positions, typeof(List<LeaguePositionDTO>), ApiParam.BySummoner);

                    //version testing
                    //apis.AddApi(ApiName.League, 3.1)
                    //    .SubApi(ApiMiddleName.ChallengerLeagues, typeof(LeagueListDTO), ApiParam.ByQueue);

                    apis.AddApi(ApiName.Match, 3.0)
                        .GetApi(ApiMiddleName.Matches, typeof(MatchDto), ApiParam.OnlyMatchId)
                        .GetApi(ApiMiddleName.MatchLists, typeof(MatchlistDto), ApiParam.ByAccount)
                        .GetApi(ApiMiddleName.MatchLists, typeof(MatchlistDto), ApiParam.ByAccountRecent)
                        .GetApi(ApiMiddleName.Timelines, typeof(MatchTimelineDto), ApiParam.ByMatch)
                        .GetApi(ApiMiddleName.Matches, typeof(List<long>), ApiParam.ByTournamentCodeIds)
                        .GetApi(ApiMiddleName.Matches, typeof(MatchDto), ApiParam.OnlyMatchId, ApiParam.ByTournamentCode);

                    apis.AddApi(ApiName.Spectator, 3.0)
                        .GetApi(ApiMiddleName.ActiveGames, typeof(CurrentGameInfo), ApiParam.BySummoner)
                        .GetApi(ApiMiddleName.FeaturedGames, typeof(FeaturedGames));

                    return apis;
                })
                .UseTournamentApi((apis) =>
                {
                    apis.AddApi(ApiName.TournamentStub, 3.0)
                        .PostApi(ApiMiddleName.Codes, typeof(List<string>), typeof(TournamentCodeParameters), false)
                        .HasQueryParameters(new Dictionary<string, Type>()
                        {
                            {"count", typeof(int)},
                            {"tournamentId", typeof(int)}
                        })
                        .GetApi(ApiMiddleName.LobbyEvents, typeof(LobbyEventDTOWrapper), ApiParam.ByCode)
                        .PostApi(ApiMiddleName.Providers, typeof(int), typeof(ProviderRegistrationParameters), true)
                        .PostApi(ApiMiddleName.Tournaments, typeof(int), typeof(TournamentRegistrationParameters), true);

                    apis.AddApi(ApiName.Tournament, 3.0)
                        .PostApi(ApiMiddleName.Codes, typeof(List<string>), typeof(TournamentCodeParameters), true)
                        .HasQueryParameters(new Dictionary<string, Type>()
                        {
                            {"count", typeof(int)},
                            {"tournamentId", typeof(int)}
                        })
                        .PutApi(ApiMiddleName.Codes, typeof(TournamentCodeUpdateParameters), false, ApiParam.OnlyTournamentCode)
                        .GetApi(ApiMiddleName.Codes, typeof(TournamentCodeDTO), ApiParam.OnlyTournamentCode)
                        .GetApi(ApiMiddleName.LobbyEvents, typeof(LobbyEventDTOWrapper), ApiParam.ByCode)
                        .PostApi(ApiMiddleName.Providers, typeof(int), typeof(ProviderRegistrationParameters), true)
                        .PostApi(ApiMiddleName.Tournaments, typeof(int), typeof(TournamentRegistrationParameters), true);

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