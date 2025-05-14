using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using VolleyballAPI.Entities;
using VolleyballAPI.Interfaces;
using VolleyballAPI.Exceptions;
using VolleyballAPI.Dtos.TournamentDtos;
using VolleyballAPI.Dtos.TeamDtos;
using VolleyballAPI.JoinTableTypes;
using VolleyballAPI.Dtos.UserDtos;

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

        public async Task<IEnumerable<TournamentHeaderDto>> GetTournamentsAsync()
        {
            var tournaments = await _context.Tournaments
                .ProjectTo<TournamentHeaderDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return tournaments;
        }

        public async Task<EditTournamentDto> InsertTournamentAsync(EditTournamentDto newTournament)
        {
            var tournamentIdExists = await _context.Tournaments.AnyAsync(t => t.Id == newTournament.Id);
            if (tournamentIdExists)
                throw new InvalidOperationException("Tournament with this ID already exists");

            // 1. Create tournament
            var efTournament = _mapper.Map<Tournament>(newTournament);
            _context.Tournaments.Add(efTournament);
            await _context.SaveChangesAsync();

            // 2. Get original match IDs and entities
            var matchIds = await _context.Matches
                .Where(m => m.TournamentType == newTournament.TournamentType)
                .Select(m => m.Id)
                .Distinct()
                .ToListAsync();

            var originalMatches = await _context.Matches
                .Where(m => matchIds.Contains(m.Id))
                .ToListAsync();

            var originalMatchTeams = await _context.MatchTeams
                .Where(mt => matchIds.Contains(mt.MatchId))
                .ToListAsync();

            // 3. Duplicate matches and build ID map
            var matchIdMap = new Dictionary<Guid, Guid>(); // old -> new ID

            var duplicatedMatches = originalMatches.Select(m =>
            {
                var newId = Guid.NewGuid();
                matchIdMap[m.Id] = newId;

                return new Match
                {
                    Id = newId,
                    Date = m.Date,
                    LocationId = m.LocationId,
                    RefereeId = m.RefereeId,
                    TournamentId = efTournament.Id,
                    StartTime = m.StartTime,
                    MatchState = m.MatchState,
                    TournamentType = null, // explicitly cleared
                    Points = m.Points,
                };
            }).ToList();

            _context.Matches.AddRange(duplicatedMatches);

            // 4. Duplicate match teams with remapped match IDs
            var duplicatedMatchTeams = originalMatchTeams.Select(mt => new MatchTeam
            {
                MatchId = matchIdMap[mt.MatchId],
                TeamId = mt.TeamId,
            }).ToList();

            _context.MatchTeams.AddRange(duplicatedMatchTeams);

            // 5. Assign matches to tournament
            efTournament.Matches = duplicatedMatches;
            await _context.SaveChangesAsync();

            var fullDetails = await GetTournamentAsync(efTournament.Id);
            return _mapper.Map<EditTournamentDto>(fullDetails);
        }

        public async Task UpdateTournamentAsync(EditTournamentDto updatedTournament, Guid tournamentId)
        {
            var tournament = _context.Tournaments.FirstOrDefault(t => t.Id == tournamentId);
            if(tournament == null)
                throw new EntityNotFoundException("Tournament not found.");
            
            var efTournament = _mapper.Map(updatedTournament, tournament);
            _context.Update(efTournament);

            await _context.SaveChangesAsync();
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

        public async Task RegisterTournamentCompetitorAsync(Guid tournamentId, TeamDto teamDto)
        {
            var tournament = _context.Tournaments.FirstOrDefault(t => t.Id == tournamentId);
            if (tournament == null)
                throw new EntityNotFoundException("Tournament not found");

            var tournamentCompetitor = new TournamentCompetitor()
            {
                TournamentId = tournamentId,
                TeamId = teamDto.TeamId,
            };
            _context.TournamentCompetitors.Add(tournamentCompetitor);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteTournamentCompetitorAsync(Guid tournamentId, TeamDto teamDto)
        {
            var tournament = _context.Tournaments.FirstOrDefault(t => t.Id == tournamentId);
            if (tournament == null)
                throw new EntityNotFoundException("TournamentCompetitor not found");


            var tournamentCompetitor = await _context.TournamentCompetitors.FirstOrDefaultAsync(tc =>
                tc.TournamentId == tournamentId && tc.TeamId == teamDto.TeamId);

            if (tournamentCompetitor == null)
                throw new EntityNotFoundException("TournamentCompetitor not found");

            _context.TournamentCompetitors.Remove(tournamentCompetitor);

            await _context.SaveChangesAsync();
        }

        public async Task SetTournamentMatchesAsync(Guid tournamentId)
        {
            var tournament = _context.Tournaments.FirstOrDefault(t => t.Id == tournamentId);
            if (tournament == null)
                throw new EntityNotFoundException("Tournament not found");


        }
    }
}

