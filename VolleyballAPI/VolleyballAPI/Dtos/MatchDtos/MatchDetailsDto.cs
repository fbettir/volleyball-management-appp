using VolleyballAPI.Dtos.LocationDtos;
using VolleyballAPI.Dtos.TeamDtos;
using VolleyballAPI.Dtos.TournamentDtos;
using VolleyballAPI.Enums;

namespace VolleyballAPI.Dtos.MatchDtos
{
    public class MatchDetailsDto
    {
        public Guid Id { get; set; }
        public LocationDto Location { get; set; }
        public TournamentHeaderDto Tournament { get; set; }
        public TeamHeaderDto Referee { get; set; }
        public List<int> Points { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public MatchState MatchState { get; set; }

        public List<TeamHeaderDto> Teams { get; set; }
    }
}
