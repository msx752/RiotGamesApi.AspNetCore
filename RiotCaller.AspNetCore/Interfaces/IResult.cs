using System;
using RiotGamesApi.AspNetCore.Models;

namespace RiotGamesApi.AspNetCore.Interfaces
{
    public interface IResult<T> where T : new()
    {
        Exception Exception { get; set; }
        bool HasError { get; }
        T Result { get; set; }

        //whether data comes from cache or not
        bool IsCache { get; set; }
    }
}