using RiotGamesApi.AspNetCore.Interfaces;

namespace RiotGamesApi.AspNetCore.Builder
{
    public class RiotGamesApiBuilder : IRiotGamesApiBuilder
    {
        public RiotGamesApiBuilder()
        {
            RiotGamesApiOptions = new RiotGamesApiOptions();
        }

        public IRiotGamesApiOption RiotGamesApiOptions { get; }

        public IRiotGamesApiOption Build()
        {
            return RiotGamesApiOptions;
        }

        public IRiotGamesApiBuilder UseApiUrl(string _url)
        {
            RiotGamesApiOptions.Url = $"https://{{platformId}}.{_url}";
            return this;
        }

        public IRiotGamesApiBuilder UseRiotApiKey(string riotApiKey)
        {
            RiotGamesApiOptions.RiotApiKey = riotApiKey;
            return this;
        }
    }
}