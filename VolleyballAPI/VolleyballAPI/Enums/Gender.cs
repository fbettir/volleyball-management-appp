using System.Text.Json.Serialization;

namespace VolleyballAPI.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Gender
    {
        Man = 0,
        Woman = 1,
        Other = 2,
    }
}
