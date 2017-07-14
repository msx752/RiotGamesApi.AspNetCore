using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using RiotGamesApi.AspNetCore.Attributes;
using RiotGamesApi.AspNetCore.Builder;
using RiotGamesApi.AspNetCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using RiotGamesApi.AspNetCore.Interfaces;

namespace RiotGamesApi.AspNetCore.Extensions
{
    public static class Extension1
    {
        public static IRiotGamesApiBuilder UseNonStaticApi(this IRiotGamesApiBuilder option, Func<Models.RiotGamesApi, Models.RiotGamesApi> action)
        {
            option.RiotGamesApiOptions.RiotGamesApis[UrlType.NonStatic] = action(new Models.RiotGamesApi(option.RiotGamesApiOptions.NonStaticUrl));
            return option;
        }

        public static IApplicationBuilder UseRiotGamesApi(this IApplicationBuilder app)
        {
            IServiceProvider SProvider = app.ApplicationServices;
            RiotGamesApiSettings.ServiceProvider = SProvider;
            return app;
        }

        public static IRiotGamesApiBuilder UseStaticApi(this IRiotGamesApiBuilder option, Func<Models.RiotGamesApi, Models.RiotGamesApi> action)
        {
            option.RiotGamesApiOptions.RiotGamesApis[UrlType.Static] = action(new Models.RiotGamesApi(option.RiotGamesApiOptions.StaticUrl));
            return option;
        }

        public static IRiotGamesApiBuilder UseStatusApi(this IRiotGamesApiBuilder option, Func<Models.RiotGamesApi, Models.RiotGamesApi> action)
        {
            option.RiotGamesApiOptions.RiotGamesApis[UrlType.Status] = action(new Models.RiotGamesApi(option.RiotGamesApiOptions.StatusUrl));
            return option;
        }
    }
}