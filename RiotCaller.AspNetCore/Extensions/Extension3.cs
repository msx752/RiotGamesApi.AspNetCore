using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using RiotGamesApi.AspNetCore.Attributes;
using RiotGamesApi.AspNetCore.Enums;

namespace RiotGamesApi.AspNetCore.Extensions
{
    public static class Extension3
    {
        public static bool CompareParameterType(this ApiParameterType enumVal, Type requestValueType)
        {
            var typeInfo = enumVal.GetType().GetTypeInfo();
            var v = typeInfo.DeclaredMembers.First(x => x.Name == enumVal.ToString());
            var attr = v.GetCustomAttribute<ParameterTypeAttribute>();
            if (attr == null)
                throw new Exception("ParameterTypeAttribute not found");
            var t1 = attr.ParameterType;
            var t2 = requestValueType;
            return t1 == t2;
        }

        public static Type GetParameterType(this ApiParameterType enumVal)
        {
            var typeInfo = enumVal.GetType().GetTypeInfo();
            var v = typeInfo.DeclaredMembers.First(x => x.Name == enumVal.ToString());
            var attr = v.GetCustomAttribute<ParameterTypeAttribute>();
            if (attr == null)
                throw new Exception("ParameterTypeAttribute not found");
            return attr.ParameterType;
        }

        public static Type FindParameterType(this ApiParam enumVal)
        {
            var selectedParamX = enumVal.GetStringValue().Split('{')[1].Split('}')[0];
            List<ApiParameterType> array = ((ApiParameterType[])Enum.GetValues(typeof(ApiParameterType))).ToList();
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

        public static UrlType GetUrlType(this ApiName enumVal)
        {
            var typeInfo = enumVal.GetType().GetTypeInfo();
            var v = typeInfo.DeclaredMembers.First(x => x.Name == enumVal.ToString());
            var attr = v.GetCustomAttribute<UrlTypeAttribute>();
            if (attr == null)
                throw new Exception("UrlTypeAttribute not found");
            return attr.ApiType;
        }
    }
}