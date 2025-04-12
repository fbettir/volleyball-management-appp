using System.Text.Json.Serialization;

namespace VolleyballAPI.Entities
{
    [Flags]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Post
  {
    OutsideHitter = 1,
    Setter = 2,
    Libero = 4,
    OppositeHitter = 8,
    MiddleBlocker = 16
  }
}
