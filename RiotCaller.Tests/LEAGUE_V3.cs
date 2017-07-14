using System;
using System.Collections.Generic;
using System.Text;
using RiotGamesApi.AspNetCore;
using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Champion;
using RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League;

using RiotGamesApi.AspNetCore;
using RiotGamesApi.AspNetCore.Enums;

using RiotGamesApi.AspNetCore.Models;
using RiotGamesApi.AspNetCore.RiotApi.Enums;
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
                .For(ApiMiddleName.ChallengerLeagues)
                .AddParameter(new RiotGamesApiParameter(ApiParam.ByQueue, Queue.RANKED_SOLO_5x5))
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetLeagues()
        {
            var rit = new ApiCall()
                .SelectApi<List<LeagueListDTO>>(ApiName.League)
                .For(ApiMiddleName.Leagues)
                .AddParameter(new RiotGamesApiParameter(ApiParam.BySummoner, SummonerId1))
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetMasterLeagues()
        {
            var rit = new ApiCall()
                .SelectApi<LeagueListDTO>(ApiName.League)
                .For(ApiMiddleName.MasterLeagues)
                .AddParameter(new RiotGamesApiParameter(ApiParam.ByQueue, Queue.RANKED_SOLO_5x5))
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetPositions()
        {
            var rit = new ApiCall()
                .SelectApi<List<LeaguePositionDTO>>(ApiName.League)
                .For(ApiMiddleName.Positions)
                .AddParameter(new RiotGamesApiParameter(ApiParam.BySummoner, SummonerId1))
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }
    }
}