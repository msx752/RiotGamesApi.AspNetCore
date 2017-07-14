using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Profile
{
    public class ProfileIconDetailsDto
    {
        //
        [JsonProperty("image")]
        public ImageDto image { get; set; }

        [JsonProperty("id")]
        public long id { get; set; }
    }
}