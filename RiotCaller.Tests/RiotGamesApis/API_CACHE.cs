using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.Models;
using RiotGamesApi.AspNetCore.RiotApi.Enums;
using RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Summoner;
using RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Champions;
using RiotGamesApi.Tests.Others;
using Xunit;

namespace RiotGamesApi.Tests.RiotGamesApis
{
    public class API_CACHE : BaseTestClass
    {
        [Fact]
        public void CacheStaticApi()
        {
            var rit = new ApiCall()
                .SelectApi<ChampionListDto>(LolApiName.StaticData)
                .For(LolApiMethodName.Champions)
                .AddParameter()
                .Build(Service_Platform)
                .UseCache(true)
                .Get();
            Assert.False(rit.HasError);
            Assert.False(rit.IsCache);

            rit = new ApiCall()
                .SelectApi<ChampionListDto>(LolApiName.StaticData)
                .For(LolApiMethodName.Champions)
                .AddParameter()
                .Build(Service_Platform)
                .UseCache(true)
                .Get();
            Assert.False(rit.HasError);
            Assert.True(rit.IsCache);
        }

        [Fact]
        public void CacheNonStaticApi()
        {
            var rit = LolApi.NonStaticApi.Summonerv3
                .GetSummonersByAccount(ServicePlatform.EUW1, AccountId);
            Assert.False(rit.HasError);
            Assert.False(rit.IsCache);

            rit = LolApi.NonStaticApi.Summonerv3
                .GetSummonersByAccount(ServicePlatform.EUW1, AccountId);
            Assert.False(rit.HasError);
            Assert.True(rit.IsCache);
        }
    }
}