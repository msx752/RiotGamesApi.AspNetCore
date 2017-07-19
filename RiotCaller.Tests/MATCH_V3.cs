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
                .SelectApi<MatchDto>(LolApiName.Match)
                .For(LolApiMethodName.Matches)
                .AddParameter(new ApiParameter(LolApiPath.OnlyMatchId, MatchId))//not tested
                .Build(ServicePlatform)
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
                .SelectApi<MatchlistDto>(LolApiName.Match)
                .For(LolApiMethodName.MatchLists)
                .AddParameter(new ApiParameter(LolApiPath.ByAccount, AccountId))
                .Build(ServicePlatform)
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
                .SelectApi<MatchlistDto>(LolApiName.Match)
                .For(LolApiMethodName.MatchLists)
                .AddParameter(new ApiParameter(LolApiPath.ByAccountRecent, AccountId))//not tested
                .Build(ServicePlatform)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetMatchesByMatch()
        {
            var rit = new ApiCall()
                .SelectApi<MatchTimelineDto>(LolApiName.Match)
                .For(LolApiMethodName.Timelines)
                .AddParameter(new ApiParameter(LolApiPath.ByMatch, MatchId))//not tested
                .Build(ServicePlatform)
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
                .SelectApi<List<long>>(LolApiName.Match)
                .For(LolApiMethodName.Matches)
                .AddParameter(new ApiParameter(LolApiPath.ByTournamentCodeIds, TournamentCode))//not tested
                .Build(ServicePlatform)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetMatchesByTornamentCode()
        {
            var rit = new ApiCall()
                .SelectApi<MatchDto>(LolApiName.Match)
                .For(LolApiMethodName.Matches)
                .AddParameter(
                    new ApiParameter(LolApiPath.OnlyMatchId, MatchId),
                    new ApiParameter(LolApiPath.ByTournamentCode, TournamentCode))//not tested
                .Build(ServicePlatform)
                .Get();
            Assert.False(rit.HasError);
        }
    }
}