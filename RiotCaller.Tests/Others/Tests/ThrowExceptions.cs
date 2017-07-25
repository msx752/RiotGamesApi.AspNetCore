﻿using Newtonsoft.Json;
using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.Models;
using RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Summoner;
using RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Champions;
using Xunit;

namespace RiotGamesApi.Tests.Others.Tests
{
    public class ThrowExceptions : BaseTestClass
    {
        [Fact]
        public void Errors()
        {
            var exp = Assert.Throws(typeof(RiotGamesApiException), () =>
            {
                var rit = new ApiCall()
                    .SelectApi<SummonerDto>(LolApiName.Summoner)
                    .For(LolApiMethodName.ShardData)//there is no such thing
                    .AddParameter(new ApiParameter(LolApiPath.OnlySummonerId, SummonerId))
                    .Build(Service_Platform)
                    .Get();
            });

            exp = Assert.Throws(typeof(RiotGamesApiException), () =>
             {
                 var rit = new ApiCall()
                     .SelectApi<SummonerDto>(LolApiName.Summoner)
                     .For(LolApiMethodName.Summoners)
                     .AddParameter(new ApiParameter(LolApiPath.ByCode, "0"))//there is no such thing
                     .Build(Service_Platform)
                     .Get();
             });

            exp = Assert.Throws(typeof(RiotGamesApiException), () =>
            {
                var rit = new ApiCall()
                    .SelectApi<SummonerDto>(LolApiName.Summoner)
                    .For(LolApiMethodName.Summoners)
                    .AddParameter(new ApiParameter(LolApiPath.OnlySummonerId, (int)SummonerId))//must be long
                    .Build(Service_Platform)
                    .Get();
            });

            exp = Assert.Throws(typeof(RiotGamesApiException), () =>
            {
                var rit = new ApiCall()
                    .SelectApi<ChampionListDto>(LolApiName.Summoner)
                    .For(LolApiMethodName.Summoners)
                    .AddParameter()//summoner must be a parameter
                    .Build(Service_Platform)
                    .Get();
            });

            exp = Assert.Throws(typeof(JsonSerializationException), () =>
            {
                var rit = new ApiCall()
                    .SelectApi<long>(LolApiName.Summoner)//return type must be 'SummonerDto'
                    .For(LolApiMethodName.Summoners)
                    .AddParameter(new ApiParameter(LolApiPath.OnlySummonerId, SummonerId))
                    .Build(Service_Platform)
                    .Get(
                    /*
                    there is no queryParameter for nonStaticApi
                    */);
                Assert.True(rit.HasError);
                throw rit.Exception;
            });
        }
    }
}