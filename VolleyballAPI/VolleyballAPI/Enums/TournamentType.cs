using System.Text.Json.Serialization;

namespace VolleyballAPI.Enums
{
    [Flags]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TournamentType
    {
        Fana8Kor = 0,
        MuerA10B7 = 1,
        MuerA9B7 = 2,
    }
}
