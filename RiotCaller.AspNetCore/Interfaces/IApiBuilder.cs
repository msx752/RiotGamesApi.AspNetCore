namespace RiotGamesApi.AspNetCore.Interfaces
{
    public interface IApiBuilder
    {
        IApiOption RiotGamesApiOptions { get; }

        IApiOption Build();

        IApiBuilder UseApiUrl(string _url);

        IApiBuilder UseRiotApiKey(string riotApiKey);
    }
}