using System.Text.Json.Serialization;

namespace VolleyballAPI.Entities
{
    [Flags]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Level
    {
        Starter = 1,
        Advanced = 2,
        Experienced = 4,
        BP1 = 8,
        BP2 = 16
    }
}
