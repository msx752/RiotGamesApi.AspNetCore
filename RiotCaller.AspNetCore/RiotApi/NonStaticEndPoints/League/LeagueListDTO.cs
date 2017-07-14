using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League
{
    public class LeagueListDTO
    {
        [JsonProperty("tier")]
        public string tier { get; set; }

        [JsonProperty("queue")]
        public string queue { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("entries")]
        public List<LeagueItemDTO> entries { get; set; }
    }
}