using System;
using System.Collections.Generic;
using System.Text;
using RiotGamesApi.AspNetCore;
using RiotGamesApi.AspNetCore.Enums;

using RiotGamesApi.AspNetCore;
using RiotGamesApi.AspNetCore.Enums;

using RiotGamesApi.AspNetCore.RiotApi.Enums;
using RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Champion;
using Xunit;

namespace RiotGamesApi.Tests
{
    public class CHAMPION_V3 : BaseTestClass
    {
        [Fact]
        public void GetChampions1()
        {
            var rit = new ApiCall()
                .SelectApi<ChampionListDto>(ApiName.Platform)
                .For(ApiMiddleName.Champions)
                .AddParameter()
                .Build(Platform.TR1)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetChampionByOnlyId()
        {
            var rit = new ApiCall()
                .SelectApi<ChampionDto>(ApiName.Platform)
                .For(ApiMiddleName.Champions)
                .AddParameter(new RiotGamesApiParameter(ApiParam.OnlyId, championId1))
                .Build(Platform.TR1)
                .Get();
            Assert.False(rit.HasError);
        }
    }
}