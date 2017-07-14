using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Match
{
    public class MatchlistDto
    {
        //
        [JsonProperty("matches")]
        public List<MatchReferenceDto> matches { get; set; }

        //
        [JsonProperty("totalGames")]
        public int totalGames { get; set; }

        //
        [JsonProperty("startIndex")]
        public int startIndex { get; set; }

        [JsonProperty("endIndex")]
        public int endIndex { get; set; }
    }
}