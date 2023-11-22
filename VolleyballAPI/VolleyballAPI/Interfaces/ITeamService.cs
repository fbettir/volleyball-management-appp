using VolleyballManagementAppBackend.Dtos;

namespace VolleyballManagementAppBackend.Interfaces
{
    public interface ITeamService
    {
        public Task<TeamDto> GetTeamAsync(Guid teamId);
        public Task<IEnumerable<TeamDto>> GetTeamsAsync();
        public Task<TeamDto> InsertTeamAsync(TeamDto newTeam);
        public Task UpdateTeamAsync(TeamDto updatedTeam, Guid teamId);
        public Task DeleteTeamAsync(Guid teamId);
        public Task DeleteTeamsAsync();
    }
}
