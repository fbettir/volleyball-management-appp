using VolleyballAPI.Dtos;
using VolleyballManagementAppBackend.Dtos;
using VolleyballManagementAppBackend.Entities;

namespace VolleyballAPI
{
    public class Profile : AutoMapper.Profile
    {
        public Profile() 
        {
            CreateMap<TournamentDto, Tournament>();
            CreateMap<Tournament, TournamentDto>();
  
            CreateMap<TeamDto, Team>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));
            CreateMap<Team, TeamDto>();

            CreateMap<TeamPlayerDto, TeamPlayer>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));
            CreateMap<TeamPlayer, TeamPlayerDto>();

            CreateMap<PlayerDetailsDto, PlayerDetails>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));
            CreateMap<PlayerDetails, PlayerDetailsDto>();

            CreateMap<TrainingDto, Training>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));
            CreateMap<Training, TrainingDto>();

            CreateMap<UserDto, User>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));
            CreateMap<User, UserDto>();
        }
    }
}
