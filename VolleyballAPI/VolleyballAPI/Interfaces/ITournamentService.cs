using VolleyballAPI.Dtos;

namespace VolleyballAPI.Interfaces
{
    public interface ITournamentService
    {
        public Task<TournamentDetailsDto> GetTournamentAsync(Guid tournamentId);
        public Task<IEnumerable<TournamentDetailsDto>> GetTournamentsAsync();
        public Task<TournamentDetailsDto> InsertTournamentAsync(TournamentDetailsDto newTournament);
        public Task UpdateTournamentAsync(TournamentDetailsDto updatedTournament, Guid tournamentId);
        public Task DeleteTournamentAsync(Guid tournamentId);
        public Task RegisterTeamAsync(Guid id, Guid teamId);
        public Task<IEnumerable<TeamDetailsDto>> GetTeamsAsync(Guid tournamentId);

    }
}
