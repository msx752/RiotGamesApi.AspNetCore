﻿using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.Models;
using RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Summoner;
using RiotGamesApi.Tests.Others;
using Xunit;

namespace RiotGamesApi.Tests.RiotGamesApis
{
    public class SUMMONER_V3 : BaseTestClass
    {
        [Fact]
        public void GetSummonerByAccId()
        {
            var rit = new ApiCall()
                .SelectApi<SummonerDto>(LolApiName.Summoner)
                .For(LolApiMethodName.Summoners)
                .AddParameter(new ApiParameter(LolApiPath.ByAccount, AccountId))
                .Build(Service_Platform)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetSummonerBySumName()
        {
            var rit = new ApiCall()
                .SelectApi<SummonerDto>(LolApiName.Summoner)
                .For(LolApiMethodName.Summoners)
                .AddParameter(new ApiParameter(LolApiPath.ByName, SummonerName))
                .Build(Service_Platform)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetSummonerByIdOnly()
        {
            var rit = new ApiCall()
                .SelectApi<SummonerDto>(LolApiName.Summoner)
                .For(LolApiMethodName.Summoners)
                .AddParameter(new ApiParameter(LolApiPath.OnlySummonerId, SummonerId))
                .Build(Service_Platform)
                .Get();
            Assert.False(rit.HasError);
        }
    }
}