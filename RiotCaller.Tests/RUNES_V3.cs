using RiotGamesApi.AspNetCore;

using RiotGamesApi.AspNetCore;

using RiotGamesApi.AspNetCore.Enums;

using RiotGamesApi.AspNetCore.Enums;

using RiotGamesApi.AspNetCore.Models;
using RiotGamesApi.AspNetCore.RiotApi.Enums;
using RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League;
using RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Rune;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RiotGamesApi.Tests
{
    public class RUNES_V3 : BaseTestClass
    {
        [Fact]
        public void GetRunesBySummoner()
        {
            var rit = new ApiCall()
                .SelectApi<RunePagesDto>(LolApiName.Platform)
                .For(LolApiMethodName.Runes)
                .AddParameter(new ApiParameter(LolApiPath.BySummoner, SummonerId))
                .Build(ServicePlatform)
                .Get();
            Assert.False(rit.HasError);
        }
    }
}