# RiotGamesApi.AspNetCore Wiki
	- https://github.com/msx752/RiotGamesApi.AspNetCore/wiki

# Features

	- V3-api
	- Sync/Async 
	- RateLimiting (there may be a bug)
	- TournamentApi  (there may be a bug)
	- StaticApi
	- NonStaticApi
	- StatusApi


# Global Variables
	- [RiotGamesApi.AspNetCore.ApiSettings STATIC-CLASS] >> All Dependency-Injection features in here


# Service Layer
	- compatible with using on Controller


	- Dependency Injections
		 - [RiotGamesApi.AspNetCore.Api CLASS] >> Sync/Async, static/non-static/status/tournament apis (auto generated class)
		 
		 - [RiotGamesApi.AspNetCore.RateLimit.ApiRate CLASS] >> api rate limiter for non-static-api/tournament-api (default: 20 requests in 1 sec, 200 requests in 2 minutes)
		 
		 - [RiotGamesApi.AspNetCore.Interfaces.IApiCache INTERFACE] >> caching static-api (default: false)

# Issues
	- https://github.com/msx752/RiotGamesApi.AspNetCore/issues