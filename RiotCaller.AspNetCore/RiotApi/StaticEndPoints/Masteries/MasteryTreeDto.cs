using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Masteries
{
    public class MasteryTreeDto
    {
        //
        [JsonProperty("Resolve")]
        public List<MasteryTreeListDto> Resolve { get; set; }

        //
        [JsonProperty("Ferocity")]
        public List<MasteryTreeListDto> Ferocity { get; set; }

        [JsonProperty("Cunning")]
        public List<MasteryTreeListDto> Cunning { get; set; }
    }
}