using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.Extensions;
using RiotGamesApi.AspNetCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using RiotGamesApi.AspNetCore.Models;
using RiotGamesApi.AspNetCore.RiotApi.Enums;

namespace RiotGamesApi.AspNetCore
{
    public static class RiotGamesApiSettings
    {
        private static IServiceProvider _serviceProvider = null;

        public static IApiOption RiotGamesApiOptions
        {
            get
            {
                return (IApiOption)ServiceProvider.GetService(typeof(IApiOption));
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

        /// <summary>
        /// fun for developing, after coding, run this method and change with into Api.cs file 
        /// </summary>
        public static string GenerateApiClass()
        {
            List<string> Classes = new List<string>();
            foreach (var selected in RiotGamesApiOptions.RiotGamesApis)
            {
                var urlType = selected.Key;
                string @class = $"\r\n//\"{selected.Value.ApiUrl}\r\npublic static class {urlType.ToString()}\r\n{{";
                foreach (var url in selected.Value.RiotGamesApiUrls)
                {
                    string @class2 = $"\r\n//\"{url.SubUrl}/{url.Version}\r\npublic static class {url.SubUrl}_{url.Version.Replace(".", "_")}\r\n{{";
                    foreach (var urlSub in url.SubUrls)
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
                        ApiParam? uniqueParam = null;
                        for (int i = 0; i < urlSub.RiotGamesApiSubApiTypes.Length; i++)
                        {
                            var selectedParam = urlSub.RiotGamesApiSubApiTypes[i];
                            if (!uniqueParam.HasValue)
                            {
                                uniqueParam = selectedParam;
                            }
                            string paramName = selectedParam.ToString();

                            string paramType = selectedParam.FindParameterType().Name;
                            @parameters += $", {paramType} _{paramName}";

                            @RiotGamesApiParameters += $"new {nameof(ApiParameter)}({nameof(ApiParam)}.{paramName}, _{paramName})";
                            if (i != urlSub.RiotGamesApiSubApiTypes.Length - 1)
                            {
                                @RiotGamesApiParameters += ",\r\n";
                            }
                        }
                        string @queryParameters = "";
                        string @optionalParameters = "new Dictionary<string, string>()\r\n{\r\n";
                        foreach (var query in urlSub.QueryParameterTypes)
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
                        string @method = $"\r\npublic static IResult<{t1}> Get{urlSub.MiddleType}{uniqueParam}({nameof(Platform)} platform{@parameters})\r\n{{";

                        string @apiCall = $"\r\nvar rit = new {nameof(ApiCall)}()\r\n" +
                                          $".SelectApi<{t1}>({nameof(ApiName)}.{url.SubUrl})\r\n" +
                                          $".For({nameof(ApiMiddleName)}.{urlSub.MiddleType})\r\n" +
                                          $".AddParameter({@RiotGamesApiParameters})\r\n" +
                                          $".Build(platform)\r\n" +
                                          $".Get({@optionalParameters});";
                        @method += @apiCall;
                        @method += "\r\nreturn rit;\r\n}";
                        class2 += @method;
                    }
                    @class2 += "\r\n}";
                    @class += @class2;
                }

                @class += "\r\n}\r\n";
                Classes.Add(@class);
            }
            string @references =
                "using RiotGamesApi.AspNetCore.Enums;\r\nusing RiotGamesApi.AspNetCore.Interfaces;\r\nusing RiotGamesApi.AspNetCore.Models;\r\nusing RiotGamesApi.AspNetCore.RiotApi.Enums;\r\nusing RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.ChampionMastery;\r\nusing RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League;\r\nusing RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Mastery;\r\nusing RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Match;\r\nusing RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Rune;\r\nusing RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Spectator;\r\nusing RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Summoner;\r\nusing RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Champions;\r\nusing RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Items;\r\nusing RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.LanguageStrings;\r\nusing RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Maps;\r\nusing RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Masteries;\r\nusing RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Profile;\r\nusing RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Realms;\r\nusing RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Runes;\r\nusing RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.SummonerSpell;\r\nusing RiotGamesApi.AspNetCore.RiotApi.StatusEndPoints;\r\nusing System;\r\nusing System.Collections.Generic;\r\nusing System.ComponentModel;\r\nusing System.Text;\r\nusing MasteryDto = RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Masteries.MasteryDto;\r\nusing RuneDto = RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Runes.RuneDto;";

            string @namespaces = @references + "\r\nnamespace RiotGamesApi.AspNetCore\r\n{";
            string @apiClass = $"\r\n// ReSharper disable InconsistentNaming\r\n//AUTO GENERATED CLASS DO NOT MODIFY\r\n public static class Api\r\n{{\r\n";
            for (int i = 0; i < Classes.Count; i++)
            {
                @apiClass += $"//Class{(i + 1)}\r\n\r\n" + Classes[i];
            }
            @apiClass += "//\r\n}\r\n";
            @namespaces += apiClass;
            @namespaces += "//\r\n}\r\n";
            Classes.Clear();
            return @namespaces;
        }

        #endregion api class generetor
    }
}