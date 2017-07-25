using System;

namespace RiotGamesApi.AspNetCore.Attributes
{
    /// <summary>
    /// valueType of Url Path Parameter 
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class ParameterTypeAttribute : Attribute
    {
        private readonly Type _parameterType;

        public ParameterTypeAttribute(Type _apitype)
        {
            this._parameterType = _apitype;
        }

        public Type ParameterType { get { return _parameterType; } }

        public override string ToString()
        {
            return ParameterType.ToString();
        }
    }
}