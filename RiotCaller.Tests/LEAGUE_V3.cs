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
                .SelectApi<LeagueListDTO>(LolApiName.League)
                .For(LolApiMethodName.ChallengerLeagues)
                .AddParameter(new ApiParameter(LolApiPath.ByQueue, Queue.RANKED_SOLO_5x5))
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetLeagues()
        {
            var rit = new ApiCall()
                .SelectApi<List<LeagueListDTO>>(LolApiName.League)
                .For(LolApiMethodName.Leagues)
                .AddParameter(new ApiParameter(LolApiPath.BySummoner, SummonerId))
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetMasterLeagues()
        {
            var rit = new ApiCall()
                .SelectApi<LeagueListDTO>(LolApiName.League)
                .For(LolApiMethodName.MasterLeagues)
                .AddParameter(new ApiParameter(LolApiPath.ByQueue, Queue.RANKED_SOLO_5x5))
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetPositions()
        {
            var rit = new ApiCall()
                .SelectApi<List<LeaguePositionDTO>>(LolApiName.League)
                .For(LolApiMethodName.Positions)
                .AddParameter(new ApiParameter(LolApiPath.BySummoner, SummonerId))
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }
    }
}