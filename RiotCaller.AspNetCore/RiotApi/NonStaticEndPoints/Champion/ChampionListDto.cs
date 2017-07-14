using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Champion
{
    public class ChampionListDto
    {
        [JsonProperty("champions")]
        public List<ChampionDto> Champions { get; set; }
    }
}