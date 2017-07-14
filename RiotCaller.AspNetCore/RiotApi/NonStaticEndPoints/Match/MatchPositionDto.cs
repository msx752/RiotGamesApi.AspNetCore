using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Match
{
    public class MatchPositionDto
    {
        //
        [JsonProperty("y")]
        public int y { get; set; }

        [JsonProperty("x")]
        public int x { get; set; }
    }
}