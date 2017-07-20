using RiotGamesApi.AspNetCore.Attributes;
using RiotGamesApi.AspNetCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using RiotGamesApi.AspNetCore.Models;

namespace RiotGamesApi.AspNetCore.Extensions
{
    public static class Extension3
    {
        public static bool CompareParameterType(this LolParameterType enumVal, Type requestValueType)
        {
            var typeInfo = enumVal.GetType().GetTypeInfo();
            var v = typeInfo.DeclaredMembers.First(x => x.Name == enumVal.ToString());
            var attr = v.GetCustomAttribute<ParameterTypeAttribute>();
            if (attr == null)
                throw new RiotGamesApiException("ParameterTypeAttribute not found");
            var t1 = attr.ParameterType;
            var t2 = requestValueType;
            return t1 == t2;
        }

        public static Type GetParameterType(this LolParameterType enumVal)
        {
            var typeInfo = enumVal.GetType().GetTypeInfo();
            var v = typeInfo.DeclaredMembers.First(x => x.Name == enumVal.ToString());
            var attr = v.GetCustomAttribute<ParameterTypeAttribute>();
            if (attr == null)
                throw new RiotGamesApiException("ParameterTypeAttribute not found");
            return attr.ParameterType;
        }

        public static Type FindParameterType(this LolApiPath enumVal)
        {
            var selectedParamX = enumVal.GetStringValue().Split('{')[1].Split('}')[0];
            List<LolParameterType> array = ((LolParameterType[])Enum.GetValues(typeof(LolParameterType))).ToList();
            var found = array.FindIndex(p => String.Compare(p.ToString(), selectedParamX, StringComparison.OrdinalIgnoreCase) == 0);
            if (found > -1)
                return array[found].GetParameterType();
            else
                return null;
        }

        public static string GetStringValue(this Enum enumVal)
        {
            var typeInfo = enumVal.GetType().GetTypeInfo();
            var v = typeInfo.DeclaredMembers.First(x => x.Name == enumVal.ToString());
            var attr = v.GetCustomAttribute<StringValueAttribute>();
            if (attr == null)
                return enumVal.ToString().ToLower();
            return attr.StringValue;
        }

        public static LolUrlType GetUrlType(this LolApiName enumVal)
        {
            var typeInfo = enumVal.GetType().GetTypeInfo();
            var v = typeInfo.DeclaredMembers.First(x => x.Name == enumVal.ToString());
            var attr = v.GetCustomAttribute<UrlTypeAttribute>();
            if (attr == null)
                throw new RiotGamesApiException("UrlTypeAttribute not found");
            return attr.ApiType;
        }
    }
}