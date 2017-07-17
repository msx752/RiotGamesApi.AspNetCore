using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using RiotGamesApi.AspNetCore.Attributes;
using RiotGamesApi.AspNetCore.Builder;
using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RiotGamesApi.AspNetCore.Extensions
{
    public static class Extension1
    {
        public static IApiBuilder UseTournamentApi(this IApiBuilder option, Func<Models.RiotGamesApi, Models.RiotGamesApi> action)
        {
            option.RiotGamesApiOptions.RiotGamesApis[UrlType.Tournament] = action(new Models.RiotGamesApi(option.RiotGamesApiOptions.NonStaticUrl));
            return option;
        }

        public static IApiBuilder UseNonStaticApi(this IApiBuilder option, Func<Models.RiotGamesApi, Models.RiotGamesApi> action)
        {
            option.RiotGamesApiOptions.RiotGamesApis[UrlType.NonStatic] = action(new Models.RiotGamesApi(option.RiotGamesApiOptions.NonStaticUrl));
            return option;
        }

        public static IApplicationBuilder UseRiotGamesApi(this IApplicationBuilder app)
        {
            var sProvider = app.ApplicationServices;
            ApiSettings.ServiceProvider = sProvider;
            return app;
        }

        public static IApiBuilder UseStaticApi(this IApiBuilder option, Func<Models.RiotGamesApi, Models.RiotGamesApi> action)
        {
            option.RiotGamesApiOptions.RiotGamesApis[UrlType.Static] = action(new Models.RiotGamesApi(option.RiotGamesApiOptions.StaticUrl));
            return option;
        }

        public static IApiBuilder UseStatusApi(this IApiBuilder option, Func<Models.RiotGamesApi, Models.RiotGamesApi> action)
        {
            option.RiotGamesApiOptions.RiotGamesApis[UrlType.Status] = action(new Models.RiotGamesApi(option.RiotGamesApiOptions.StatusUrl));
            return option;
        }
    }
}