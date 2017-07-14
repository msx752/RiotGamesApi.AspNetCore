using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Match
{
    public class MasteryDto
    {
        //
        [JsonProperty("masteryId")]
        public int masteryId { get; set; }

        [JsonProperty("rank")]
        public int rank { get; set; }
    }
}