﻿using Microsoft.Extensions.Configuration;
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
        public long AccountId { get; }
        public AspNetCoreTestServer AspNetCoreTestServer { get; }

        public long ChampionId { get; }

        public IConfigurationRoot Configuration { get; }
        public long MatchId { get; }
        public long ItemId { get; }

        public Region RegionType { get; }
        public Platform PlatformType { get; }

        public long SummonerId { get; }

        public string SummonerName { get; }
        public string TournamentCode { get; }

        public long MasteryId { get; }

        public BaseTestClass()
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