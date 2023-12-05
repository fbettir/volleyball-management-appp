using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using VolleyballAPI.Dtos;
using VolleyballAPI.Entities;
using VolleyballManagementAppBackend.Dtos;
using VolleyballManagementAppBackend.Entities;
using VolleyballManagementAppBackend.Exceptions;
using VolleyballManagementAppBackend.Interfaces;

namespace VolleyballManagementAppBackend.Services
{
    public class TeamService : ITeamService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public TeamService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TeamDto> GetTeamAsync(Guid teamId)
        {
            return await _context.Teams
                .ProjectTo<TeamDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(r => r.Id == teamId)
                ?? throw new EntityNotFoundException("Team not found");
        }

        public async Task<IEnumerable<TeamDto>> GetTeamsAsync()
        {
            var teams = await _context.Teams
                .ProjectTo<TeamDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return teams;
        }

        public async Task<TeamDto> InsertTeamAsync(TeamDto newTeam)
        {
            var efTeam = _mapper.Map<Team>(newTeam);
            _context.Teams.Add(efTeam);
            await _context.SaveChangesAsync();
            return await GetTeamAsync(efTeam.Id);
        }

        public async Task UpdateTeamAsync(TeamDto updatedTeam, Guid teamId)
        {
            var efTeam = _mapper.Map<Team>(updatedTeam);
            efTeam.Id = teamId;
            var entry = _context.Attach(efTeam);
            entry.State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Teams.AnyAsync(p => p.Id == teamId))
                    throw new EntityNotFoundException("Team not found");
                else
                    throw;
            }
        }
        public async Task DeleteTeamAsync(Guid teamId)
        {
            _context.Teams.Remove(new Team() { Id = teamId });
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Teams.AnyAsync(p => p.Id == teamId))
                    throw new EntityNotFoundException("Team not found");
                else
                    throw;
            }
        }
        public async Task DeleteTeamsAsync()
        {

            Team[] teams = _context.Teams.ToArray();
            foreach (var t in teams)
            {
                _context.Teams.Remove(new Team() { Id = t.Id });

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _context.Teams.AnyAsync(p => p.Id == t.Id))
                        throw new EntityNotFoundException("Team not found");
                    else
                        throw;
                }
            }
        }

        public async Task<IEnumerable<PlayerDetailsDto>> GetTeamPlayersAsync(Guid teamId)
        {
            var teamExists = await _context.Teams.AnyAsync(t => t.Id == teamId);
            if (!teamExists)
                throw new EntityNotFoundException("Team not found.");
            else
            {
                var teamPlayers = from player in _context.TeamPlayers
                                  where player.TeamId == teamId
                                  select _mapper.Map<PlayerDetailsDto>(player.Player);

                return teamPlayers;
            }
        }
    }
}
