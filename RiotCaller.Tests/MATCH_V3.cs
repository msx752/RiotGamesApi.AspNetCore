using RiotGamesApi.AspNetCore;

using RiotGamesApi.AspNetCore;

using RiotGamesApi.AspNetCore.Enums;

using RiotGamesApi.AspNetCore.Enums;

using RiotGamesApi.AspNetCore.Models;
using RiotGamesApi.AspNetCore.RiotApi.Enums;
using RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Mastery;
using RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Match;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RiotGamesApi.Tests
{
    public class MATCH_V3 : BaseTestClass
    {
        [Fact]
        public void GetMatchesByOnlyMatchId()
        {
            var rit = new ApiCall()
                .SelectApi<MatchDto>(ApiName.Match)
                .For(ApiMethodName.Matches)
                .AddParameter(new ApiParameter(ApiPath.OnlyMatchId, MatchId))//not tested
                .Build(PlatformType)
                .Get();
            if (rit.HasError)
                Assert.Equal("Data not found:404", rit.Exception.Message);
            else
                Assert.False(rit.HasError);
        }

        [Fact]
        public void GetMatchesByAccount()
        {
            var rit = new ApiCall()
                .SelectApi<MatchlistDto>(ApiName.Match)
                .For(ApiMethodName.MatchLists)
                .AddParameter(new ApiParameter(ApiPath.ByAccount, AccountId))
                .Build(PlatformType)
                .Get(/*
                it has optional parameters
                https://developer.riotgames.com/api-methods/#match-v3/GET_getMatchlist
                */);
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetMatchesByAccountRecent()
        {
            var rit = new ApiCall()
                .SelectApi<MatchlistDto>(ApiName.Match)
                .For(ApiMethodName.MatchLists)
                .AddParameter(new ApiParameter(ApiPath.ByAccountRecent, AccountId))//not tested
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetMatchesByMatch()
        {
            var rit = new ApiCall()
                .SelectApi<MatchTimelineDto>(ApiName.Match)
                .For(ApiMethodName.Timelines)
                .AddParameter(new ApiParameter(ApiPath.ByMatch, MatchId))//not tested
                .Build(PlatformType)
                .Get();
            if (rit.HasError)
                Assert.Equal("Data not found:404", rit.Exception.Message);
            else
                Assert.False(rit.HasError);
        }

        [Fact]
        public void GetMatchesByTornamentCodeIds()
        {
            var rit = new ApiCall()
                .SelectApi<List<long>>(ApiName.Match)
                .For(ApiMethodName.Matches)
                .AddParameter(new ApiParameter(ApiPath.ByTournamentCodeIds, TournamentCode))//not tested
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetMatchesByTornamentCode()
        {
            var rit = new ApiCall()
                .SelectApi<MatchDto>(ApiName.Match)
                .For(ApiMethodName.Matches)
                .AddParameter(
                    new ApiParameter(ApiPath.OnlyMatchId, MatchId),
                    new ApiParameter(ApiPath.ByTournamentCode, TournamentCode))//not tested
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }
    }
}