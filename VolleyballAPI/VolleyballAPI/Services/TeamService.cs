using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using VolleyballAPI.Dtos.MatchDtos;
using VolleyballAPI.Dtos.TeamDtos;
using VolleyballAPI.Dtos.TrainingDtos;
using VolleyballAPI.Dtos.UserDtos;
using VolleyballAPI.Entities;
using VolleyballAPI.Exceptions;
using VolleyballAPI.Interfaces;
using VolleyballAPI.JoinTableTypes;

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

        public async Task<IEnumerable<TeamHeaderDto>> GetTeamsAsync()
        {
            var teams = await _context.Teams
                .ProjectTo<TeamHeaderDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return teams;
        }

        public async Task<EditTeamDto> InsertTeamAsync(EditTeamDto newTeam)
        {
            var teamId = await _context.Teams.AnyAsync(t => t.Id == newTeam.Id);
            if (teamId)
                throw new InvalidOperationException("Team with this ID already exists");
            
            var efTeam = _mapper.Map<Team>(newTeam);
            _context.Teams.Add(efTeam);
            await _context.SaveChangesAsync();

            var fullDetails = await GetTeamAsync(efTeam.Id);
            return _mapper.Map<EditTeamDto>(fullDetails);
        }

        public async Task UpdateTeamAsync(EditTeamDto updatedTeam, Guid teamId)
        {
            var team = _context.Teams.FirstOrDefault(t => t.Id == teamId);
            if (team == null)
                throw new EntityNotFoundException("Team not found");

            var efTeam = _mapper.Map(updatedTeam, team);
            _context.Update(efTeam);

            await _context.SaveChangesAsync();  
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

        //public async Task<IEnumerable<UserDetailsDto>> GetTeamPlayersAsync(Guid teamId)
        //{
        //    var teamExists = await _context.Teams.AnyAsync(t => t.Id == teamId);
        //    if (!teamExists)
        //        throw new EntityNotFoundException("Team not found.");
        //    else
        //    {
        //        var teamPlayers = from player in _context.TeamPlayers
        //                          where player.TeamId == teamId
        //                          select _mapper.Map<UserDetailsDto>(player.User);

        //        return teamPlayers;
        //    }
        //}

        public async Task RegisterTeamPlayerAsync(Guid teamId, UserDto userDto)
        {
            var teamExists = await _context.Teams.AnyAsync(t => t.Id == teamId);
            if (!teamExists)
                throw new EntityNotFoundException("Team not found");

            var teamPlayer = new TeamPlayer()
            {
                TeamId = teamId,
                UserId = userDto.UserId,
            };
            _context.TeamPlayers.Add(teamPlayer);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteTeamPlayerAsync(Guid teamId, Guid userId)
        {
            var teamExists = await _context.Teams.AnyAsync(t => t.Id == teamId);
            if (!teamExists)
                throw new EntityNotFoundException("Team not found");

            var teamPlayer = await _context.TeamPlayers.FirstOrDefaultAsync(tp =>
                tp.TeamId == teamId && tp.UserId == userId);

            if (teamPlayer == null)
                throw new EntityNotFoundException("TeamPlayer not found");

            _context.TeamPlayers.Remove(teamPlayer);

            await _context.SaveChangesAsync();
        }

        public async Task RegisterTeamCoachAsync(Guid teamId, UserDto userDto)
        {
            var teamExists = await _context.Teams.AnyAsync(t => t.Id == teamId);
            if (!teamExists)
                throw new EntityNotFoundException("Team not found");
            else
            {
                var teamCoach = new TeamCoach()
                {
                    TeamId = teamId,
                    UserId = userDto.UserId,
                };
                _context.TeamCoaches.Add(teamCoach);

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteTeamCoachAsync(Guid teamId, Guid userId)
        {
            var teamExists = await _context.Teams.AnyAsync(t => t.Id == teamId);
            if (!teamExists)
                throw new EntityNotFoundException("Team not found");

            var teamCoach = await _context.TeamCoaches.FirstOrDefaultAsync(tc =>
                tc.TeamId == teamId && tc.UserId == userId);

            if (teamCoach == null)
                throw new EntityNotFoundException("TeamCoach not found");

            _context.TeamCoaches.Remove(teamCoach);

            await _context.SaveChangesAsync();
        }
    }
}
