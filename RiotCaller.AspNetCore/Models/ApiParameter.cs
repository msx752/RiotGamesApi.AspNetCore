using RiotGamesApi.AspNetCore.Enums;

namespace RiotGamesApi.AspNetCore.Models
{
    public class ApiParameter
    {
        /// <summary>
        /// url path parameter for apis 
        /// </summary>
        /// <param name="SubApiType">
        /// Name of UrlPath 
        /// </param>
        /// <param name="value">
        /// value of UrlPath 
        /// </param>
        public ApiParameter(LolApiPath SubApiType, object value)
        {
            this.Type = SubApiType;
            this.Value = value;
        }

        public LolApiPath Type { get; private set; }
        public object Value { get; private set; }
    }
}