using System;
using System.Collections.Generic;
using System.Text;
using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.Models;
using RiotGamesApi.AspNetCore.RiotApi.Enums;
using RiotGamesApi.AspNetCore.RiotApi.TournamentEndPoints;
using Xunit;
using LobbyEventDTOWrapper = RiotGamesApi.AspNetCore.RiotApi.TournamentStubEndPoints.LobbyEventDTOWrapper;
using TournamentCodeParameters = RiotGamesApi.AspNetCore.RiotApi.TournamentStubEndPoints.TournamentCodeParameters;

namespace RiotGamesApi.Tests
{
    public class TOURNAMENT_STUB_V3 : BaseTestClass
    {
        [Fact]
        public void GetLobbyEvents()//NOT TESTED
        {
            var rit = new ApiCall()
                .SelectApi<LobbyEventDTOWrapper>(LolApiName.TournamentStub)
                .For(LolApiMethodName.LobbyEvents)
                .AddParameter(new ApiParameter(LolApiPath.ByCode, TournamentCode))
                .Build(PhysicalRegion.americas)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void PostCodes()//NOT TESTED
        {
            var rit = new ApiCall()
                .SelectApi<List<string>>(LolApiName.TournamentStub)
                .For(LolApiMethodName.Codes)
                .AddParameter()
                .Build(PhysicalRegion.americas)
                .Post(new Dictionary<string, string>()
                {
                    {"count","1"},
                    {"tournamentId", "1"}
                }, new TournamentCodeParameters() { });
            Assert.False(rit.HasError);
        }

        [Fact]
        public void PostProviders()//NOT TESTED
        {
            var rit = new ApiCall()
             .SelectApi<int>(LolApiName.TournamentStub)
             .For(LolApiMethodName.Providers)
             .AddParameter()
             .Build(PhysicalRegion.americas)
             .Post(new ProviderRegistrationParameters() { });
            Assert.False(rit.HasError);
        }

        [Fact]
        public void PostTournaments()//NOT TESTED
        {
            var rit = new ApiCall()
                .SelectApi<int>(LolApiName.TournamentStub)
                .For(LolApiMethodName.Tournaments)
                .AddParameter()
                .Build(PhysicalRegion.americas)
                .Post(new TournamentRegistrationParameters() { });
            Assert.False(rit.HasError);
        }
    }
}