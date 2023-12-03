using VolleyballAPI.Dtos;
using VolleyballManagementAppBackend.Dtos;

namespace VolleyballAPI.Interfaces
{
    public interface ITournamentService
    {
        public Task<TournamentDto> GetTournamentAsync(Guid tournamentId);
        public Task<IEnumerable<TournamentDto>> GetTournamentsAsync();
        public Task<TournamentDto> InsertTournamentAsync(TournamentDto newTournament);
        public Task UpdateTournamentAsync(TournamentDto updatedTournament, Guid tournamentId);
        public Task DeleteTournamentAsync(Guid tournamentId);
        public Task RegisterTeamAsync(Guid id, Guid teamId);
    }
}
