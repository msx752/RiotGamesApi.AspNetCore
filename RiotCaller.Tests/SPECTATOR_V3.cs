using RiotGamesApi.AspNetCore;

using RiotGamesApi.AspNetCore;

using RiotGamesApi.AspNetCore.Enums;

using RiotGamesApi.AspNetCore.Enums;

using RiotGamesApi.AspNetCore.Models;
using RiotGamesApi.AspNetCore.RiotApi.Enums;
using RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Champion;
using RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Spectator;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RiotGamesApi.Tests
{
    public class SPECTATOR_V3 : BaseTestClass
    {
        [Fact]
        public void GetActiveGamesBySummoner()
        {
            var rit = new ApiCall()
                .SelectApi<CurrentGameInfo>(LolApiName.Spectator)
                .For(LolApiMethodName.ActiveGames)
                .AddParameter(new ApiParameter(LolApiPath.BySummoner, SummonerId))
                .Build(PlatformType)
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
                .SelectApi<FeaturedGames>(LolApiName.Spectator)
                .For(LolApiMethodName.FeaturedGames)
                .AddParameter()
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }
    }
}