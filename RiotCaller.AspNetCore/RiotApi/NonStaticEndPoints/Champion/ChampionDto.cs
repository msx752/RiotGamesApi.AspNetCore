using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Champion
{
    public class ChampionDto
    {
        [JsonProperty("botMmEnabled")]
        public bool BotMmEnabled { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("rankedPlayEnabled")]
        public bool RankedPlayEnabled { get; set; }

        [JsonProperty("botEnabled")]
        public bool BotEnabled { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("freeToPlay")]
        public bool FreeToPlay { get; set; }
    }
}