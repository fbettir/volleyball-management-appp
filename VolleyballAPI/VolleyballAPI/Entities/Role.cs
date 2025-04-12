using System.Text.Json.Serialization;

namespace VolleyballAPI.Entities
{
  [Flags]
  [JsonConverter(typeof(JsonStringEnumConverter))]  
  public enum Role
  {
    Administrator = 1,
    Coach = 2,
    BasicUser = 4,
    Referee = 8
  }
}
