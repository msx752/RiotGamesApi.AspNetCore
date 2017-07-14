using RiotGamesApi.AspNetCore.Enums;
using System;

namespace RiotGamesApi.AspNetCore.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class UrlTypeAttribute : Attribute
    {
        private readonly UrlType value;

        public UrlTypeAttribute(UrlType _apitype)
        {
            this.value = _apitype;
        }

        public UrlType ApiType { get { return value; } }

        public override string ToString()
        {
            return ApiType.ToString();
        }
    }
}