using VolleyballAPI.Dtos;

namespace VolleyballAPI.Interfaces
{
    public interface ITeamService
    {
        public Task<TeamDetailsDto> GetTeamAsync(Guid teamId);
        public Task<IEnumerable<TeamHeaderDto>> GetTeamsAsync();
        public Task<TeamDetailsDto> InsertTeamAsync(TeamDetailsDto newTeam);
        public Task UpdateTeamAsync(TeamDetailsDto updatedTeam, Guid teamId);
        public Task DeleteTeamAsync(Guid teamId);
        public Task<IEnumerable<UserDetailsDto>> GetTeamPlayersAsync(Guid teamId);
        public Task RegisterTeamPlayerAsync(Guid teamId, UserDetailsDto playerDetailsDto);
        public Task<IEnumerable<TrainingDetailsDto>> GetTrainingsAsync(Guid teamId);

    }
}