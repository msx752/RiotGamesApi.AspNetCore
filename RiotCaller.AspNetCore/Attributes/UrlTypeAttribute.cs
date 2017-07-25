using RiotGamesApi.AspNetCore.Enums;
using System;

namespace RiotGamesApi.AspNetCore.Attributes
{
    /// <summary>
    /// type of request url (static,nonstatic,status or tournament) 
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class UrlTypeAttribute : Attribute
    {
        private readonly LolUrlType value;

        public UrlTypeAttribute(LolUrlType _apitype)
        {
            this.value = _apitype;
        }

        public LolUrlType ApiType { get { return value; } }

        public override string ToString()
        {
            return ApiType.ToString();
        }
    }
}