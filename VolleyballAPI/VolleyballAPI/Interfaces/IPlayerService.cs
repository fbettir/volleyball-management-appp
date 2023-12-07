using VolleyballAPI.Dtos;

namespace VolleyballAPI.Interfaces
{
    public interface IPlayerService
    {
        public Task<PlayerDetailsDto> GetPlayerAsync(Guid playerId);
        public Task<IEnumerable<PlayerDetailsDto>> GetPlayersAsync();
        public Task<PlayerDetailsDto> InsertPlayerAsync(PlayerDetailsDto newPlayer);
        public Task UpdatePlayerAsync(PlayerDetailsDto updatedPlayer, Guid playerId);
        public Task DeletePlayerAsync(Guid playerId);
    }
}
