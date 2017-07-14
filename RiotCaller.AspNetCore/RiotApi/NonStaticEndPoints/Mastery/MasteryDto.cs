using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Mastery
{
    public class MasteryDto
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("rank")]
        public int rank { get; set; }
    }
}