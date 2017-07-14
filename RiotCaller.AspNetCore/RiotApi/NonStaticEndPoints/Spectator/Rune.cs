using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Spectator
{
    public class Rune
    {
        //The count of this rune used by the participant
        [JsonProperty("count")]
        public int count { get; set; }

        //The ID of the rune
        [JsonProperty("runeId")]
        public long runeId { get; set; }
    }
}