using System;
using System.Collections.Generic;
using System.Text;
using RiotGamesApi.AspNetCore;
using RiotGamesApi.AspNetCore.RiotApi.Enums;
using Xunit;

namespace RiotGamesApi.Tests
{
    public class UsingStaticApiClass : BaseTestClass
    {
        [Fact]
        public void Using()
        {
            var champions = Api.Static.StaticData_v3.GetChampions(AspNetCore.RiotApi.Enums.ServicePlatform.TR1, false, null, null,
                  new List<ChampionTag>() { ChampionTag.all }, true);
            Assert.False(champions.HasError);
        }
    }
}