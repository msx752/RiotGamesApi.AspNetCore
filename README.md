[![nuget](https://img.shields.io/badge/Nuget-RiotGamesApi.AspNetCore-brightgreen.svg?style=flat-square&maxAge=259200)](https://www.nuget.org/packages/RiotGamesApi.AspNetCore)
[![NuGet](https://img.shields.io/nuget/v/RiotGamesApi.AspNetCore.svg?style=flat-square)](https://www.nuget.org/packages/RiotGamesApi.AspNetCore)
[![Build status](https://ci.appveyor.com/api/projects/status/nli0nlk8trqo57qg)](https://ci.appveyor.com/project/msx752/riotgamesapi-aspnetcore)

# RiotGamesApi.AspNetCore
League Of Legends v3 API Wrapper for .Net Core 1.1

### **Usage** https://github.com/msx752/RiotGamesApi.AspNetCore/wiki


# API Wrapper Configuration
- add reference `using RiotGamesApi.AspNetCore.Extensions;` to begining of the Startup.cs
- add `services.AddLeagueOfLegendsApi("RiotApiKey");` to end of the `ConfigureServices()` method which contains in Startup.cs
- determine your **RiotApiKey** in Startup.cs
- add `app.UseRiotGamesApi();` to end of the `Configure()` method which contains in Startup.cs
- default settings Caching:disable, RateLimiting:enable, 
- IMPORTANT NOTICE: web-server setting must be `full-trust` for access to `System.Reflection` when you published the web-site-project

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

# Global Variables
- [`RiotGamesApi.AspNetCore.ApiSettings` *STATIC-CLASS*] >> All Dependency-Injection features in here


# Service Layer
- compatible with using on Controller

- Dependency Injections
  - [`RiotGamesApi.AspNetCore.Api` *CLASS*] >> Sync/Async, static/non-static/status/tournament apis (**auto generated class**)
  - [`RiotGamesApi.AspNetCore.RateLimit.ApiRate` *CLASS*] >> api rate limiter for non-static-api/tournament-api (**default: 20 requests in 1 sec, 100 requests in 2 minutes**)
  - [`RiotGamesApi.AspNetCore.Interfaces.IApiCache` *INTERFACE*] >> caching static-api (**default: false**)

# Issues
- https://github.com/msx752/RiotGamesApi.AspNetCore/issues
