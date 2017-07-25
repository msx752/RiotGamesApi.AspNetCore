using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.RateLimit;
using RiotGamesApi.AspNetCore.RiotApi.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RiotGamesApi.AspNetCore.RateLimit.Property;
using Xunit;

namespace RiotGamesApi.Tests.Others.Tests
{
    public class RateLimitTest : BaseTestClass
    {
        [Fact]
        public void RespecToRegionLimits()
        {
            for (int i = 0; i < 1000; i++)
            {
                var snc = LolApi.NonStaticApi.Summonerv3.GetSummonersOnlySummonerId(ServicePlatform.TR1, SummonerId);
            }
        }

        [Fact]
        public void RegionalApiLimit()
        {
            int rateCountPerRegion = 15;
            Task.Run(() =>
            {
                List<Task> ts = new List<Task>();

                for (int j = 0; j < rateCountPerRegion; j++)
                {
                    ts.Add(Task.Run(() =>
                    {
                        ApiRateLimiting.Handle(new RateLimitProperties()
                        {
                            Platform = ServicePlatform.TR1.ToString(),
                            ApiName = LolApiName.Match,
                            UrlType = LolUrlType.NonStatic
                        });
                    }));

                    ts.Add(Task.Run(() =>
                    {
                        ApiRateLimiting.Handle(new RateLimitProperties()
                        {
                            Platform = ServicePlatform.NA1.ToString(),
                            ApiName = LolApiName.Match,
                            UrlType = LolUrlType.NonStatic
                        });
                    }));
                    ts.Add(Task.Run(() =>
                    {
                        ApiRateLimiting.Handle(new RateLimitProperties()
                        {
                            Platform = ServicePlatform.NA1.ToString(),
                            ApiName = LolApiName.Match,
                            UrlType = LolUrlType.NonStatic
                        });
                    }));
                }

                Task.WaitAll(ts.ToArray());
            }).Wait();

            var na1 = ApiRateLimiting.Rates.Find(ServicePlatform.NA1.ToString(), LolUrlType.NonStatic, LolApiName.Match);
            var c1 = na1.Limits.First().Counter;
            var tr1 = ApiRateLimiting.Rates.Find(ServicePlatform.TR1.ToString(), LolUrlType.NonStatic, LolApiName.Match);
            var c2 = tr1.Limits.First().Counter;

            Assert.Equal(c1, c2 * 2);
            var sn = ApiRateLimiting.FindRate(Service_Platform.ToString(), LolUrlType.NonStatic, LolApiName.Match);
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