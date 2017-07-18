using RiotGamesApi.AspNetCore;

using RiotGamesApi.AspNetCore;

using RiotGamesApi.AspNetCore.Enums;

using RiotGamesApi.AspNetCore.Enums;

using RiotGamesApi.AspNetCore.Models;
using RiotGamesApi.AspNetCore.RiotApi.Enums;
using RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Champion;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RiotGamesApi.Tests
{
    public class CHAMPION_V3 : BaseTestClass
    {
        [Fact]
        public void GetChampions1()
        {
            var rit = new ApiCall()
                .SelectApi<ChampionListDto>(LolApiName.Platform)
                .For(LolApiMethodName.Champions)
                .AddParameter()
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetChampionByOnlyId()
        {
            var rit = new ApiCall()
                .SelectApi<ChampionDto>(LolApiName.Platform)
                .For(LolApiMethodName.Champions)
                .AddParameter(new ApiParameter(LolApiPath.OnlyId, ChampionId))
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }
    }
}