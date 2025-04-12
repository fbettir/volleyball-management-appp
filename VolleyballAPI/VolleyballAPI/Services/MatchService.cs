using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using VolleyballAPI.Dtos;
using VolleyballAPI.Entities;
using VolleyballAPI.Exceptions;
using VolleyballAPI.Interfaces;

namespace VolleyballAPI.Services
{
    public class MatchService : IMatchService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public MatchService(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<MatchDetailsDto> GetMatchAsync(Guid matchId)
        {
            return await _context.Matches
                .ProjectTo<MatchDetailsDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(m => m.Id == matchId)
                ?? throw new EntityNotFoundException("Match not found");
        }

        public async Task<IEnumerable<MatchDetailsDto>> GetMatchesAsync()
        {
            var matches = await _context.Matches
                .ProjectTo<MatchDetailsDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return matches;
        }

        public async Task<MatchDetailsDto> InsertMatchAsync(MatchDetailsDto newMatch)
        {
            var efMatch = _mapper.Map<Match>(newMatch);
            _context.Matches.Add(efMatch);
            await _context.SaveChangesAsync();
            return await GetMatchAsync(efMatch.Id);
        }

        public async Task UpdateMatchAsync(MatchDetailsDto updatedMatch, Guid matchId)
        {
            var efMatch = _mapper.Map<Match>(updatedMatch);
            efMatch.Id = matchId;
            var entry = _context.Attach(efMatch);
            entry.State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Matches.AnyAsync(m => m.Id == matchId))
                    throw new EntityNotFoundException("Match not found");
                else
                    throw;
            }
        }

        public async Task DeleteMatchAsync(Guid matchId)
        {
            _context.Matches.Remove(new Match() { Id = matchId });
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Matches.AnyAsync(m => m.Id == matchId))
                    throw new EntityNotFoundException("Match not found");
                else
                    throw;
            }
        }

        public async Task<IEnumerable<TeamDetailsDto>> GetMatchTeamsAsync(Guid matchId)
        {
            var matchExists = await _context.Matches.AnyAsync(m => m.Id == matchId);
            if (!matchExists)
                throw new EntityNotFoundException("Match not found.");
            else
            {
                var matchTeams = from match in _context.MatchTeams
                                  where match.MatchId == matchId
                                  select _mapper.Map<TeamDetailsDto>(match.Team);

                return matchTeams;
            }
        }

    }
}
