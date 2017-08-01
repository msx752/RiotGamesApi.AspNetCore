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
        public void DebugRespecToRegionLimits()//run with DebugMode
        {
            for (int i = 0; i < 1000; i++)
            {
                LolApi.NonStaticApi.Summonerv3
                    .GetSummonersOnlySummonerId(ServicePlatform.EUW1, SummonerId);
            }
        }

        [Fact]
        public void RegionalApiLimitTesting()
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
                            Platform = ServicePlatform.EUW1.ToString(),
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
            var tr1 = ApiRateLimiting.Rates.Find(ServicePlatform.EUW1.ToString(), LolUrlType.NonStatic, LolApiName.Match);
            var c2 = tr1.Limits.First().Counter;

            Assert.Equal(c1, c2 * 2);
            var sn = ApiRateLimiting.FindRate(Service_Platform.ToString(), LolUrlType.NonStatic, LolApiName.Match);
            Assert.Equal(3, sn.Limits.Count(p => p.Counter == rateCountPerRegion));//there are app,service and method rate limits
        }
    }
}