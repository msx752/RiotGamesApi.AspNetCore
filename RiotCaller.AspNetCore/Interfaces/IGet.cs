using System.Collections.Generic;

namespace RiotGamesApi.AspNetCore.Interfaces
{
    public interface IGet<T> where T : new()
    {
        string RequestUrl { get; }

        /// <summary>
        /// before using cache set EnableStaticApiCaching to True 
        /// </summary>
        /// <param name="useCache">
        /// </param>
        /// <returns>
        /// </returns>
        IGet<T> UseCache(bool useCache = false);

        IResult<T> Get(Dictionary<string, string> optionalParameters = null);
    }
}