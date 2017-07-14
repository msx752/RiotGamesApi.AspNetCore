using Microsoft.Extensions.Configuration;
using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.RiotApi.Enums;
using RiotGamesApi.AspNetCore.RiotApi.Extensions;
using RiotGamesApi.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace RiotGamesApi.Tests
{
    public class BaseTestClass
    {
        public static long AccountId { get; }
        public static AspNetCoreTestServer AspNetCoreTestServer { get; }

        public static long ChampionId1 { get; }

        public static IConfigurationRoot Configuration { get; }
        public static long GameId1 { get; }

        public static long ItemId1 { get; }

        public static Region RegionType { get; }
        public static Platform PlatformType { get; }

        public static long SummonerId1 { get; }

        public static long SummonerId2 { get; }

        public static string SummonerName1 { get; }

        public static string SummonerName2 { get; }

        public static string TeamName1 { get; }

        public static string TeamName2 { get; }

        static BaseTestClass()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile(Directory.GetCurrentDirectory() + "\\appsettings.json",
                    optional: false, reloadOnChange: true);
            Configuration = builder.Build();

            ChampionId1 = long.Parse(Configuration["championId1"]);

            GameId1 = long.Parse(Configuration["gameId1"]);

            ItemId1 = long.Parse(Configuration["itemId1"]);

            RegionType = (Region)Enum.Parse(typeof(Region), Configuration["region"]);
            PlatformType = RegionType.ToPlatform();
            SummonerId1 = long.Parse(Configuration["summonerId1"]);

            SummonerId2 = long.Parse(Configuration["summonerId2"]);

            SummonerName1 = Configuration["summonerName1"];

            SummonerName2 = Configuration["summonerName2"];

            TeamName1 = Configuration["teamId1"];

            TeamName2 = Configuration["teamId2"];

            AccountId = long.Parse(Configuration["accountId"]);
            AspNetCoreTestServer = new AspNetCoreTestServer();
        }
    }
}