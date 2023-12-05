using VolleyballAPI.Dtos;
using VolleyballManagementAppBackend.Dtos;
using VolleyballManagementAppBackend.Entities;

namespace VolleyballAPI
{
    public class Profile : AutoMapper.Profile
    {
        public Profile() 
        {
            CreateMap<TournamentDto, Tournament>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));
            CreateMap<Tournament, TournamentDto>();
  
            CreateMap<TeamDto, Team>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));
            CreateMap<Team, TeamDto>();

            CreateMap<TeamPlayerDto, TeamPlayer>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));
            CreateMap<TeamPlayer, TeamPlayerDto>();
        }
    }
}
