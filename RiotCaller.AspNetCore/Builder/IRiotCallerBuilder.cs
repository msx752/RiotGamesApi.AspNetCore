namespace RiotGamesApi.AspNetCore.Builder
{
    public interface IRiotGamesApiBuilder
    {
        IRiotGamesApiOption RiotGamesApiOptions { get; }

        IRiotGamesApiOption Build();

        IRiotGamesApiBuilder UseApiUrl(string _url);

        IRiotGamesApiBuilder UseRiotApiKey(string riotApiKey);
    }
}