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
            //    .Build(ServicePlatform.TR1)
            //    .GetAsync();
            var rit = LolApi.NonStaticApi.ChampionMasteryv3.GetChampionMasteriesBySummoner(ServicePlatform.TR1, 466244);

            //var rit2 = LolApi.StaticApi.StaticDatav3.GetChampions(ServicePlatform.TR1);
            return View(rit);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}