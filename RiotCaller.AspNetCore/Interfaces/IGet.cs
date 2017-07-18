using System.Collections.Generic;
using System.Threading.Tasks;
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

        Task<IResult<T>> GetAsync(Dictionary<string, object> optionalParameters = null);

        IResult<T> Get(Dictionary<string, object> optionalParameters = null);

        IResult<T> Put(object bodyParameter = null);

        Task<IResult<T>> PutAsync(object bodyParameter = null);

        IResult<T> Post(object bodyParameter = null);

        Task<IResult<T>> PostAsync(object bodyParameter = null);

        Task<IResult<T>> PostAsync(Dictionary<string, object> optionalParameters = null, object bodyParameter = null);

        IResult<T> Post(Dictionary<string, object> optionalParameters = null, object bodyParameter = null);
    }
}