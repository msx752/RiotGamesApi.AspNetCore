using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Match
{
    public class PlayerDto
    {
        //
        [JsonProperty("currentPlatformId")]
        public string currentPlatformId { get; set; }

        //
        [JsonProperty("summonerName")]
        public string summonerName { get; set; }

        //
        [JsonProperty("matchHistoryUri")]
        public string matchHistoryUri { get; set; }

        //
        [JsonProperty("platformId")]
        public string platformId { get; set; }

        //
        [JsonProperty("currentAccountId")]
        public long currentAccountId { get; set; }

        //
        [JsonProperty("profileIcon")]
        public int profileIcon { get; set; }

        //
        [JsonProperty("summonerId")]
        public long summonerId { get; set; }

        [JsonProperty("accountId")]
        public long accountId { get; set; }
    }
}