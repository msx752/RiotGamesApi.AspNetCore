using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RiotGamesApi.AspNetCore.Interfaces;
using RiotGamesApi.AspNetCore.Models;
using RiotGamesApi.AspNetCore.RateLimit;
using RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Champions;
using Xunit;

namespace RiotGamesApi.Tests.Others
{
    public class RateLimitTest : BaseTestClass
    {
        [Fact]
        public void RateLimiting()//on debug mode
        {
            for (int i = 0; i < 205; i++)
            {
                IResult<ChampionDto> result =
                    LolApi.StaticApi.StaticDatav3.GetChampionsOnlyId(AspNetCore.RiotApi.Enums.ServicePlatform.TR1, 45, true);
                Assert.False(result.HasError);
            }
        }

        [Fact]
        public void RateLimit2()//on debug mode
        {
            ApiRate rt = new ApiRate();
            for (int i = 0; i < 205; i++)
            {
                Task.Run(() =>
                {
                    rt.Handle();
                });
            }
            Console.ReadLine();
        }
    }
}