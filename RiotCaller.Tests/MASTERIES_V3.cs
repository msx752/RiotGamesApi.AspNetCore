using RiotGamesApi.AspNetCore;

using RiotGamesApi.AspNetCore;

using RiotGamesApi.AspNetCore.Enums;

using RiotGamesApi.AspNetCore.Enums;

using RiotGamesApi.AspNetCore.Models;
using RiotGamesApi.AspNetCore.RiotApi.Enums;
using RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League;
using RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Mastery;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RiotGamesApi.Tests
{
    public class MASTERIES_V3 : BaseTestClass
    {
        [Fact]
        public void GetMasteriesBySumId()
        {
            var rit = new ApiCall()
                .SelectApi<MasteryPagesDto>(ApiName.Platform)
                .For(ApiMiddleName.Masteries)
                .AddParameter(new ApiParameter(ApiParam.BySummoner, SummonerId1))
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }
    }
}