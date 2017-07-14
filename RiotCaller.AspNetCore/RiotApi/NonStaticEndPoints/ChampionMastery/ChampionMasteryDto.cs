using Newtonsoft.Json;
using RiotGamesApi.AspNetCore.RiotApi.Converters;
using System;

namespace RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.ChampionMastery
{
    public class ChampionMasteryDto
    {
        [JsonProperty("championPoints")]
        public int ChampionPoints { get; set; }

        [JsonProperty("playerId")]
        public long PlayerId { get; set; }

        [JsonProperty("championPointsUntilNextLevel")]
        public int ChampionPointsUntilNextLevel { get; set; }

        [JsonProperty("chestGranted")]
        public bool ChestGranted { get; set; }

        [JsonProperty("championLevel")]
        public int ChampionLevel { get; set; }

        [JsonProperty("championId")]
        public long ChampionId { get; set; }

        [JsonProperty("championPointsSinceLastLevel")]
        public long ChampionPointsSinceLastLevel { get; set; }

        [JsonConverter(typeof(DateTimeFromLong))]
        [JsonProperty("lastPlayTime")]
        public DateTime LastPlayTime { get; set; }
    }
}