using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RiotGamesApi.AspNetCore.RiotApi.StatusEndPoints
{
    public class ShardStatus
    {
        //
        [JsonProperty("name")]
        public string name { get; set; }

        //
        [JsonProperty("region_tag")]
        public string region_tag { get; set; }

        //
        [JsonProperty("hostname")]
        public string hostname { get; set; }

        //
        [JsonProperty("services")]
        public List<Service> services { get; set; }

        //
        [JsonProperty("slug")]
        public string slug { get; set; }

        [JsonProperty("locales")]
        public List<string> locales { get; set; }
    }
}