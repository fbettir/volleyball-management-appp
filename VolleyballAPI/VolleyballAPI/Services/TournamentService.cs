using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using VolleyballAPI.Dtos;
using VolleyballAPI.Entities;
using VolleyballAPI.Interfaces;
using VolleyballAPI.Exceptions;

namespace VolleyballAPI.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public TournamentService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<TournamentDetailsDto> GetTournamentAsync(Guid tournamentId)
        {
            return await _context.Tournaments
                .ProjectTo<TournamentDetailsDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(t => t.Id == tournamentId)
                ?? throw new EntityNotFoundException("Tournament not found");
        }


        public async Task<IEnumerable<TournamentDetailsDto>> GetTournamentsAsync()
        {
            var tournaments = await _context.Tournaments
                .ProjectTo<TournamentDetailsDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return tournaments;
        }

        public async Task<TournamentDetailsDto> InsertTournamentAsync(TournamentDetailsDto newTournament)
        {
            var efTournament = _mapper.Map<Tournament>(newTournament);
            _context.Tournaments.Add(efTournament);
            await _context.SaveChangesAsync();
            return await GetTournamentAsync(efTournament.Id);
        }

        public async Task UpdateTournamentAsync(TournamentDetailsDto updatedTournament, Guid tournamentId)
        {
            var tournament = _context.Tournaments.FirstOrDefault(t => t.Id == tournamentId);
            if(tournament == null)
            {
                throw new EntityNotFoundException("Tournament not found.");
            }
            var efTournament = _mapper.Map(updatedTournament, tournament);
            _context.Update(efTournament);
        }

        public async Task DeleteTournamentAsync(Guid tournamentId)
        {
            _context.Tournaments.Remove(new Tournament() { Id = tournamentId });
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Tournaments.AnyAsync(p => p.Id == tournamentId))
                    throw new EntityNotFoundException("Tournament not found");
                else
                    throw;
            }
        }

        public async Task RegisterTeamAsync(Guid id, Guid teamId)
        {
            var teamExists = await _context.Teams.AnyAsync(t => t.Id == teamId);
            var tournamentExists = await _context.Tournaments.AnyAsync(t => t.Id == id);
            if ( teamExists && tournamentExists )
            {
                var tournamentCompetitor = new TournamentCompetitor()
                {
                    TournamentId = id,
                    TeamId = teamId
                };
                _context.TournamentCompetitors.Add(tournamentCompetitor);
                await _context.SaveChangesAsync();
            }
            else
                throw new EntityNotFoundException("Tournament or team not found.");
        }

        public async Task<IEnumerable<TeamDetailsDto>> GetTeamsAsync(Guid tournamentId)
        {
            var tournamentExists = await _context.Tournaments.AnyAsync(t => t.Id == tournamentId);
            if (!tournamentExists)
                throw new EntityNotFoundException("Tournament not found.");
            else
            {
                var teams = from team in _context.TournamentCompetitors
                            where team.TournamentId == tournamentId
                            select _mapper.Map<TeamDetailsDto>(team.Team);
                return teams;
            }
        }
    }
}

