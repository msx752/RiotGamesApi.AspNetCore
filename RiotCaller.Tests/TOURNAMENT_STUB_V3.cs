using System;
using System.Collections.Generic;
using System.Text;
using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.Models;
using RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.ChampionMastery;
using RiotGamesApi.AspNetCore.RiotApi.TournamentStubEndPoints;
using Xunit;

namespace RiotGamesApi.Tests
{
    public class TOURNAMENT_STUB_V3 : BaseTestClass
    {
        [Fact]
        public void GetLobbyEvents()
        {
            var rit = new ApiCall()
                .SelectApi<LobbyEventDTOWrapper>(ApiName.TournamentStub)
                .For(ApiMethodName.Codes)
                .AddParameter()
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }
    }
}