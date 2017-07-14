using System.Collections.Generic;

namespace RiotGamesApi.AspNetCore
{
    public class RiotGamesApiApi
    {
        public RiotGamesApiApi(string baseUrl)
        {
            ApiUrl = baseUrl;
            RiotGamesApiApiUrls = new List<RiotGamesApiApiUrl>();
        }

        public string ApiUrl { get; set; }
        public List<RiotGamesApiApiUrl> RiotGamesApiApiUrls { get; }
    }
}