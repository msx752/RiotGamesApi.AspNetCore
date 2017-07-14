﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Runes
{
    public class MetaDataDto
    {
        //
        [JsonProperty("tier")]
        public string tier { get; set; }

        //
        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("isRune")]
        public bool isRune { get; set; }
    }
}