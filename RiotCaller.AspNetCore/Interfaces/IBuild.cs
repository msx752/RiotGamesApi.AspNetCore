using RiotGamesApi.AspNetCore.RiotApi.Enums;

namespace RiotGamesApi.AspNetCore.Interfaces
{
    public interface IBuild<T> where T : new()
    {
        IRequestMethod<T> Build(ServicePlatform platform);

        IRequestMethod<T> Build(PhysicalRegion platform);
    }
}