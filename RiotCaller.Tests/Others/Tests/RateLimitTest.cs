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
        public void RateLimit1()//on debug mode
        {
            for (int i = 0; i < 205; i++)
            {
                IResult<SummonerDto> result =
                    LolApi.NonStaticApi.Summonerv3.GetSummonersOnlySummonerId(Service_Platform, SummonerId);
                //Assert.False(result.HasError);
            }
        }

        [Fact]
        public void RateLimit2()//on debug mode
        {
            ApiRate rt = ApiSettings.RateLimiter;

            int expected = 25;
            for (int i = 0; i < expected; i++)
            {
                rt.Handle(Service_Platform);
            }
            Assert.Equal(1, rt.RegionLimits.Count);
            Assert.Equal(expected, rt.RegionLimits[Service_Platform.ToString()].Limits.First().Counter);
        }

        [Fact]
        public void RateLimitByRegion()
        {
            ApiRate rt = ApiSettings.RateLimiter;

            int regionCount = 12;
            int rateCountPerRegion = 18;
            Task.Run(() =>
            {
                List<Task> ts = new List<Task>();
                for (int i = 1; i <= regionCount; i++)
                {
                    ServicePlatform spl = (ServicePlatform)i;
                    for (int j = 0; j < rateCountPerRegion; j++)
                    {
                        ts.Add(Task.Run(() =>
                        {
                            rt.Handle(spl);
                        }));
                        ts.Add(Task.Run(() =>
                        {
                            rt.Handle(spl);
                        }));
                    }
                }
                Task.WaitAll(ts.ToArray());
            }).Wait();

            int totalServicePlatform = rt.RegionLimits.Count(p => p.Value.Limits.First().Counter == rateCountPerRegion * 2);
            Assert.Equal(regionCount, totalServicePlatform);
        }

        [Fact]
        public void ApiRate2Test()
        {
            ApiRate2 apir = ApiSettings.RateL2;
            apir.Add(ServicePlatform.TR1.ToString(), LolUrlType.NonStatic, new List<LolApiName>()
            {
                LolApiName.Match
            }, new List<ApiLimit>()
            {
                new ApiLimit(new TimeSpan(0,0,1),20),

                new ApiLimit(new TimeSpan(0,2,0),200)
            });

            apir.Add(ServicePlatform.NA1.ToString(), LolUrlType.NonStatic, new List<LolApiName>()
                {
                    LolApiName.Match
                },
                new List<ApiLimit>()
                {
                    new ApiLimit(new TimeSpan(0,0,1),20),

                    new ApiLimit(new TimeSpan(0,2,0),200)
                });

            int rateCountPerRegion = 25;
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
                }

                Task.WaitAll(ts.ToArray());
            }).Wait();

            //int totalServicePlatform = apir.RegionLimits.Count(p => p.Value.Limits.First().Counter == rateCountPerRegion * 2);
            //Assert.Equal(regionCount, totalServicePlatform);
        }
    }
}