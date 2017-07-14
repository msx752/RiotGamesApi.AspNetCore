using RiotGamesApi.AspNetCore;

using RiotGamesApi.AspNetCore;

using RiotGamesApi.AspNetCore.Enums;

using RiotGamesApi.AspNetCore.Enums;

using RiotGamesApi.AspNetCore.Models;
using RiotGamesApi.AspNetCore.RiotApi.Enums;
using RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Champions;
using RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Items;
using RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.LanguageStrings;
using RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Maps;
using RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Masteries;
using RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Realms;
using RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Runes;
using RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.SummonerSpell;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RiotGamesApi.Tests
{
    public class LOL_STATIC_DATA_V3 : BaseTestClass
    {
        [Fact]
        public void GetChampions()
        {
            var rit = new ApiCall()
                .SelectApi<ChampionListDto>(ApiName.StaticData)
                .For(ApiMiddleName.Champions)
                .AddParameter()
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetChampionsOnlyId()
        {
            var rit = new ApiCall()
                .SelectApi<ChampionDto>(ApiName.StaticData)
                .For(ApiMiddleName.Champions)
                .AddParameter(new ApiParameter(ApiParam.OnlyId, (long)1))
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetItems()
        {
            var rit = new ApiCall()
                .SelectApi<ItemListDto>(ApiName.StaticData)
                .For(ApiMiddleName.Champions)
                .AddParameter()
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetItemsOnlyId()
        {
            var rit = new ApiCall()
                .SelectApi<ItemDto>(ApiName.StaticData)
                .For(ApiMiddleName.Items)
                .AddParameter(new ApiParameter(ApiParam.OnlyId, (long)1))
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetLanguageStrings()
        {
            var rit = new ApiCall()
                .SelectApi<LanguageStringsDto>(ApiName.StaticData)
                .For(ApiMiddleName.LanguageStrings)
                .AddParameter()
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetLanguages()
        {
            var rit = new ApiCall()
                .SelectApi<List<string>>(ApiName.StaticData)
                .For(ApiMiddleName.Languages)
                .AddParameter()
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetMaps()
        {
            var rit = new ApiCall()
                .SelectApi<MapDataDto>(ApiName.StaticData)
                .For(ApiMiddleName.Maps)
                .AddParameter()
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetMasteries()
        {
            var rit = new ApiCall()
                .SelectApi<MasteryListDto>(ApiName.StaticData)
                .For(ApiMiddleName.Masteries)
                .AddParameter()
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetMasteriesOnlyId()
        {
            var rit = new ApiCall()
                .SelectApi<MasteryDto>(ApiName.StaticData)
                .For(ApiMiddleName.Masteries)
                .AddParameter(new ApiParameter(ApiParam.OnlyId, (long)1))
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetRealms()
        {
            var rit = new ApiCall()
                .SelectApi<RealmDto>(ApiName.StaticData)
                .For(ApiMiddleName.Realms)
                .AddParameter()
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetRunes()
        {
            var rit = new ApiCall()
                .SelectApi<RuneListDto>(ApiName.StaticData)
                .For(ApiMiddleName.Runes)
                .AddParameter()
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetRunesOnlyId()
        {
            var rit = new ApiCall()
                .SelectApi<RuneDto>(ApiName.StaticData)
                .For(ApiMiddleName.Runes)
                .AddParameter(new ApiParameter(ApiParam.OnlyId, (long)1))
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetSummonerSpells()
        {
            var rit = new ApiCall()
                .SelectApi<SummonerSpellListDto>(ApiName.StaticData)
                .For(ApiMiddleName.SummonerSpells)
                .AddParameter()
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetSummonerSpellsOnlyId()
        {
            var rit = new ApiCall()
                .SelectApi<SummonerSpellDto>(ApiName.StaticData)
                .For(ApiMiddleName.SummonerSpells)
                .AddParameter(new ApiParameter(ApiParam.OnlyId, (long)1))
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetVersions()
        {
            var rit = new ApiCall()
                .SelectApi<List<string>>(ApiName.StaticData)
                .For(ApiMiddleName.Versions)
                .AddParameter()
                .Build(PlatformType)
                .Get();
            Assert.False(rit.HasError);
        }
    }
}