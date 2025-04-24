using VolleyballAPI.Entities;

namespace VolleyballAPI.Dtos
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
