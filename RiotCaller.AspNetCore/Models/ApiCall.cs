using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.Extensions;
using RiotGamesApi.AspNetCore.Interfaces;
using System;
using System.Linq;

namespace RiotGamesApi.AspNetCore.Models
{
    /// <summary>
    /// easy api requester 
    /// </summary>
    public class ApiCall
    {
        /// <summary>
        /// easy api requester 
        /// </summary>
        /// <typeparam name="T">
        /// returns Type of Value 
        /// </typeparam>
        /// <param name="apiType">
        /// specify api type version 
        /// </param>
        /// <param name="version">
        /// specify api version 
        /// </param>
        /// <returns>
        /// </returns>
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