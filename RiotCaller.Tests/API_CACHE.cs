using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Caching.Memory;
using RiotGamesApi.AspNetCore;
using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.Models;
using RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Champions;
using RiotGamesApi.AspNetCore.RiotApi.StatusEndPoints;
using Xunit;

namespace RiotGamesApi.Tests
{
    public class API_CACHE : BaseTestClass
    {
        [Fact]
        public void Caching1()
        {
            var rit = new ApiCall()
                .SelectApi<ChampionListDto>(LolApiName.StaticData)
                .For(LolApiMethodName.Champions)
                .AddParameter()
                .Build(PlatformType)
                .UseCache(true)
                .Get();
            Assert.False(rit.HasError);
            Assert.False(rit.IsCache);

            rit = new ApiCall()
                .SelectApi<ChampionListDto>(LolApiName.StaticData)
                .For(LolApiMethodName.Champions)
                .AddParameter()
                .Build(PlatformType)
                .UseCache(true)
                .Get();
            Assert.False(rit.HasError);
            Assert.True(rit.IsCache);
        }
    }
}