using System.Collections.Generic;

namespace RiotGamesApi.AspNetCore.Models
{
    public class RiotGamesApi
    {
        public RiotGamesApi(string baseUrl)
        {
            ApiUrl = baseUrl;
            RiotGamesApiUrls = new List<LolApiUrl>();
        }

        public string ApiUrl { get; set; }
        public List<LolApiUrl> RiotGamesApiUrls { get; }
    }
}