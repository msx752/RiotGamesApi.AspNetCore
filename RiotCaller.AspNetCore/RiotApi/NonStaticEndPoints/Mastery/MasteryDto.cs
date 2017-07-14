using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

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