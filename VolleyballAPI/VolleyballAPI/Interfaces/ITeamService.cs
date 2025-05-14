using VolleyballAPI.Dtos.TeamDtos;
using VolleyballAPI.Dtos.TrainingDtos;
using VolleyballAPI.Dtos.UserDtos;

namespace VolleyballAPI.Interfaces
{
    public interface ITeamService
    {
        public Task<TeamDetailsDto> GetTeamAsync(Guid teamId);
        public Task<IEnumerable<TeamHeaderDto>> GetTeamsAsync();
        public Task<EditTeamDto> InsertTeamAsync(EditTeamDto newTeam);
        public Task UpdateTeamAsync(EditTeamDto updatedTeam, Guid teamId);
        public Task DeleteTeamAsync(Guid teamId);
        public Task RegisterTeamPlayerAsync(Guid teamId, UserDto playerDetailsDto);
        public Task DeleteTeamPlayerAsync(Guid teamId, UserDto playerDetailsDto);
        public Task RegisterTeamCoachAsync(Guid teamId, UserDto playerDetailsDto);
        public Task DeleteTeamCoachAsync(Guid teamId, UserDto playerDetailsDto);
    }
}