using System;
using System.Collections.Generic;
using System.Text;
using RiotGamesApi.AspNetCore;
using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Champion;
using RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Spectator;

using RiotGamesApi.AspNetCore;
using RiotGamesApi.AspNetCore.Enums;

using RiotGamesApi.AspNetCore.Models;
using RiotGamesApi.AspNetCore.RiotApi.Enums;
using Xunit;

namespace RiotGamesApi.Tests
{
    public class SPECTATOR_V3 : BaseTestClass
    {
        [Fact]
        public void GetActiveGamesBySummoner()
        {
            var rit = new ApiCall()
                .SelectApi<CurrentGameInfo>(ApiName.Spectator)
                .For(ApiMiddleName.ActiveGames)
                .AddParameter(new RiotGamesApiParameter(ApiParam.BySummoner, summonerId1))
                .Build(Platform.TR1)
                .Get();
            if (rit.HasError)
                Assert.Equal("Data not found:404", rit.Exception.Message);
            else
                Assert.False(rit.HasError);
        }

        [Fact]
        public void GetFeaturedGames()
        {
            var rit = new ApiCall()
                .SelectApi<FeaturedGames>(ApiName.Spectator)
                .For(ApiMiddleName.FeaturedGames)
                .AddParameter()
                .Build(Platform.TR1)
                .Get();
            Assert.False(rit.HasError);
        }
    }
}