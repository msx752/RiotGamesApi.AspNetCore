using System.Collections.Generic;
using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.Models;

namespace RiotGamesApi.AspNetCore.Interfaces
{
    public interface IProperty<T> where T : new()
    {
        RiotGamesApiUrl ApiList { get; }
        string BaseUrl { get; }
        List<ApiParameter> ParametersWithValue { get; }
        int SelectedApiIndex { get; }
        UrlType UrlType { get; }
    }
}