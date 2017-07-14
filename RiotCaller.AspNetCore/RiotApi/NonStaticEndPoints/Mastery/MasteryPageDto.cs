using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Mastery
{
    public class MasteryPageDto
    {
        [JsonProperty("current")]
        public bool current { get; set; }

        [JsonProperty("masteries")]
        public List<MasteryDto> masteries { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("id")]
        public long id { get; set; }
    }
}