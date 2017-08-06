﻿using Microsoft.AspNetCore.Mvc;
using RiotGamesApi.AspNetCore;
using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.Models;
using RiotGamesApi.AspNetCore.RiotApi.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.ChampionMastery;
using RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Champions;

namespace RiotGamesApi.Web.Controllers
{
    public class HomeController : Controller
    {
        public Api LolApi { get; set; }

        public HomeController(Api _api)
        {
            LolApi = _api;
        }

        public async Task<IActionResult> Index()
        {
            var rit1 = await new ApiCall()
                .SelectApi<List<ChampionMasteryDto>>(LolApiName.ChampionMastery)
                .For(LolApiMethodName.ChampionMasteries)
                .AddParameter(new ApiParameter(LolApiPath.BySummoner, (long)34639237))
                .Build(ServicePlatform.EUW1)
                .GetAsync();

            var rit = await LolApi.NonStaticApi.ChampionMasteryv3.GetChampionMasteriesBySummonerAsync(ServicePlatform.EUW1, 34639237);
            if (rit.HasError)
            {
                throw rit.Exception;
            }
            var rit2 = LolApi.StaticApi.StaticDatav3.GetChampions(ServicePlatform.EUW1);
            return View(rit);
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Items()
        {
            var LolApi1 = new ApiCall()
                .SelectApi<ChampionListDto>(LolApiName.StaticData)
                .For(LolApiMethodName.Champions)
                .AddParameter()
                .Build(ServicePlatform.EUW1)
                .UseCache(true)
                .Get(new QueryParameter("tags", ItemTag.image),
                     new QueryParameter("tags", ItemTag.stats));

            var rit = LolApi.StaticApi.StaticDatav3.GetItems(ServicePlatform.EUW1, true, null, null, new List<ItemTag>() { ItemTag.image, ItemTag.stats });
            if (rit.HasError)
            {
                throw rit.Exception;
            }
            return Json(rit.Result);
        }
    }
}