using System.Text.Json.Serialization;

namespace VolleyballAPI.Entities
{
    [Flags]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MatchState
    {
        Scheduled = 0,
        Ongoing = 1,
        Finished = 2
    }
}
