using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RiotGamesApi.AspNetCore.RiotApi.Extensions;

namespace RiotGamesApi.AspNetCore.RiotApi.Converters
{
    public class ChampionTagConverter<TEnum> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(List<string>).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token.Values<string>() == null) return null;
            var liste = token.Values<string>().ToList();
            liste.ForEach(i =>
            {
                if (i.IndexOf(",") != -1)
                {
                    string[] splited = i.Split(',');
                    for (int j = 0; j < splited.Length; j++)
                    {
                        splited[j] = splited[j].ToUpperFirstLetter();
                    }
                    liste.AddRange(splited);
                    liste.Remove(i);
                }
            });
            return liste.Select(x => (TEnum)Enum.Parse(typeof(TEnum), x)).ToList();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var liste = (value as List<TEnum>).Select(p => p.ToString()).ToList();
            serializer.Serialize(writer, liste);
        }
    }
}