using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RiotGamesApi.AspNetCore;
using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.Interfaces;
using RiotGamesApi.AspNetCore.Models;
using RiotGamesApi.AspNetCore.RateLimit;
using RiotGamesApi.AspNetCore.RiotApi.Enums;
using RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Summoner;
using RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Champions;
using Xunit;

namespace RiotGamesApi.Tests.Others
{
    public class RateLimitTest : BaseTestClass
    {
        [Fact]
        public void ApiRate2Test()
        {
            ApiRate2 apir = ApiSettings.RateL2;

            int rateCountPerRegion = 5;
            Task.Run(() =>
            {
                List<Task> ts = new List<Task>();

                for (int j = 0; j < rateCountPerRegion; j++)
                {
                    ts.Add(Task.Run(() =>
                    {
                        apir.Handle(new RateLimitProperties()
                        {
                            Platform = ServicePlatform.TR1.ToString(),
                            ApiName = LolApiName.Match,
                            UrlType = LolUrlType.NonStatic
                        });
                    }));

                    ts.Add(Task.Run(() =>
                    {
                        apir.Handle(new RateLimitProperties()
                        {
                            Platform = ServicePlatform.NA1.ToString(),
                            ApiName = LolApiName.Match,
                            UrlType = LolUrlType.NonStatic
                        });
                    }));
                    ts.Add(Task.Run(() =>
                    {
                        apir.Handle(new RateLimitProperties()
                        {
                            Platform = ServicePlatform.NA1.ToString(),
                            ApiName = LolApiName.Match,
                            UrlType = LolUrlType.NonStatic
                        });
                    }));
                }

                Task.WaitAll(ts.ToArray());
            }).Wait();

            var na1 = apir.Rates.Find(ServicePlatform.NA1.ToString(), LolUrlType.NonStatic, LolApiName.Match);
            var c1 = na1.Limits.First().Counter;
            var tr1 = apir.Rates.Find(ServicePlatform.TR1.ToString(), LolUrlType.NonStatic, LolApiName.Match);
            var c2 = tr1.Limits.First().Counter;

            Assert.Equal(c1, rateCountPerRegion * 2);
            var sn = ApiSettings.RateL2.FindRate(Service_Platform.ToString(), LolUrlType.NonStatic, LolApiName.Match);
            Assert.Equal(3, sn.Limits.Count(p => p.Counter == rateCountPerRegion));//there are app,service and method rate limits
        }

        //[Fact]
        //public void XRateLimit()
        //{
        //    LolApi.NonStaticApi.ChampionMasteryv3.GetChampionMasteriesBySummoner(ServicePlatform.TR1, SummonerId);

        // LolApi.NonStaticApi.Leaguev3.GetChallengerLeaguesByQueue(ServicePlatform.TR1, AspNetCore.RiotApi.Enums.GameConstants.MatchMakingQueue.RANKED_FLEX_SR);

        // LolApi.NonStaticApi.Matchv3.GetMatchesOnlyMatchId(ServicePlatform.TR1, MatchId);

        // LolApi.NonStaticApi.Platformv3.GetChampionsOnlyId(ServicePlatform.TR1, 45);

        // LolApi.NonStaticApi.Summonerv3.GetSummonersByAccount(ServicePlatform.TR1, AccountId);

        // LolApi.StaticApi.StaticDatav3.GetChampionsOnlyId(ServicePlatform.TR1, 45);

        //    LolApi.StatusApi.Statusv3.GetShardData(ServicePlatform.TR1);
        //}
    }
}