using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Champions
{
    public class PassiveDto
    {
        //
        [JsonProperty("image")]
        public ImageDto image { get; set; }

        //
        [JsonProperty("sanitizedDescription")]
        public string sanitizedDescription { get; set; }

        //
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }
    }
}