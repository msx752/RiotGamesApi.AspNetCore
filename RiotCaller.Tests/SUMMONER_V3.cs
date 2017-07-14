using RiotGamesApi.AspNetCore;
using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.RiotApi.Enums;
using RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Summoner;
using Xunit;

namespace RiotGamesApi.Tests
{
    public class SUMMONER_V3 : BaseTestClass
    {
        [Fact]
        public void GetSummonerByAccId()
        {
            var rit = new ApiCall()
                .SelectApi<SummonerDto>(ApiName.Summoner)
                .For(ApiMiddleName.Summoners)
                .AddParameter(new RiotGamesApiParameter(ApiParam.ByAccount, accountId))
                .Build(Platform.TR1)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetSummonerBySumName()
        {
            var rit = new ApiCall()
                .SelectApi<SummonerDto>(ApiName.Summoner)
                .For(ApiMiddleName.Summoners)
                .AddParameter(new RiotGamesApiParameter(ApiParam.ByName, summonerName1))
                .Build(Platform.TR1)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetSummonerByIdOnly()
        {
            var rit = new ApiCall()
                .SelectApi<SummonerDto>(ApiName.Summoner)
                .For(ApiMiddleName.Summoners)
                .AddParameter(new RiotGamesApiParameter(ApiParam.OnlySummonerId, summonerId1))
                .Build(Platform.TR1)
                .Get();
            Assert.False(rit.HasError);
        }
    }
}