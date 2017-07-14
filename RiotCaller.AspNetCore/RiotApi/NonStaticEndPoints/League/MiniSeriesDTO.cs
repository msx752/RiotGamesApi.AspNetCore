using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League
{
    public class MiniSeriesDTO
    {
        [JsonProperty("progress")]
        public string Progress { get; set; }

        [JsonProperty("target")]
        public int Target { get; set; }

        [JsonProperty("losses")]
        public int Losses { get; set; }

        [JsonProperty("wins")]
        public int Wins { get; set; }
    }
}