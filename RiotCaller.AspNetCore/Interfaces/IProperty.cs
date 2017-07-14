using System.Collections.Generic;
using RiotGamesApi.AspNetCore.Enums;

namespace RiotGamesApi.AspNetCore.Interfaces
{
    public interface IProperty<T> where T : new()
    {
        RiotGamesApiUrl ApiList { get; }
        string BaseUrl { get; }
        List<RiotGamesApiParameter> ParametersWithValue { get; }
        int SelectedApiIndex { get; }
        UrlType UrlType { get; }
    }
}