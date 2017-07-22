using System;
using RiotGamesApi.AspNetCore.Interfaces;
using RiotGamesApi.AspNetCore.Models;
using RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Champions;
using Xunit;

namespace RiotGamesApi.Tests.Others
{
    public class RateLimiter : BaseTestClass
    {
        [Fact]
        public void RateLimiting()//testing
        {
            for (int i = 0; i < 10; i++)
            {
                IResult<ChampionDto> result =
                    LolApi.StaticApi.StaticDatav3.GetChampionsOnlyId(AspNetCore.RiotApi.Enums.ServicePlatform.TR1, 45);
                Assert.False(result.HasError);
            }
            Assert.Throws(typeof(RiotGamesApiException), () =>
            {
                IResult<ChampionDto> result =
                    LolApi.StaticApi.StaticDatav3
                        .GetChampionsOnlyId(AspNetCore.RiotApi.Enums.ServicePlatform.TR1, 45);
                Assert.False(result.HasError); //429
                //throw result.Exception;
            });
        }
    }
}