using VolleyballAPI.Dtos.LocationDtos;
using VolleyballAPI.Dtos.MatchDtos;
using VolleyballAPI.Dtos.TournamentDtos;
using VolleyballAPI.Dtos.TrainingDtos;
using VolleyballAPI.Dtos.UserDtos;
using VolleyballAPI.Entities;

namespace VolleyballAPI.Dtos.TeamDtos
{
    public class TeamDetailsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string PictureLink { get; set; } = null!;
        public UserHeaderDto Owner { get; set; }
        public LocationDto Location { get; set; }
        public List<TrainingHeaderDto> Trainings { get; set; }
        public List<UserHeaderDto> Players { get; set; }
        public List<UserHeaderDto> Coaches { get; set; }
        public List<MatchHeaderDto> Matches { get; set; }
        public List<TournamentHeaderDto> Tournaments { get; set; }
        public List<UserHeaderDto> UserHasAsFavourite { get; set; }

    }
}
