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
                .SelectApi<List<ChampionMasteryDto>>(LolApiName.ChampionMastery)
                .For(LolApiMethodName.ChampionMasteries)
                .AddParameter(new ApiParameter(LolApiPath.BySummoner, SummonerId))
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetChampionMastery()
        {
            var rit = new ApiCall()
                .SelectApi<ChampionMasteryDto>(LolApiName.ChampionMastery)
                .For(LolApiMethodName.ChampionMasteries)
                .AddParameter(new ApiParameter(LolApiPath.BySummoner, SummonerId),
                               new ApiParameter(LolApiPath.ByChampion, ChampionId))
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetChampionScore()
        {
            var rit = new ApiCall()
                .SelectApi<int>(LolApiName.ChampionMastery)
                .For(LolApiMethodName.Scores)
                .AddParameter(new ApiParameter(LolApiPath.BySummoner, SummonerId))
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }
    }
}