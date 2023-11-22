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
            CreateMap<Team, TeamDto>();
        }
    }
}
