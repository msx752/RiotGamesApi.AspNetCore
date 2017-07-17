using RiotGamesApi.AspNetCore;

using RiotGamesApi.AspNetCore;

using RiotGamesApi.AspNetCore.Enums;

using RiotGamesApi.AspNetCore.Enums;

using RiotGamesApi.AspNetCore.Models;
using RiotGamesApi.AspNetCore.RiotApi.Enums;
using RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Champion;
using RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RiotGamesApi.Tests
{
    public class LEAGUE_V3 : BaseTestClass
    {
        [Fact]
        public void GetChallengerLeagues()
        {
            var rit = new ApiCall()
                .SelectApi<LeagueListDTO>(ApiName.League)
                .For(ApiMethodName.ChallengerLeagues)
                .AddParameter(new ApiParameter(ApiPath.ByQueue, Queue.RANKED_SOLO_5x5))
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetLeagues()
        {
            var rit = new ApiCall()
                .SelectApi<List<LeagueListDTO>>(ApiName.League)
                .For(ApiMethodName.Leagues)
                .AddParameter(new ApiParameter(ApiPath.BySummoner, SummonerId))
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetMasterLeagues()
        {
            var rit = new ApiCall()
                .SelectApi<LeagueListDTO>(ApiName.League)
                .For(ApiMethodName.MasterLeagues)
                .AddParameter(new ApiParameter(ApiPath.ByQueue, Queue.RANKED_SOLO_5x5))
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetPositions()
        {
            var rit = new ApiCall()
                .SelectApi<List<LeaguePositionDTO>>(ApiName.League)
                .For(ApiMethodName.Positions)
                .AddParameter(new ApiParameter(ApiPath.BySummoner, SummonerId))
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }
    }
}