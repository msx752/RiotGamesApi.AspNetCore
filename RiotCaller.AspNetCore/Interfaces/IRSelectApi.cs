using RiotGamesApi.AspNetCore.Enums;

namespace RiotGamesApi.AspNetCore.Interfaces
{
    public interface IRSelectApi<T> where T : new() { IFor<T> SelectApi(ApiName apiType, double version = 3.0); }
}