using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RiotGamesApi.AspNetCore;
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

            for (int i = 0; i < 205; i++)
            {
                rt.Handle(Service_Platform);
            }
            Assert.Equal(1, rt.RegionLimits.Count);
        }

        [Fact]
        public void RateLimitByRegion()//on debug mode
        {
            ApiRate rt = ApiSettings.RateLimiter;

            rt.Handle(Service_Platform);
            Assert.Equal(1, rt.RegionLimits[Service_Platform.ToString()].First().Counter);

            rt.Handle(ServicePlatform.NA1);
            rt.Handle(ServicePlatform.NA1);
            Assert.Equal(2, rt.RegionLimits[ServicePlatform.NA1.ToString()].First().Counter);

            rt.Handle(PhysicalRegion.americas);
            Assert.Equal(1, rt.RegionLimits[PhysicalRegion.americas.ToString()].First().Counter);
        }
    }
}