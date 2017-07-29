[![nuget](https://img.shields.io/badge/Nuget-RiotGamesApi.AspNetCore-brightgreen.svg?style=flat-square&maxAge=259200)](https://www.nuget.org/packages/RiotGamesApi.AspNetCore)
[![NuGet](https://img.shields.io/nuget/v/RiotGamesApi.AspNetCore.svg?style=flat-square)](https://www.nuget.org/packages/RiotGamesApi.AspNetCore)
[![Build status](https://ci.appveyor.com/api/projects/status/nli0nlk8trqo57qg)](https://ci.appveyor.com/project/msx752/riotgamesapi-aspnetcore)

# RiotGamesApi.AspNetCore
League Of Legends v3 API Wrapper for .Net Core 1.1

### **Usage** https://github.com/msx752/RiotGamesApi.AspNetCore/wiki

# Step by Step Configuration
- add reference `using RiotGamesApi.AspNetCore.Extensions;` to begining of the Startup.cs
- add `services.AddLeagueOfLegendsApi("RiotApiKey");` to end of the `ConfigureServices()` method which contains in Startup.cs
- determine your **RiotApiKey** in Startup.cs
- add `app.UseRiotGamesApi();` to end of the `Configure()` method which contains in Startup.cs
- default settings Caching: *disable*, RateLimiting: *enable*, 
- IMPORTANT NOTICE: web-server setting must be `full-trust` for access to `System.Reflection` when you published the web-site-project

## Configuration
- includes `app.AddLeagueOfLegendsApi();` (using necessary)
	```c#
	  public void ConfigureServices(IServiceCollection services)
        {
	..
	..
	app.AddLeagueOfLegendsApi("riot_key");//at the end
	}
	```
	- *types of AddLeagueOfLegendsApi method*
		1. **AddLeagueOfLegendsApi({ String })**);
			- String: *RiotApiKey*
		```c#
		services.AddLeagueOfLegendsApi("your_key");
		```
		2. **AddLeagueOfLegendsApi({ String }, { Func<CacheOption, CacheOption> }))**;
			- String: *RiotApiKey*
			- Func<CacheOption, CacheOption> : *custom cache configs*
		 ```c#
			services.AddLeagueOfLegendsApi("your_key",(cache) =>{
		      //overrides default values
		      cache.EnableStaticApiCaching = true;
		      cache.StaticApiCacheExpiry = new TimeSpan(1, 0, 0);
		      
		      //custom caching is activated
		      //working for any api except static-api
		      cache.EnableCustomApiCaching = true;
		      //summoner-profiles are cached for 5sec
		      cache.AddCacheRule(LolUrlType.NonStatic, LolApiName.Summoner, new TimeSpan(0, 0, 5));
		      //

		      return cache;
		  });
		```
		3. **AddLeagueOfLegendsApi({ String },  null , { Func<RateLimitData, RateLimitData> }))**;
			- String: *RiotApiKey*
			- null : *default cache configs*
			- Func<RateLimitData, RateLimitData> : *custom rate-limit configs*
		 ```c#
			 services.AddLeagueOfLegendsApi("your_key",null,(limits) =>{
		      limits.ClearMatchApiXMethodRateLimit();//removes default value
		      limits.ClearXAppRateLimits();//removes default  value
		      limits.ClearXMethodRateLimits();//removes default value
		      //overrides default values
		      limits.DisableLimiting = false;
		      limits.AddXAppRateLimits(new Dictionary<TimeSpan, int>()
		      {
			  {new TimeSpan(0, 2, 0), 100 },
			  {new TimeSpan(0, 0, 1), 20 }
		      });

		      limits.AddXMethodRateLimits(new Dictionary<TimeSpan, int>()
		      {
			  {new TimeSpan(0, 10, 0), 1200000 },
			  {new TimeSpan(0, 0, 10), 20000 }
		      });

		      limits.SetMatchApiXMethodRateLimit(new TimeSpan(0, 0, 10), 500);
		      return limits;
		  });
		```
		4. **or we can use both configs at the same time**
		```c#
		services.AddLeagueOfLegendsApi("your_key",
		(cache)=>{ /*as mentioned above*/}, 
		(limits) => { /*as mentioned above*/});
		```
- includes `app.UseRiotGamesApi();` (using necessary)
	```c#
	  public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
	..
	..
	app.UseRiotGamesApi();//at the end
	}
	```
# Usage
- Using with service-layer

```c#
using RiotGamesApi.AspNetCore;

public class HomeController : Controller
{
        public Api LolApi { get; set; }

        public HomeController(Api _api)//DI
        {
            LolApi = _api;
        }
	public async Task<IActionResult> Index()
        {
            var rit = await LolApi.NonStaticApi.ChampionMasteryv3
	    .GetChampionMasteriesBySummonerAsync(ServicePlatform.TR1, 466244);
            return View(rit);
        }
}
```

- **Using sync-api**
	1. **method 1** (using with service-layer)
	 ```c#
	var rit = LolApi.NonStaticApi.ChampionMasteryv3
	.GetChampionMasteriesBySummoner(ServicePlatform.TR1, 466244);
	 ```
	 
	2. **method 2** (using as fluent-api-method)
	```c#
	var rit = new ApiCall()
                .SelectApi<List<ChampionMasteryDto>>(LolApiName.ChampionMastery)
                .For(LolApiMethodName.ChampionMasteries)
                .AddParameter(new ApiParameter(LolApiPath.BySummoner, (long)466244))
                .Build(ServicePlatform.TR1)
                .Get();
	```
	 
- **Using async-api**
	1. **method 1** (using with service-layer)
	```c#
	var rit = await LolApi.NonStaticApi.ChampionMasteryv3
	.GetChampionMasteriesBySummonerAsync(ServicePlatform.TR1, 466244);
	```
	
	2. **method 2** (using as fluent-api-method)
	 ```c#
	 var rit = await new ApiCall()
                .SelectApi<List<ChampionMasteryDto>>(LolApiName.ChampionMastery)
                .For(LolApiMethodName.ChampionMasteries)
                .AddParameter(new ApiParameter(LolApiPath.BySummoner, (long)466244))
                .Build(ServicePlatform.TR1)
                .GetAsync();
	 ```

# Global Variables
- `RiotGamesApi.AspNetCore.ApiSettings` **STATIC-CLASS** >> All Dependency-Injection features in here

# Service Layer
- compatible with using on Controller

- Dependency Injections
  - `RiotGamesApi.AspNetCore.Api` **CLASS** >> Sync/Async, static/non-static/status/tournament apis (**auto generated class**)
  - `RiotGamesApi.AspNetCore.RateLimit.ApiRate` **CLASS** >> api rate limiter for non-static-api/tournament-api (**default: 20 requests in 1 sec, 100 requests in 2 minutes**)
  - `RiotGamesApi.AspNetCore.Interfaces.IApiCache` **INTERFACE** >> caching static-api (**default: false**)


# More Information
- [Examples](https://github.com/msx752/RiotGamesApi.AspNetCore/blob/master/RiotCaller.Tests/RiotGamesApis)
- [Sample Project](https://github.com/msx752/RiotGamesApi.AspNetCore/blob/master/RiotCaller.Web)

# Features
- v3-api (*and upper*)
- Sync/Async 
- Caching
	- StaticApiCaching is supported (**default: false**)
	- CustomApiCaching is supported (*for type of non-static api i.e. SummonerProfile*) (**default: false**)
- RateLimiting[*more reliable for respects to regional limits*] (**default: Active**)
	- reads response headers (*X-Rate-Limit-Type* and *Retry-After*)
	- supports special limits for any api path
	- *X-Rate-Limit-Type* is supported (*showing which restriction being forced*)
	- *Retry-After* feature is supported (*per region*)
	- *X-App-Rate-Limit* is supported (*per region*)
	- *X-Method-Rate-Limit* is supported  (*per region*)
	- `special limit for matchlists` X-Method-Rate-Limit is supported  (*per region*)
	- Find current ratelimit for any regions and any apiTypes
	- *ReTryAfterSeconds* feature
	- Enabling/Disabling feature
- TournamentApi  (there may be a bug)
- StaticApi
- NonStaticApi
- StatusApi

# Issues
- https://github.com/msx752/RiotGamesApi.AspNetCore/issues
