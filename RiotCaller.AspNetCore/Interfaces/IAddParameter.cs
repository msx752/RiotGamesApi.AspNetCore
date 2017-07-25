using RiotGamesApi.AspNetCore.Models;

namespace RiotGamesApi.AspNetCore.Interfaces
{
    /// <summary>
    /// url path parameter for apis 
    /// </summary>
    /// <typeparam name="T">
    /// response type of value 
    /// </typeparam>
    public interface IAddParameter<T> where T : new() { IBuild<T> AddParameter(params ApiParameter[] parameters); }
}