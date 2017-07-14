using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RiotGamesApi.AspNetCore.RiotApi.StatusEndPoints;

namespace RiotGamesApi.AspNetCore.RiotApi.StatusEndPoints
{
    public class Incident
    {
        //
        [JsonProperty("active")]
        public bool active { get; set; }

        //
        [JsonProperty("created_at")]
        public string created_at { get; set; }

        //
        [JsonProperty("id")]
        public long id { get; set; }

        [JsonProperty("updates")]
        public List<Message> updates { get; set; }
    }
}