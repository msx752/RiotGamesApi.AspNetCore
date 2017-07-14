using System;
using System.Collections.Generic;
using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.Extensions;
using RiotGamesApi.AspNetCore.Interfaces;

namespace RiotGamesApi.AspNetCore
{
    public static class RiotGamesApiSettings
    {
        private static IServiceProvider _serviceProvider = null;

        public static IRiotGamesApiOption RiotGamesApiOptions
        {
            get
            {
                return (IRiotGamesApiOption)ServiceProvider.GetService(typeof(IRiotGamesApiOption));
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
                        string @parameters = $"";
                        string @RiotGamesApiParameters = $"";
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
                            @parameters += $", {paramType} {paramName.ToLower()}";

                            @RiotGamesApiParameters += $"new RiotGamesApiParameter(ApiParam.{paramName}, {paramName.ToLower()})";
                            if (i != urlSub.RiotGamesApiSubApiTypes.Length - 1)
                            {
                                @RiotGamesApiParameters += ",\r\n";
                            }
                        }
                        string @method = $"\r\npublic static IResult<{t1}> Get{urlSub.MiddleType}{uniqueParam}(Platform platform{@parameters})\r\n{{";

                        string @apiCall = $"\r\nvar rit = new ApiCall()\r\n" +
                                          $".SelectApi<{t1}>(ApiName.{url.SubUrl})\r\n" +
                                          $".For(ApiMiddleName.{urlSub.MiddleType})\r\n" +
                                          $".AddParameter({@RiotGamesApiParameters})" +
                                          $".Build(platform)\r\n" +
                                          $".Get();";
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
                "using System;\r\nusing System.Collections.Generic;\r\nusing System.ComponentModel;\r\nusing System.Text;\r\nusing RiotGamesApi.AspNetCore.Enums;\r\nusing RiotGamesApi.AspNetCore.RiotApi.Enums;\r\nusing RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.ChampionMastery;\r\nusing RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.League;\r\nusing RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Mastery;\r\nusing RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Match;\r\nusing RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Rune;\r\nusing RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Spectator;\r\nusing RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Summoner;\r\nusing RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Champions;\r\nusing RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Items;\r\nusing RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.LanguageStrings;\r\nusing RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Maps;\r\nusing RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Masteries;\r\nusing RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Profile;\r\nusing RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Realms;\r\nusing RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Runes;\r\nusing RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.SummonerSpell;\r\nusing RiotGamesApi.AspNetCore.RiotApi.StatusEndPoints;\r\nusing MasteryDto = RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Masteries.MasteryDto;\r\nusing RuneDto = RiotGamesApi.AspNetCore.RiotApi.StaticEndPoints.Runes.RuneDto;";

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