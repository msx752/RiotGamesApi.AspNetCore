using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Champions
{
    public class SkinDto
    {
        //
        [JsonProperty("num")]
        public int num { get; set; }

        //
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("id")]
        public int id { get; set; }
    }
}