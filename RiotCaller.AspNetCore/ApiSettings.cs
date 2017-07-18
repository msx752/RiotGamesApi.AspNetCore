using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.Extensions;
using RiotGamesApi.AspNetCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Caching.Memory;
using RiotGamesApi.AspNetCore.Cache;
using RiotGamesApi.AspNetCore.Models;
using RiotGamesApi.AspNetCore.RiotApi.Enums;

namespace RiotGamesApi.AspNetCore
{
    public static class ApiSettings
    {
        private static IServiceProvider _serviceProvider = null;

        public static IApiOption ApiOptions
        {
            get
            {
                return (IApiOption)ServiceProvider.GetService(typeof(IApiOption));
            }
        }

        internal static IMemoryCache MemoryCache
        {
            get
            {
                return (IMemoryCache)ServiceProvider.GetService(typeof(IMemoryCache));
            }
        }

        public static IApiCache ApiCache
        {
            get
            {
                return (IApiCache)ServiceProvider.GetService(typeof(IApiCache));
            }
        }

        public static IServiceProvider ServiceProvider
        {
            get { return _serviceProvider; }
            set
            {
                if (_serviceProvider == null)
                    _serviceProvider = value;
            }
        }

        #region api class generetor

        private static bool IsDigitType(string value)
        {
            if (value.StartsWith("Int") ||
                value.StartsWith("long") ||
                value.StartsWith("byte") ||
                value.Equals("int") ||
                value.StartsWith("decimal") ||
                value.StartsWith("double"))
            {
                return true;
            }

            return false;
        }

