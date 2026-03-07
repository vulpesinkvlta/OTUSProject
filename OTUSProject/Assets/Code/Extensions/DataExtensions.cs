using Newtonsoft.Json;

namespace Code.Extensions
{
  public static class DataExtensions
  {
    public static string ToJson(this object obj) => 
      JsonConvert.SerializeObject(obj);

    public static T ToDeserialized<T>(this string json) =>
      JsonConvert.DeserializeObject<T>(json);
  }
}