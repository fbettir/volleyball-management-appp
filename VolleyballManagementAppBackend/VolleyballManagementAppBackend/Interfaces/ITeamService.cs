using VolleyballManagementAppBackend.Dtos;

namespace VolleyballManagementAppBackend.Interfaces
{
    public interface ITeamService
    {
        public Task<TeamDto> GetTeamAsync(int teamId);
        public Task<IEnumerable<TeamDto>> GetTeamsAsync();
        public Task<TeamDto> InsertTeamAsync(TeamDto newTeam);
        public Task UpdateTeamAsync(TeamDto updatedTeam, int teamId);
        public Task DeleteTeamAsync(int teamId);
        public Task DeleteTeamsAsync();
    }
}
