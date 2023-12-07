using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using VolleyballAPI.Dtos;
using VolleyballAPI.Interfaces;
using VolleyballManagementAppBackend;
using VolleyballManagementAppBackend.Entities;
using VolleyballManagementAppBackend.Exceptions;

namespace VolleyballAPI.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public PlayerService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PlayerDetailsDto> GetPlayerAsync(Guid playerId)
        {
            return await _context.PlayerDetails
                .ProjectTo<PlayerDetailsDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(r => r.Id == playerId)
                ?? throw new EntityNotFoundException("Player not found");
        }

        public async Task<IEnumerable<PlayerDetailsDto>> GetPlayersAsync()
        {
            var players = await _context.PlayerDetails
                .ProjectTo<PlayerDetailsDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return players;
        }

        public async Task<PlayerDetailsDto> InsertPlayerAsync(PlayerDetailsDto newPlayer)
        {
            var efPlayer = _mapper.Map<PlayerDetails>(newPlayer);
            _context.PlayerDetails.Add(efPlayer);
            await _context.SaveChangesAsync();
            return await GetPlayerAsync(efPlayer.Id);
        }

        public async Task UpdatePlayerAsync(PlayerDetailsDto updatedPlayer, Guid playerId)
        {
            var efPlayer = _mapper.Map<PlayerDetails>(updatedPlayer);
            efPlayer.Id = playerId;
            var entry = _context.Attach(efPlayer);
            entry.State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.PlayerDetails.AnyAsync(p => p.Id == playerId))
                    throw new EntityNotFoundException("Player not found");
                else
                    throw;
            }
        }

        public async Task DeletePlayerAsync(Guid playerId)
        {
            _context.PlayerDetails.Remove(new PlayerDetails() { Id = playerId });
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.PlayerDetails.AnyAsync(p => p.Id == playerId))
                    throw new EntityNotFoundException("Player not found");
                else
                    throw;
            }
        }
    }
}
