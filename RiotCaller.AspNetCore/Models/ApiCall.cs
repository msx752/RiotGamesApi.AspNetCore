using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.Extensions;
using RiotGamesApi.AspNetCore.Interfaces;
using System.Linq;
using static RiotGamesApi.AspNetCore.ApiSettings;

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
        /// <exception cref="RiotGamesApiException">
        /// Condition. 
        /// </exception>
        public IFor<T> SelectApi<T>(LolApiName apiType, double version = 3.0) where T : new()
        {
            var rit = new LolApiRequest<T> { UrlType = apiType.GetUrlType() };
            rit.BaseUrl = ApiOptions.RiotGamesApis[rit.UrlType].ApiUrl;
            rit.ApiList = ApiOptions.RiotGamesApis[rit.UrlType].RiotGamesApiUrls
                .FirstOrDefault(p => p.ApiName == apiType && p.CompareVersion(version));
            if (rit.ApiList == null)
                throw new RiotGamesApiException($"{rit.UrlType} is not defined in RiotGamesApiBuilder or selected version:{version} is not defined");

            return rit;
        }
    }
}