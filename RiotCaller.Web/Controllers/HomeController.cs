using Microsoft.AspNetCore.Mvc;
using RiotGamesApi.AspNetCore;
using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.Models;
using RiotGamesApi.AspNetCore.RiotApi.Enums;
using RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.ChampionMastery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiotGamesApi.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var rit1 = new ApiCall()
                .SelectApi<List<ChampionMasteryDto>>(ApiName.ChampionMastery)
                .For(ApiMiddleName.ChampionMasteries)
                .AddParameter(new ApiParameter(ApiParam.BySummoner, (long)466244))
                .Build(Platform.TR1)
                .Get();

            var rit = Api.NonStatic.ChampionMastery_v3.GetChampionMasteriesBySummoner(Platform.TR1, 466244);
            return View(rit);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}