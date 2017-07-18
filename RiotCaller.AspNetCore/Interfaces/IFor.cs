using RiotGamesApi.AspNetCore.Enums;

namespace RiotGamesApi.AspNetCore.Interfaces
{
    public interface IFor<T> where T : new() { IAddParameter<T> For(LolApiMethodName middleType); }
}