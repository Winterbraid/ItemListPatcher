using ItemListPatcher.Parameters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace ItemListPatcher
{
  internal class ParameterConverter : JsonConverter
  {
    public override bool CanConvert(Type objectType)
    {
      return objectType == typeof(Parameter);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
      Parameter parameter = existingValue as Parameter;
      parameter.value = JToken.Load(reader);

      return parameter;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
      Parameter parameter = value as Parameter;
      JToken.FromObject(parameter.value).WriteTo(writer);
    }
  }
}
