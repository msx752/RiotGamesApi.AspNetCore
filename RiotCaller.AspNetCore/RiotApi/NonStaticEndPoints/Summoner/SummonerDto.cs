using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RiotGamesApi.AspNetCore.RiotApi.Converters;
using RiotGamesApi.AspNetCore.RiotApi.Enums;

namespace RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Summoner
{
    public class SummonerDto
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("profileIconId")]
        public int ProfileIconId { get; set; }

        [JsonConverter(typeof(DateTimeFromLong))]
        [JsonProperty("revisionDate")]
        public DateTime RevisionDate { get; set; }

        [JsonProperty("summonerLevel")]
        public int SummonerLevel { get; set; }

        public Region Region;
    }
}