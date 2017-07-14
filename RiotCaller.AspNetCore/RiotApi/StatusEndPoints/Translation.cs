using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.AspNetCore.RiotApi.StatusEndPoints
{
    public class Translation
    {
        //
        [JsonProperty("locale")]
        public string locale { get; set; }

        //
        [JsonProperty("content")]
        public string content { get; set; }

        [JsonProperty("updated_at")]
        public string updated_at { get; set; }
    }
}