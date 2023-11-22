using VolleyballAPI.Dtos;
using VolleyballManagementAppBackend.Dtos;

namespace VolleyballAPI.Interfaces
{
    public interface ITournementService
    {
        public Task<TournamentDto> GetTournamentAsync(Guid tournamentId);
        public Task<IEnumerable<TournamentDto>> GetTeamsAsync();
        public Task<TournamentDto> InsertTeamAsync(TournamentDto newTournament);
        public Task UpdateTournamentAsync(TournamentDto updatedTournament, Guid tournamentId);
        public Task DeleteTournamentAsync(Guid tournamentId);
        public Task DeleteTournamentAsync();
    }
}
