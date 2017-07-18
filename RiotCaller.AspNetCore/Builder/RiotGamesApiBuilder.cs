using RiotGamesApi.AspNetCore.Interfaces;
using RiotGamesApi.AspNetCore.Models;

namespace RiotGamesApi.AspNetCore.Builder
{
    public class RiotGamesApiBuilder : IApiBuilder
    {
        public RiotGamesApiBuilder()
        {
            RiotGamesApiOptions = new LolApiOptions();
        }

        public IApiOption RiotGamesApiOptions { get; }

        public IApiOption Build()
        {
            return RiotGamesApiOptions;
        }

        public IApiBuilder UseApiUrl(string _url)
        {
            RiotGamesApiOptions.Url = $"https://{{platformId}}.{_url}";
            return this;
        }

        public IApiBuilder UseRiotApiKey(string riotApiKey)
        {
            RiotGamesApiOptions.RiotApiKey = riotApiKey;
            return this;
        }
    }
}