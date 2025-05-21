using VolleyballAPI.Dtos.TeamDtos;
using VolleyballAPI.Dtos.TournamentDtos;

namespace VolleyballAPI.Interfaces
{
    public interface ITournamentService
    {
        public Task<TournamentDetailsDto> GetTournamentAsync(Guid tournamentId);
        public Task<IEnumerable<TournamentHeaderDto>> GetTournamentsAsync();
        public Task<EditTournamentDto> InsertTournamentAsync(EditTournamentDto newTournament);
        public Task UpdateTournamentAsync(EditTournamentDto updatedTournament, Guid tournamentId);
        public Task DeleteTournamentAsync(Guid tournamentId);
        public Task RegisterTournamentCompetitorAsync(Guid tournamentId, TeamDto teamDto);
        public Task DeleteTournamentCompetitorAsync(Guid tournamentId, Guid teamId);
        public Task SetTournamentMatchesAsync(Guid tournamentId);

    }
}
