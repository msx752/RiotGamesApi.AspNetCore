using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Rune
{
    public class RunePageDto
    {
        //Indicates if the page is the current page.
        [JsonProperty("current")]
        public bool current { get; set; }

        //Collection of rune slots associated with the rune page.
        [JsonProperty("slots")]
        public List<RuneSlotDto> slots { get; set; }

        //Rune page name.
        [JsonProperty("name")]
        public string name { get; set; }

        //Rune page ID.
        [JsonProperty("id")]
        public long id { get; set; }
    }
}