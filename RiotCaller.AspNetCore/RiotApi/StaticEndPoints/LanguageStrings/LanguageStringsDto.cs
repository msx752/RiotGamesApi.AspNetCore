using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.LanguageStrings
{
    public class LanguageStringsDto
    {
        //
        [JsonProperty("data")]
        public Dictionary<string, string> data { get; set; }

        //
        [JsonProperty("version")]
        public string version { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }
    }
}