using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using VolleyballAPI.Dtos;
using VolleyballAPI.Entities;
using VolleyballAPI.Exceptions;
using VolleyballAPI.Interfaces;

namespace VolleyballAPI.Services
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

        public async Task<TeamDetailsDto> GetTeamAsync(Guid teamId)
        {
            return await _context.Teams
                .ProjectTo<TeamDetailsDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(r => r.Id == teamId)
                ?? throw new EntityNotFoundException("Team not found");
        }

        public async Task<IEnumerable<TeamDetailsDto>> GetTeamsAsync()
        {
            var teams = await _context.Teams
                .ProjectTo<TeamDetailsDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return teams;
        }

        public async Task<TeamDetailsDto> InsertTeamAsync(TeamDetailsDto newTeam)
        {
            var efTeam = _mapper.Map<Team>(newTeam);
            _context.Teams.Add(efTeam);
            await _context.SaveChangesAsync();
            return await GetTeamAsync(efTeam.Id);
        }

        public async Task UpdateTeamAsync(TeamDetailsDto updatedTeam, Guid teamId)
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

        public async Task<IEnumerable<UserDetailsDto>> GetTeamPlayersAsync(Guid teamId)
        {
            var teamExists = await _context.Teams.AnyAsync(t => t.Id == teamId);
            if (!teamExists)
                throw new EntityNotFoundException("Team not found.");
            else
            {
                var teamPlayers = from player in _context.TeamPlayers
                                  where player.TeamId == teamId
                                  select _mapper.Map<UserDetailsDto>(player.User);

                return teamPlayers;
            }
        }

        public async Task RegisterTeamPlayerAsync(Guid teamId, UserDetailsDto playerDetailsDto)
        {
            var teamExists = await _context.Teams.AnyAsync(t => t.Id == teamId);
            if (!teamExists)
                throw new EntityNotFoundException("Team not found");
            else
            {
                var efPlayer = _mapper.Map<User>(playerDetailsDto);
                _context.Users.Add(efPlayer);

                var teamPlayer = new TeamPlayer()
                {
                    TeamId = teamId,
                    UserId = efPlayer.Id,
                };
                _context.TeamPlayers.Add(teamPlayer);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TrainingDetailsDto>> GetTrainingsAsync(Guid teamId)
            {
                var teamExists = await _context.Teams.AnyAsync(t => t.Id == teamId);
                if (!teamExists)
                    throw new EntityNotFoundException("Team not found.");
                else
                {
                    var trainings = from training in _context.Trainings
                                      where training.TeamId == teamId
                                      select _mapper.Map<TrainingDetailsDto>(training);

                    return trainings;
                }
            }
    }
}
