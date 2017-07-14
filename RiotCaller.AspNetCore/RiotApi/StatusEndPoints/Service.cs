using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.AspNetCore.RiotApi.StatusEndPoints
{
    public class Service
    {
        //
        [JsonProperty("status")]
        public string status { get; set; }

        //
        [JsonProperty("incidents")]
        public List<Incident> incidents { get; set; }

        //
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("slug")]
        public string slug { get; set; }
    }
}