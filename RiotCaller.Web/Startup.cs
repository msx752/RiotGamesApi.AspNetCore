using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RiotGamesApi.AspNetCore.Extensions;

/*
    using RiotGamesApi.AspNetCore.Extensions;

    add this reference for using .net core middleware
 * */

namespace RiotGamesApi.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            //necessary
            services.AddLeagueOfLegendsApi("RGAPI-a5dcfb69-f596-4ddb-b407-f56852f359a1",
            (cache) =>
            {
                cache.EnableStaticApiCaching = true;
                cache.StaticApiCacheExpiry = new TimeSpan(1, 0, 0);
                return cache;
            },
            (rateLimit) =>
            {
                rateLimit.AddEvery().One().Seconds(10);
                rateLimit.AddEvery().Two().Minutes(100);
                return rateLimit;
            }
            );
            //use your key
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            //necessary
            app.UseRiotGamesApi();
        }
    }
}