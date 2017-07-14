using System;
using System.Collections.Generic;
using System.Text;
using RiotGamesApi.AspNetCore;
using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Mastery;
using RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Match;

using RiotGamesApi.AspNetCore;
using RiotGamesApi.AspNetCore.Enums;

using RiotGamesApi.AspNetCore.Models;
using RiotGamesApi.AspNetCore.RiotApi.Enums;
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
                .For(ApiMiddleName.Matches)
                .AddParameter(new RiotGamesApiParameter(ApiParam.OnlyMatchId, (long)1))//not tested
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
                .For(ApiMiddleName.MatchLists)
                .AddParameter(new RiotGamesApiParameter(ApiParam.ByAccount, AccountId))
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
                .For(ApiMiddleName.MatchLists)
                .AddParameter(new RiotGamesApiParameter(ApiParam.ByAccountRecent, AccountId))//not tested
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetMatchesByMatch()
        {
            var rit = new ApiCall()
                .SelectApi<MatchTimelineDto>(ApiName.Match)
                .For(ApiMiddleName.Timelines)
                .AddParameter(new RiotGamesApiParameter(ApiParam.ByMatch, (long)1))//not tested
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
                .For(ApiMiddleName.Matches)
                .AddParameter(new RiotGamesApiParameter(ApiParam.ByTournamentCodeIds, "code"))//not tested
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetMatchesByTornamentCode()
        {
            var rit = new ApiCall()
                .SelectApi<MatchDto>(ApiName.Match)
                .For(ApiMiddleName.Matches)
                .AddParameter(
                    new RiotGamesApiParameter(ApiParam.OnlyMatchId, (long)1),
                    new RiotGamesApiParameter(ApiParam.ByTournamentCode, "code"))//not tested
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }
    }
}