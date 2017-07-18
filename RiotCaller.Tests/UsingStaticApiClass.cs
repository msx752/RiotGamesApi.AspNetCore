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
            Api p = new Api();
            var champions = p.StaticApi.StaticDatav3.GetChampions(AspNetCore.RiotApi.Enums.ServicePlatform.TR1, false, null, null,
                  new List<ChampionTag>() { ChampionTag.all }, true);
            Assert.False(champions.HasError);
        }
    }
}