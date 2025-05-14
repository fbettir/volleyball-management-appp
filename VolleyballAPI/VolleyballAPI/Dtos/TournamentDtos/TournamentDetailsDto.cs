using VolleyballAPI.Dtos.LocationDtos;
using VolleyballAPI.Dtos.MatchDtos;
using VolleyballAPI.Dtos.TeamDtos;
using VolleyballAPI.Dtos.UserDtos;
using VolleyballAPI.Enums;

namespace VolleyballAPI.Dtos.TournamentDtos
{
    public class TournamentDetailsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public DateTime EntryDeadline { get; set; }
        public LocationDto Location { get; set; }
        public string Organizer { get; set; }
        public string RegistrationPolicy { get; set; }
        public string TeamPolicy { get; set; }
        public string Description { get; set; }
        public string PictureLink { get; set; } = null!;
        public TournamentType TournamentType { get; set; }
        public int Courts { get; set; }
        public List<int> MaxTeamsPerLevel { get; set; }
        public Level Categories { get; set; }
        public PriceType PriceType { get; set; }
        public List<MatchHeaderDto> Matches { get; set; }
        public List<TeamHeaderDto> Teams { get; set; }
        public List<UserHeaderDto> UserHasAsFavourite { get; set; }

    }
}
