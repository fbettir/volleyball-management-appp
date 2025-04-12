using VolleyballAPI.Dtos;

namespace VolleyballAPI.Interfaces
{
    public interface IMatchService
    {
        public Task<MatchDetailsDto> GetMatchAsync(Guid matchId);
        public Task<IEnumerable<MatchDetailsDto>> GetMatchesAsync();
        public Task<MatchDetailsDto> InsertMatchAsync(MatchDetailsDto newMatch);
        public Task UpdateMatchAsync(MatchDetailsDto updatedMatch, Guid matchId);
        public Task DeleteMatchAsync(Guid matchId);
        public Task<IEnumerable<TeamDetailsDto>> GetMatchTeamsAsync(Guid matchId);

    }
}
