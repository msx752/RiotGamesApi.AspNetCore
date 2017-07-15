using RiotGamesApi.AspNetCore;
using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.Models;
using RiotGamesApi.AspNetCore.RiotApi.Enums;
using RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.ChampionMastery;
using System.Collections.Generic;
using Xunit;

namespace RiotGamesApi.Tests
{
    public class CHAMPION_MASTERY_V3 : BaseTestClass
    {
        [Fact]
        public void GetChampionMasteries()
        {
            var rit = new ApiCall()
                .SelectApi<List<ChampionMasteryDto>>(ApiName.ChampionMastery)
                .For(ApiMiddleName.ChampionMasteries)
                .AddParameter(new ApiParameter(ApiParam.BySummoner, SummonerId))
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetChampionMastery()
        {
            var rit = new ApiCall()
                .SelectApi<ChampionMasteryDto>(ApiName.ChampionMastery)
                .For(ApiMiddleName.ChampionMasteries)
                .AddParameter(new ApiParameter(ApiParam.BySummoner, SummonerId),
                               new ApiParameter(ApiParam.ByChampion, ChampionId))
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetChampionScore()
        {
            var rit = new ApiCall()
                .SelectApi<int>(ApiName.ChampionMastery)
                .For(ApiMiddleName.Scores)
                .AddParameter(new ApiParameter(ApiParam.BySummoner, SummonerId))
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }
    }
}