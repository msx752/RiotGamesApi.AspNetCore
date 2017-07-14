using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;
using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.RiotApi.Enums;
using RiotGamesApi.Enums;
using Xunit;

namespace RiotGamesApi.Tests
{
    public class BaseTestClass
    {
        public static AspNetCoreTestServer AspNetCoreTestServer;

        public static long championId1;

        public static long gameId1;

        public static long itemId1;

        public static Region Region;

        public static long summonerId1;

        public static long summonerId2;

        public static string summonerName1;

        public static string summonerName2;

        public static string teamName1;

        public static string teamName2;
        public static long accountId;

        public static IConfigurationRoot Configuration;

        static BaseTestClass()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile(Directory.GetCurrentDirectory() + "\\appsettings.json",
                    optional: false, reloadOnChange: true);
            Configuration = builder.Build();

            championId1 = long.Parse(Configuration["championId1"]);

            gameId1 = long.Parse(Configuration["gameId1"]);

            itemId1 = long.Parse(Configuration["itemId1"]);

            Region Region = (Region)Enum.Parse(typeof(Region), Configuration["region"]);

            summonerId1 = long.Parse(Configuration["summonerId1"]);

            summonerId2 = long.Parse(Configuration["summonerId2"]);

            summonerName1 = Configuration["summonerName1"];

            summonerName2 = Configuration["summonerName2"];

            teamName1 = Configuration["teamId1"];

            teamName2 = Configuration["teamId2"];

            accountId = long.Parse(Configuration["accountId"]);
            AspNetCoreTestServer = new AspNetCoreTestServer();
        }
    }
}