using System;

namespace RiotGamesApi.AspNetCore.Interfaces
{
    public interface IResult<T> where T : new()
    {
        Exception Exception { get; set; }
        bool HasError { get; }
        T Result { get; set; }
    }
}