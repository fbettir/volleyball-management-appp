using VolleyballAPI.Dtos;

namespace VolleyballAPI.Interfaces
{
    public interface ITournamentService
    {
        public Task<TournamentDetailsDto> GetTournamentAsync(Guid tournamentId);
        public Task<IEnumerable<TournamentHeaderDto>> GetTournamentsAsync();
        public Task<RegisterTournamentDto> InsertTournamentAsync(RegisterTournamentDto newTournament);
        public Task UpdateTournamentAsync(RegisterTournamentDto updatedTournament, Guid tournamentId);
        public Task DeleteTournamentAsync(Guid tournamentId);
        public Task RegisterTeamAsync(Guid id, Guid teamId);
        public Task<IEnumerable<TeamDetailsDto>> GetTeamsAsync(Guid tournamentId);

    }
}
