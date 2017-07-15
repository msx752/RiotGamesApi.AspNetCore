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

        public static long ChampionId { get; }

        public static IConfigurationRoot Configuration { get; }
        public static long MatchId { get; }
        public static long ItemId { get; }

        public static Region RegionType { get; }
        public static Platform PlatformType { get; }

        public static long SummonerId { get; }

        public static string SummonerName { get; }
        public static string TournamentCode { get; }

        public static long MasteryId { get; }

        static BaseTestClass()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile(Directory.GetCurrentDirectory() + "\\appsettings.json",
                    optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            ChampionId = long.Parse(Configuration["championId"]);

            MatchId = long.Parse(Configuration["matchId"]);

            ItemId = long.Parse(Configuration["itemId"]);

            RegionType = (Region)Enum.Parse(typeof(Region), Configuration["region"]);

            PlatformType = RegionType.ToPlatform();

            SummonerId = long.Parse(Configuration["summonerId"]);

            SummonerName = Configuration["summonerName"];

            AccountId = long.Parse(Configuration["accountId"]);

            TournamentCode = Configuration["tournamentCode"];

            MasteryId = long.Parse(Configuration["masteryId"]);

            AspNetCoreTestServer = new AspNetCoreTestServer();
        }
    }
}