using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.AspNetCore.Models
{
    public class RiotGamesApiException : Exception
    {
        public RiotGamesApiException()
        {
        }

        public RiotGamesApiException(string message) : base(message)
        {
        }

        public RiotGamesApiException(string message, Exception exception) : base(message, exception)
        {
        }
    }
}