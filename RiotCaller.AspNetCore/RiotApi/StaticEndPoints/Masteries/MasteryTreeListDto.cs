using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Masteries
{
    public class MasteryTreeListDto
    {
        [JsonProperty("masteryTreeItems")]
        public List<MasteryTreeItemDto> masteryTreeItems { get; set; }
    }
}