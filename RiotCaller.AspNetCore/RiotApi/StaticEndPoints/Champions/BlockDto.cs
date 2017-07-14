﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Champions
{
    public class BlockDto
    {
        //
        [JsonProperty("items")]
        public List<BlockItemDto> items { get; set; }

        //
        [JsonProperty("recMath")]
        public bool recMath { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }
    }
}