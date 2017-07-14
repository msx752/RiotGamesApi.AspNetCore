using RiotGamesApi.AspNetCore.RiotApi.Enums;

using RiotGamesApi.AspNetCore.RiotApi.Enums;

using RiotGamesApi.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.AspNetCore.RiotApi.Extensions
{
    public static class Extensions
    {
        public static string ToUpperFirstLetter(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return string.Empty;
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        public static Platform ToPlatform(this Region enumVal)
        {
            switch (enumVal)
            {
                case Region.tr:
                    return Platform.TR1;

                case Region.ru:
                    return Platform.RU;

                case Region.las:
                    return Platform.LA2;

                case Region.lan:
                    return Platform.LA1;

                case Region.oce:
                    return Platform.OC1;

                case Region.kr:
                    return Platform.KR;

                case Region.na:
                    return Platform.NA1;

                case Region.euw:
                    return Platform.EUW1;

                case Region.br:
                    return Platform.BR1;

                case Region.eune:
                    return Platform.EUN1;

                case Region.jp:
                    return Platform.JP1;

                case Region.pbe:
                    return Platform.PBE1;

                default:
                    return Platform.TR1;
            }
        }

        public static Region ToRegion(this Platform enumVal)
        {
            switch (enumVal)
            {
                case Platform.TR1:
                    return Region.tr;

                case Platform.NA1:
                    return Region.na;

                case Platform.BR1:
                    return Region.br;

                case Platform.RU:
                    return Region.ru;

                case Platform.EUW1:
                    return Region.euw;

                case Platform.KR:
                    return Region.kr;

                case Platform.LA1:
                    return Region.lan;

                case Platform.LA2:
                    return Region.las;

                case Platform.OC1:
                    return Region.oce;

                case Platform.EUN1:
                    return Region.eune;

                case Platform.JP1:
                    return Region.jp;

                case Platform.PBE1:
                    return Region.pbe;

                default:
                    return Region.tr;
            }
        }

        public static Language ToLanguage(this Region enumVal)
        {
            return enumVal.ToPlatform().ToLanguage();
        }

        public static Language ToLanguage(this Platform enumVal)
        {
            switch (enumVal)
            {
                case Platform.TR1:
                    return Language.tr_TR;

                default:
                    return Language.en_US;
            }
        }
    }
}