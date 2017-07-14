using RiotGamesApi.AspNetCore.Models;

namespace RiotGamesApi.AspNetCore.Interfaces
{
    public interface IAddParameter<T> where T : new() { IBuild<T> AddParameter(params RiotGamesApiParameter[] parameters); }
}