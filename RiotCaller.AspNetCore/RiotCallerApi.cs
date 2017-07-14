using System.Collections.Generic;

namespace RiotGamesApi.AspNetCore
{
    public class RiotGamesApi
    {
        public RiotGamesApi(string baseUrl)
        {
            ApiUrl = baseUrl;
            RiotGamesApiUrls = new List<RiotGamesApiUrl>();
        }

        public string ApiUrl { get; set; }
        public List<RiotGamesApiUrl> RiotGamesApiUrls { get; }
    }
}