using System;

namespace RiotGamesApi.AspNetCore.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class StringValueAttribute : Attribute
    {
        private readonly string _value;

        public StringValueAttribute(string value)
        {
            this._value = value;
        }

        public string StringValue { get { return _value; } }

        public override string ToString()
        {
            return StringValue.ToString();
        }
    }
}