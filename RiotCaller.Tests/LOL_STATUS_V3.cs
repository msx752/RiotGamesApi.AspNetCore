﻿using System;
using System.Collections.Generic;
using System.Text;
using RiotGamesApi.AspNetCore;
using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.ChampionMastery;

using RiotGamesApi.AspNetCore;
using RiotGamesApi.AspNetCore.Enums;

using RiotGamesApi.AspNetCore.Models;
using RiotGamesApi.AspNetCore.RiotApi.Enums;
using RiotGamesApi.AspNetCore.RiotApi.StatusEndPoints;
using Xunit;

namespace RiotGamesApi.Tests
{
    public class LOL_STATUS_V3 : BaseTestClass
    {
        [Fact]
        public void GetStatus()
        {
            var rit = new ApiCall()
                .SelectApi<ShardStatus>(ApiName.Status)
                .For(ApiMiddleName.ShardData)
                .AddParameter()
                .Build(Platform.TR1)
                .Get();
            Assert.False(rit.HasError);
        }
    }
}