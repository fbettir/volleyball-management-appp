using VolleyballAPI.Dtos.TeamDtos;
using VolleyballAPI.Dtos.TournamentDtos;
using VolleyballAPI.Dtos.TrainingDtos;
using VolleyballAPI.Enums;

namespace VolleyballAPI.Dtos.UserDtos
{
    public class UserDetailsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public int PlayerNumber { get; set; }
        public string PictureLink { get; set; } = null!;
        public Role Roles { get; set; }
        public PriceType PriceType { get; set; }
        public Gender Gender { get; set; }
        public Post Posts { get; set; }
        public List<TeamHeaderDto> OwnedTeams { get; set; }
        public List<TeamHeaderDto> JoinedTeams { get; set; }
        public List<TeamHeaderDto> CoachedTeams { get; set; }
        public List<TeamHeaderDto> FavouriteTeams { get; set; }
        public List<TrainingHeaderDto> Trainings { get; set; }
        public List<TrainingHeaderDto> FavouriteTrainings { get; set; }
        public List<TournamentHeaderDto> FavouriteTournaments { get; set; }

    }
}
