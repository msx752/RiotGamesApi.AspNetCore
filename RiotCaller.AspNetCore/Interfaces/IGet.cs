using System.Collections.Generic;

namespace RiotGamesApi.AspNetCore.Interfaces
{
    public interface IGet<T> where T : new()
    {
        string RequestUrl { get; }

        IResult<T> Get(Dictionary<string, string> optionalParameters = null);
    }
}