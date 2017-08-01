﻿using RiotGamesApi.AspNetCore.Enums;
using System;

namespace RiotGamesApi.AspNetCore.Attributes
{
    /// <summary>
    /// type of request url (static,nonstatic,status or tournament) 
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class UrlTypeAttribute : Attribute
    {
        public UrlTypeAttribute(LolUrlType _apitype)
        {
            this.ApiType = _apitype;
        }

        public LolUrlType ApiType { get; }

        /// <inheritdoc />
        ///
        public override string ToString()
        {
            return ApiType.ToString();
        }
    }
}