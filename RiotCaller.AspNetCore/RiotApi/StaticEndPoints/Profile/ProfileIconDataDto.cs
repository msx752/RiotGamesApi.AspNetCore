using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Profile
{
    public class ProfileIconDataDto
    {
        //
        [JsonProperty("data")]
        public Dictionary<string, ProfileIconDetailsDto> data { get; set; }

        //
        [JsonProperty("version")]
        public string version { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }
    }
}