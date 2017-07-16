using RiotGamesApi.AspNetCore.Interfaces;
using System;

namespace RiotGamesApi.AspNetCore.Models
{
    public class RiotGamesApiResult<T> : IResult<T> where T : new()
    {
        public RiotGamesApiResult(Exception exp)
        {
            this.Exception = exp;
        }

        public RiotGamesApiResult()
        {
        }

        public Exception Exception { get; set; }
        public bool HasError { get { return Exception != null; } }
        public T Result { get; set; }
        public bool IsCache { get; set; } = false;
    }
}