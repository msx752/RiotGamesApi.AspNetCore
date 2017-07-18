using System.Collections.Generic;
using RiotGamesApi.AspNetCore.Models;

namespace RiotGamesApi.AspNetCore.Interfaces
{
    public interface IRequestMethod<T> where T : new()
    {
        string RequestUrl { get; }

        /// <summary>
        /// before using cache set EnableStaticApiCaching to True 
        /// </summary>
        /// <param name="useCache">
        /// </param>
        /// <returns>
        /// </returns>
        IRequestMethod<T> UseCache(bool useCache = false);

        IResult<T> Get(Dictionary<string, object> optionalParameters = null);

        IResult<T> Put(object bodyParameter = null);

        IResult<T> Post(object bodyParameter = null);

        IResult<T> Post(Dictionary<string, object> optionalParameters = null, object bodyParameter = null);
    }
}