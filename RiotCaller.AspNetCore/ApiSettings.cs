using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.Extensions;
using RiotGamesApi.AspNetCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public static string GenerateApiClass()
        {
            Dictionary<LolUrlType, string> Classes = new Dictionary<LolUrlType, string>();
            Dictionary<LolUrlType, Models.RiotGamesApi> TournamenApis = new Dictionary<LolUrlType, Models.RiotGamesApi>();
            foreach (var selected in ApiOptions.RiotGamesApis)
            {
                var urlType = selected.Key;
                if (urlType == LolUrlType.Tournament)
                {
                    TournamenApis.Add(selected.Key, selected.Value);
                    continue;
                }
                string @class = $"\r\n//\"{selected.Value.ApiUrl}\r\n" +
                                $"public static class {urlType.ToString()}\r\n{{";
                foreach (var url in selected.Value.RiotGamesApiUrls)
                {
                    string @class2 = $"\r\n//\"{url.ApiName}/{url.Version}\r\n" +
                                     $"public static class {url.ApiName}_{url.Version.Replace(".", "_")}\r\n{{";
                    foreach (var urlSub in url.ApiMethods)
                    {
                        var t1 = urlSub.ReturnValueType.Name;
                        if (t1 == "List`1")
                        {
                            string t2 =
                                urlSub.ReturnValueType.FullName.Split(new string[] { "[[" }, StringSplitOptions.None)[1]
                                    .Split(new string[] { "," }, StringSplitOptions.None)[0];
                            t1 = $"List<{t2}>";
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
                        string @optionalParameters = "new Dictionary<string, string>()\r\n{\r\n";
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
                        string @method = $"\r\npublic static IResult<{t1}> Get{urlSub.ApiMethodName}{uniqueParam}({nameof(ServicePlatform)} platform{@parameters})\r\n{{";

                        string @apiCall = $"\r\nIResult<{t1}> rit = new {nameof(ApiCall)}()\r\n" +
                                          $".SelectApi<{t1}>({nameof(LolApiName)}.{url.ApiName})\r\n" +
                                          $".For({nameof(LolApiMethodName)}.{urlSub.ApiMethodName})\r\n" +
                                          $".AddParameter({@RiotGamesApiParameters})\r\n" +
                                          ".Build(platform)\r\n" +
                                          @useCacheMethod +
                                          $".Get({@optionalParameters});";
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
            string nameOfNs = typeof(ApiSettings).Namespace;
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
            string @references =
                $"using {Namespace}.Enums;\r\n" +
                $"using {Namespace}.Interfaces;\r\n" +
                $"using {Namespace}.Models;\r\n" +
                $"using {Namespace}.RiotApi.Enums;\r\n" +
                $"using {Namespace}.RiotApi.NonStaticEndPoints.ChampionMastery;\r\n" +
                $"using {Namespace}.RiotApi.NonStaticEndPoints.League;\r\n" +
                $"using {Namespace}.RiotApi.NonStaticEndPoints.Mastery;\r\n" +
                $"using {Namespace}.RiotApi.NonStaticEndPoints.Match;\r\n" +
                $"using {Namespace}.RiotApi.NonStaticEndPoints.Rune;\r\n" +
                $"using {Namespace}.RiotApi.NonStaticEndPoints.Spectator;\r\n" +
                $"using {Namespace}.RiotApi.NonStaticEndPoints.Summoner;\r\n" +
                $"using {Namespace}.RiotApi.StaticEndPoints.Champions;\r\n" +
                $"using {Namespace}.RiotApi.StaticEndPoints.Items;\r\n" +
                $"using {Namespace}.RiotApi.StaticEndPoints.LanguageStrings;\r\n" +
                $"using {Namespace}.RiotApi.StaticEndPoints.Maps;\r\n" +
                $"using {Namespace}.RiotApi.StaticEndPoints.Masteries;\r\n" +
                $"using {Namespace}.RiotApi.StaticEndPoints.Profile;\r\n" +
                $"using {Namespace}.RiotApi.StaticEndPoints.Realms;\r\n" +
                $"using {Namespace}.RiotApi.StaticEndPoints.Runes;\r\n" +
                $"using {Namespace}.RiotApi.StaticEndPoints.SummonerSpell;\r\n" +
                $"using {Namespace}.RiotApi.StatusEndPoints;\r\n" +
                $"using System;\r\n" +
                $"using System.Collections.Generic;\r\n" +
                $"using System.ComponentModel;\r\n" +
                $"using System.Text;\r\n" +
                $"using MasteryDto = {Namespace}.RiotApi.StaticEndPoints.Masteries.MasteryDto;\r\n" +
                $"using RuneDto = {Namespace}.RiotApi.StaticEndPoints.Runes.RuneDto;";

            return @references;
        }

        #endregion api class generetor
    }
}