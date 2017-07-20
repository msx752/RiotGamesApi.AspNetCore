using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.Extensions;
using RiotGamesApi.AspNetCore.Interfaces;
using System;
using System.Linq;

namespace RiotGamesApi.AspNetCore.Models
{
    public class ApiCall
    {
        public IFor<T> SelectApi<T>(LolApiName apiType, double version = 3.0) where T : new()
        {
            LolApiRequest<T> rit = new LolApiRequest<T>();
            rit.UrlType = apiType.GetUrlType();
            rit.BaseUrl = ApiSettings.ApiOptions.RiotGamesApis[rit.UrlType].ApiUrl;
            rit.ApiList = ApiSettings.ApiOptions.RiotGamesApis[rit.UrlType].RiotGamesApiUrls
                .FirstOrDefault(p => p.ApiName == apiType && p.CompareVersion(version));
            if (rit.ApiList == null)
                throw new RiotGamesApiException($"{rit.UrlType} is not defined in RiotGamesApiBuilder or selected version:{version} is not defined");

            return rit;
        }
    }
}