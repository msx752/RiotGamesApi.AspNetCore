using RiotGamesApi.AspNetCore.Enums;

namespace RiotGamesApi.AspNetCore.Models
{
    public class ApiParameter
    {
        public ApiParameter(LolApiPath SubApiType, object value)
        {
            this.Type = SubApiType;
            this.Value = value;
        }

        public LolApiPath Type { get; private set; }
        public object Value { get; private set; }
    }
}