using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.Models;
using RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Champion;
using RiotGamesApi.Tests.Others;
using Xunit;

namespace RiotGamesApi.Tests.RiotGamesApis
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
                .Build(ServicePlatform)
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
                .Build(ServicePlatform)
                .Get();
            Assert.False(rit.HasError);
        }
    }
}