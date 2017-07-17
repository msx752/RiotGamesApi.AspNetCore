using RiotGamesApi.AspNetCore.RiotApi.Enums;

namespace RiotGamesApi.AspNetCore.Interfaces
{
    public interface IBuild<T> where T : new()
    {
        IGet<T> Build(Platform platform);

        //IGet<T> Build(PhysicalRegion platform);
    }
}