        public static string GenerateApiClass()
        {
            string nameOfNs = typeof(ApiSettings).Namespace;
            Dictionary<LolUrlType, string> Classes = new Dictionary<LolUrlType, string>();
            Dictionary<LolUrlType, Models.RiotGamesApi> TournamenApis = new Dictionary<LolUrlType, Models.RiotGamesApi>();
            foreach (var selected in ApiOptions.RiotGamesApis)
            {
                var urlType = selected.Key;
                //if (urlType == LolUrlType.Tournament)
                //{
                //    TournamenApis.Add(selected.Key, selected.Value);
                //    continue;
                //}
                string @class = $"\r\n//\"{selected.Value.ApiUrl}\r\n" +
                                $"public static class {urlType.ToString()}\r\n{{";
                foreach (var url in selected.Value.RiotGamesApiUrls)
                {
                    string @class2 = $"\r\n//\"{url.ApiName}/{url.Version}\r\n" +
                                     $"public static class {url.ApiName}_{url.Version.Replace(".", "_")}\r\n{{";
                    foreach (var urlSub in url.ApiMethods)
                    {
                        TypeInfo tinf = urlSub.ReturnValueType.GetTypeInfo();
                        string t1_ns = urlSub.ReturnValueType.Namespace;
                        var t1 = "";
                        if (urlSub.ReturnValueType.Name == "List`1")
                        {
                            string t2 =
                                urlSub.ReturnValueType.FullName.Split(new string[] { "[[" }, StringSplitOptions.None)[1]
                                    .Split(new string[] { "," }, StringSplitOptions.None)[0];
                            t1 = $"List<{t2}>";
                        }
                        else
                        {
                            if (tinf.IsClass || tinf.IsInterface)
                            {
                                t1 = $"{t1_ns}.{urlSub.ReturnValueType.Name}";
                            }
                            else
                            {
                                t1 = $"{urlSub.ReturnValueType.Name}";
                            }
                        }
                        string @parameters = "";
                        string @RiotGamesApiParameters = "";
                        LolApiPath? uniqueParam = null;
                        for (int i = 0; i < urlSub.RiotGamesApiPaths.Length; i++)
                        {
                            var selectedParam = urlSub.RiotGamesApiPaths[i];
                            if (!uniqueParam.HasValue)
                            {
                                uniqueParam = selectedParam;
                            }
                            string paramName = selectedParam.ToString();

                            string paramType = selectedParam.FindParameterType().Name;
                            @parameters += $", {paramType} _{paramName}";

                            @RiotGamesApiParameters += $"new {nameof(ApiParameter)}({nameof(LolApiPath)}.{paramName}, _{paramName})";
                            if (i != urlSub.RiotGamesApiPaths.Length - 1)
                            {
                                @RiotGamesApiParameters += ",\r\n";
                            }
                        }
                        string @useCacheMethod = "";
                        if (selected.Key == LolUrlType.Static)//useCache parameter
                        {
                            @parameters += ", bool _useCache = false";
                            @useCacheMethod = $".UseCache(_useCache)\r\n";
                        }
                        string @queryParameters = "";
                        string @optionalParameters = "new Dictionary<string, object>()\r\n{\r\n";
                        foreach (var query in urlSub.TypesOfQueryParameter)
                        {
                            string paramName = $"_{query.Key}";
                            string paramType = query.Value.Name;
                            if (paramType == "List`1")
                            {
                                string paramType_t2 =
                                    query.Value.FullName.Split(new string[] { "[[" }, StringSplitOptions.None)[1]
                                        .Split(new string[] { "," }, StringSplitOptions.None)[0];
                                paramType = $"List<{paramType_t2}>";
                            }
                            //string.Join(\"&tags=\", tags)
                            string @defaultParamValue = paramType == "Boolean" ? "false" : "null";
                            if (IsDigitType(paramType))
                            {
                                paramType += "?";
                            }
                            @queryParameters += $", {paramType} {paramName} = {@defaultParamValue}";
                            if (paramType.StartsWith("List<"))
                            {
                                @optionalParameters += $"{{\"{query.Key}\",string.Join(\"&tags=\", {paramName}  ?? new {paramType}()) }},\r\n";
                            }
                            else
                            {
                                if (paramType == "Boolean")
                                {
                                    @optionalParameters += $"{{\"{query.Key}\",{paramName}.ToString().ToLower() }},\r\n";
                                }
                                else
                                {
                                    @optionalParameters += $"{{\"{query.Key}\",{paramName} }},\r\n";
                                }
                            }
                        }
                        @optionalParameters += "\r\n}\r\n";
                        if (!string.IsNullOrWhiteSpace(@queryParameters))
                        {
                            @parameters += @queryParameters;
                        }
                        else
                        {
                            @optionalParameters = "";
                        }
                        string platformName = "";
                        if (urlType == LolUrlType.Tournament)
                        {
                            platformName = nameof(PhysicalRegion);
                            if (urlSub.RequestType != ApiMethodType.Get)
                            {
                                string bodyParam = $"_{urlSub.BodyValueType.Name.ToLower()}";
                                string @mergedParameters = $",{urlSub.BodyValueType.Namespace}.{urlSub.BodyValueType.Name} {bodyParam}";
                                if (urlSub.IsBodyRequired)
                                {
                                    var cacheParams = @parameters;
                                    mergedParameters += cacheParams;
                                    @parameters = mergedParameters;
                                }
                                else
                                {
                                    @parameters += $"{mergedParameters} = null";
                                }
                                if (@optionalParameters.Length > 0)
                                    @optionalParameters += ",";
                                optionalParameters += bodyParam;
                            }
                        }
                        else
                        {
                            platformName = nameof(ServicePlatform);
                        }
                        string @method = $"\r\npublic static {nameOfNs}.Interfaces.IResult<{t1}> {urlSub.RequestType}{urlSub.ApiMethodName}{uniqueParam}({platformName} platform{@parameters})\r\n{{";

                        string @apiCall = $"\r\n{nameOfNs}.Interfaces.IResult<{t1}> rit = new {nameof(ApiCall)}()\r\n" +
                                          $".SelectApi<{t1}>({nameof(LolApiName)}.{url.ApiName})\r\n" +
                                          $".For({nameof(LolApiMethodName)}.{urlSub.ApiMethodName})\r\n" +
                                          $".AddParameter({@RiotGamesApiParameters})\r\n" +
                                          ".Build(platform)\r\n" +
                                          @useCacheMethod +
                                          $".{urlSub.RequestType}({@optionalParameters});";
                        @method += @apiCall;
                        @method += "\r\nreturn rit;\r\n}";
                        class2 += @method;
                    }
                    @class2 += "\r\n}";
                    @class += @class2;
                }

                @class += "\r\n}\r\n";
                Classes[urlType] = @class;
            }
            string @references = Reference(nameOfNs);
            string @namespaces = @references + $"\r\nnamespace {nameOfNs}\r\n{{";
            string @apiClass = $"\r\n// ReSharper disable InconsistentNaming\r\n" +
                               $"//AUTO GENERATED CLASS DO NOT MODIFY\r\n " +
                               $"public static class Api\r\n{{\r\n";

            foreach (var clss in Classes)
            {
                @apiClass += $"//{clss.Key} API" + clss.Value;
            }
            @apiClass += "//\r\n}\r\n";
            @namespaces += apiClass;
            @namespaces += "//\r\n}\r\n";
            Classes.Clear();
            return @namespaces;
        }

        private static string Reference(string Namespace)
        {
            string @references = $"using {Namespace}.Enums;\r\n" +
                                 $"using {Namespace}.Models;\r\n" +
                                 $"using {Namespace}.RiotApi.Enums;\r\n" +
                                 $"using System;\r\nusing System.Collections.Generic;";

            return @references;
        }

        #endregion api class generetor
    }
}