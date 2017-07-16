namespace RiotGamesApi.AspNetCore.Interfaces
{
    public interface IApiCache
    {
        void Add<T>(IProperty<T> data) where T : new();
        bool Get<T>(IProperty<T> data, out T cachedData) where T : new();
        void Remove<T>(IProperty<T> data) where T : new();
    }
}