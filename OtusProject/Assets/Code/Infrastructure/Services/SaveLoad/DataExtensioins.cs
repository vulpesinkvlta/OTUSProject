

using Newtonsoft.Json;

public static class DataExtensioins 
{
    public static string ToJson(this object obj) =>
     JsonConvert.SerializeObject(obj);

    public static T ToDeserialized<T>(this string json) =>
      JsonConvert.DeserializeObject<T>(json);
}
