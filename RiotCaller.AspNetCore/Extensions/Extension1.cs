using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using RiotGamesApi.AspNetCore.Attributes;
using RiotGamesApi.AspNetCore.Builder;
using RiotGamesApi.AspNetCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RiotGamesApi.AspNetCore.Extensions
{
    public static class Extension1
    {
        public static RiotGamesApiUrl AddApi(this RiotGamesApi option, ApiName suffix1, double _version)
        {
            RiotGamesApiUrl sff1 = new RiotGamesApiUrl(suffix1, _version);
            option.RiotGamesApiUrls.Add(sff1);
            return sff1;
        }

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

        public static RiotGamesApiUrl SubApi(this RiotGamesApiUrl option, ApiMiddleName middleType, Type type, params ApiParam[] subApis)
        {
            option.SubUrls.Add(new SubUrl(middleType, subApis, type));
            option.LastSubUrlIndex = option.SubUrls.Count - 1;
            return option;
        }

        /// <summary>
        /// </summary>
        /// <param name="option">
        /// </param>
        /// <param name="queryParameterTypes">
        /// NAME,TYPE 
        /// </param>
        /// <returns>
        /// </returns>
        public static RiotGamesApiUrl HasQueryParameters(this RiotGamesApiUrl option, Dictionary<string, Type> queryParameterTypes)
        {
            try
            {
                if (option.SubUrl != ApiName.StaticData)
                    throw new Exception("QueryParameters only for static-data's api");

                option.SubUrls[option.LastSubUrlIndex].QueryParameterTypes = queryParameterTypes;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return option;
        }

        public static IRiotGamesApiBuilder UseNonStaticApi(this IRiotGamesApiBuilder option, Func<RiotGamesApi, RiotGamesApi> action)
        {
            option.RiotGamesApiOptions.RiotGamesApis[UrlType.NonStatic] = action(new RiotGamesApi(option.RiotGamesApiOptions.NonStaticUrl));
            return option;
        }

        public static IApplicationBuilder UseRiotGamesApi(this IApplicationBuilder app)
        {
            IServiceProvider SProvider = app.ApplicationServices;
            RiotGamesApiSettings.ServiceProvider = SProvider;
            return app;
        }

        public static IRiotGamesApiBuilder UseStaticApi(this IRiotGamesApiBuilder option, Func<RiotGamesApi, RiotGamesApi> action)
        {
            option.RiotGamesApiOptions.RiotGamesApis[UrlType.Static] = action(new RiotGamesApi(option.RiotGamesApiOptions.StaticUrl));
            return option;
        }

        public static IRiotGamesApiBuilder UseStatusApi(this IRiotGamesApiBuilder option, Func<RiotGamesApi, RiotGamesApi> action)
        {
            option.RiotGamesApiOptions.RiotGamesApis[UrlType.Status] = action(new RiotGamesApi(option.RiotGamesApiOptions.StatusUrl));
            return option;
        }
    }
}