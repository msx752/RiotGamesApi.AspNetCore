using System;
using RiotGamesApi.AspNetCore.Enums;
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

        public IApiBuilder UseNonStaticApi(Func<Models.RiotGamesApi, Models.RiotGamesApi> action)
        {
            this.RiotGamesApiOptions.RiotGamesApis[LolUrlType.NonStatic] =
                action(new Models.RiotGamesApi(this.RiotGamesApiOptions.NonStaticUrl));
            return this;
        }

        public IApiBuilder UseRiotApiKey(string riotApiKey)
        {
            RiotGamesApiOptions.RiotApiKey = riotApiKey;
            return this;
        }

        public IApiBuilder UseStaticApi(Func<Models.RiotGamesApi, Models.RiotGamesApi> action)
        {
            this.RiotGamesApiOptions.RiotGamesApis[LolUrlType.Static] =
                action(new Models.RiotGamesApi(this.RiotGamesApiOptions.StaticUrl));
            return this;
        }

        public IApiBuilder UseStatusApi(Func<Models.RiotGamesApi, Models.RiotGamesApi> action)
        {
            this.RiotGamesApiOptions.RiotGamesApis[LolUrlType.Status] =
                action(new Models.RiotGamesApi(this.RiotGamesApiOptions.StatusUrl));
            return this;
        }

        public IApiBuilder UseTournamentApi(Func<Models.RiotGamesApi, Models.RiotGamesApi> action)
        {
            this.RiotGamesApiOptions.RiotGamesApis[LolUrlType.Tournament] =
                action(new Models.RiotGamesApi(this.RiotGamesApiOptions.TournamentUrl));
            return this;
        }
    }
}