using System;
using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.Models;
using System.Collections.Generic;

namespace RiotGamesApi.AspNetCore.Interfaces
{
    public interface IProperty<T> where T : new()
    {
        RiotGamesApiUrl ApiList { get; }
        string BaseUrl { get; }
        List<ApiParameter> ParametersWithValue { get; }
        int SelectedApiIndex { get; }
        UrlType UrlType { get; }
        string RequestUrl { get; }
        IResult<T> RiotResult { get; }
        String CacheKey { get; }
    }
}