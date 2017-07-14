using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Champions
{
    public class BlockItemDto
    {
        //
        [JsonProperty("count")]
        public int count { get; set; }

        [JsonProperty("id")]
        public int id { get; set; }
    }
}