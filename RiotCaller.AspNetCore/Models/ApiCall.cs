using System;
using System.Linq;
using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.Extensions;
using RiotGamesApi.AspNetCore.Interfaces;

namespace RiotGamesApi.AspNetCore.Models
{
    public class ApiCall
    {
        public IFor<T> SelectApi<T>(ApiName apiType, double version = 3.0) where T : new()
        {
            RiotGamesApiRequest<T> rit = new RiotGamesApiRequest<T>();
            rit.UrlType = apiType.GetUrlType();
            rit.BaseUrl = RiotGamesApiSettings.RiotGamesApiOptions.RiotGamesApis[rit.UrlType].ApiUrl;
            rit.ApiList = RiotGamesApiSettings.RiotGamesApiOptions.RiotGamesApis[rit.UrlType].RiotGamesApiUrls
                .FirstOrDefault(p => p.SubUrl == apiType && p.CompareVersion(version));
            if (rit.ApiList == null)
                throw new Exception($"{rit.UrlType} is not defined in RiotGamesApiBuilder or selected version:{version} is not defined");

            return rit;
        }
    }
}