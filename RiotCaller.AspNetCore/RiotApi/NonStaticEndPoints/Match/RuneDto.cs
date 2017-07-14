using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Match
{
    public class RuneDto
    {
        //
        [JsonProperty("runeId")]
        public int runeId { get; set; }

        //
        [JsonProperty("rank")]
        public int rank { get; set; }
    }
}