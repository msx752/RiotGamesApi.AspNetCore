using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Mastery
{
    public class MasteryPagesDto
    {
        //Collection of mastery pages associated with the summoner.
        [JsonProperty("pages")]
        public List<MasteryPageDto> pages { get; set; }

        //Summoner ID.
        [JsonProperty("summonerId")]
        public long summonerId { get; set; }
    }
}