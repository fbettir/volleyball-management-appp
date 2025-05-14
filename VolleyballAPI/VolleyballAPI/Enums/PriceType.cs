using System.Text.Json.Serialization;

namespace VolleyballAPI.Enums
{
    [Flags]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PriceType
    {
        Ticket = 1,
        StudentTicket = 2,
        Pass = 4,
        StudentPass = 8,
        TournamentTicket = 16,
        StudentTournamentTicket = 32,
        SeasonPass = 64,
        StudentSeasonPass = 128
    }
}
