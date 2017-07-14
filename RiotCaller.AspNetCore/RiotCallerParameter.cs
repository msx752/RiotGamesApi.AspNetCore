using RiotGamesApi.AspNetCore.Enums;

namespace RiotGamesApi.AspNetCore
{
    public class RiotGamesApiParameter
    {
        public RiotGamesApiParameter(ApiParam SubApiType, object value)
        {
            this.Type = SubApiType;
            this.Value = value;
        }

        public ApiParam Type { get; private set; }
        public object Value { get; private set; }
    }
}