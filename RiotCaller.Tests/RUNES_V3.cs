using System;
using System.Collections.Generic;
using System.Text;
using RiotGamesApi.AspNetCore;
using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League;
using RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Rune;

using RiotGamesApi.AspNetCore;
using RiotGamesApi.AspNetCore.Enums;

using RiotGamesApi.AspNetCore.RiotApi.Enums;
using Xunit;

namespace RiotGamesApi.Tests
{
    public class RUNES_V3 : BaseTestClass
    {
        [Fact]
        public void GetRunesBySummoner()
        {
            var rit = new ApiCall()
                .SelectApi<RunePagesDto>(ApiName.Platform)
                .For(ApiMiddleName.Runes)
                .AddParameter(new RiotGamesApiParameter(ApiParam.BySummoner, summonerId1))
                .Build(Platform.TR1)
                .Get();
            Assert.False(rit.HasError);
        }
    }
}