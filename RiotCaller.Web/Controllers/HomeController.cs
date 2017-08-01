using Microsoft.AspNetCore.Mvc;
using RiotGamesApi.AspNetCore;
using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.Models;
using RiotGamesApi.AspNetCore.RiotApi.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.ChampionMastery;

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
            //var rit1 = await new ApiCall()
            //    .SelectApi<List<ChampionMasteryDto>>(LolApiName.ChampionMastery)
            //    .For(LolApiMethodName.ChampionMasteries)
            //    .AddParameter(new ApiParameter(LolApiPath.BySummoner, (long)466244))
            //    .Build(ServicePlatform.EUW1)
            //    .GetAsync();
            var rit = await LolApi.NonStaticApi.ChampionMasteryv3.GetChampionMasteriesBySummonerAsync(ServicePlatform.EUW1, 466244);

            //var rit2 = LolApi.StaticApi.StaticDatav3.GetChampions(ServicePlatform.EUW1);
            return View(rit);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}