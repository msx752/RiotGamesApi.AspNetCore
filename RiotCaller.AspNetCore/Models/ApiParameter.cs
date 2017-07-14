using RiotGamesApi.AspNetCore.Enums;

namespace RiotGamesApi.AspNetCore.Models
{
    public class ApiParameter
    {
        public ApiParameter(ApiParam SubApiType, object value)
        {
            this.Type = SubApiType;
            this.Value = value;
        }

        public ApiParam Type { get; private set; }
        public object Value { get; private set; }
    }
}