using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Masteries
{
    public class MasteryTreeItemDto
    {
        //
        [JsonProperty("masteryId")]
        public int masteryId { get; set; }

        [JsonProperty("prereq")]
        public string prereq { get; set; }
    }
}