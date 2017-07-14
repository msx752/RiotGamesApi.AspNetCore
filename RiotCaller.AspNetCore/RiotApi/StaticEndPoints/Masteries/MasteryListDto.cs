using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Masteries
{
    public class MasteryListDto
    {
        //
        [JsonProperty("data")]
        public Dictionary<string, MasteryDto> data { get; set; }

        //
        [JsonProperty("version")]
        public string version { get; set; }

        //
        [JsonProperty("tree")]
        public MasteryTreeDto tree { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }
    }
}