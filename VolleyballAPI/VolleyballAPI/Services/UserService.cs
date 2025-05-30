﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using VolleyballAPI.Interfaces;
using VolleyballAPI.Entities;
using VolleyballAPI.Exceptions;
using VolleyballAPI.Dtos.UserDtos;
using VolleyballAPI.JoinTableTypes;
using VolleyballAPI.Dtos.TeamDtos;
using VolleyballAPI.Dtos.TrainingDtos;
using VolleyballAPI.Dtos.TournamentDtos;
using VolleyballAPI.Enums;


namespace VolleyballAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public UserService(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<UserDetailsDto> GetUserDetailsAsync(Guid userId)
        {
            return await _context.Users
                .ProjectTo<UserDetailsDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(r => r.Id == userId)
                ?? throw new EntityNotFoundException("User not found");
        }

        public async Task<UserDetailsDto> GetOrCreateByAuth0Async(Auth0UserDto dto)
        {
            var existing = await _context.Users
                .FirstOrDefaultAsync(u => u.Auth0Id == dto.Auth0Id);

            if (existing != null)
                return _mapper.Map<UserDetailsDto>(existing);

            var newUser = new User
            {
                Auth0Id = dto.Auth0Id,
                Email = dto.Email,
                Name = dto.Name ?? "New User",
                PictureLink = dto.PictureLink ?? "",
                Birthday = DateTime.Now,
                Phone = "",
                PlayerNumber = 0,
                Gender = Gender.Man, 
                Roles = Role.BasicUser,
                PriceType = PriceType.None
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserDetailsDto>(newUser);
        }
        public async Task<UserDetailsDto> GetByAuth0IdAsync(string auth0Id)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Auth0Id == auth0Id);

            if (user == null)
                throw new EntityNotFoundException("User not found with given Auth0 ID");

            return _mapper.Map<UserDetailsDto>(user);
        }


        public async Task<IEnumerable<UserHeaderDto>> GetUsersAsync()
        {
            var users = await _context.Users
                .ProjectTo<UserHeaderDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return users;
        }

        public async Task<IEnumerable<UserHeaderDto>> GetCoachesAsync()
        {
            var users = await _context.Users
                .Where(u => (u.Roles & Role.Coach) == Role.Coach)
                .ProjectTo<UserHeaderDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return users;
        }

        public async Task<EditUserDto> InsertUserAsync(EditUserDto newUser)
        {
            var userIdExists = await _context.Users.AnyAsync(u => u.Id == newUser.Id);
            if (userIdExists)
                throw new InvalidOperationException("User with this ID already exists");

            var efUser = _mapper.Map<User>(newUser);
            _context.Users.Add(efUser);
            await _context.SaveChangesAsync();

            var fullDetails = await GetUserDetailsAsync(efUser.Id);
            return _mapper.Map<EditUserDto>(fullDetails);
        }

        public async Task UpdateUserAsync(EditUserDto updatedUser, Guid userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if(user == null)
                throw new EntityNotFoundException("User not found");

            var efUser = _mapper.Map(updatedUser, user);
            _context.Update(efUser);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(Guid UserId)
        {
            _context.Users.Remove(new User() { Id = UserId });
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Users.AnyAsync(p => p.Id == UserId))
                    throw new EntityNotFoundException("User not found");
                else
                    throw;
            }
        }

        public async Task RegisterFavouriteTeamAsync(Guid userId, TeamDto teamDto)
        {
            var userExists = await _context.Users.AnyAsync(u => u.Id == userId);
            if (!userExists)
                throw new EntityNotFoundException("User not found");

            var favouriteTeam = new FavouriteTeam()
            {
                TeamId = teamDto.TeamId,
                UserId = userId,
            };
            _context.FavouriteTeams.Add(favouriteTeam);

            await _context.SaveChangesAsync();
            
        }

        public async Task DeleteFavouriteTeamAsync(Guid userId, TeamDto teamDto)
        {
            var userExists = await _context.Users.AnyAsync(u => u.Id == userId);
            if (!userExists)
                throw new EntityNotFoundException("User not found");

            var favouriteTeam = await _context.FavouriteTeams.FirstOrDefaultAsync(ft =>
                ft.TeamId == teamDto.TeamId && ft.UserId == userId);

            if (favouriteTeam == null)
                throw new EntityNotFoundException("FavouriteTeam not found");

            _context.FavouriteTeams.Remove(favouriteTeam);

            await _context.SaveChangesAsync();
        }

        public async Task RegisterFavouriteTrainingAsync(Guid userId, TrainingDto trainingDto)
        {
            var userExists = await _context.Users.AnyAsync(u => u.Id == userId);
            if (!userExists)
                throw new EntityNotFoundException("User not found");

            var favouriteTraining = new FavouriteTraining()
            {
                TrainingId = trainingDto.TrainingId,
                UserId = userId,
            };
            _context.FavouriteTrainings.Add(favouriteTraining);

            await _context.SaveChangesAsync();
            
        }

        public async Task DeleteFavouriteTrainingAsync(Guid userId, TrainingDto trainingDto)
        {
            var userExists = await _context.Users.AnyAsync(u => u.Id == userId);
            if (!userExists)
                throw new EntityNotFoundException("User not found");

            var favouriteTraining = await _context.FavouriteTrainings.FirstOrDefaultAsync(ft =>
                ft.TrainingId == trainingDto.TrainingId && ft.UserId == userId);

            if (favouriteTraining == null)
                throw new EntityNotFoundException("FavouriteTraining not found");

            _context.FavouriteTrainings.Remove(favouriteTraining);

            await _context.SaveChangesAsync();
        }

        public async Task RegisterFavouriteTournamentAsync(Guid userId, TournamentDto tournamentDto)
        {
            var userExists = await _context.Users.AnyAsync(u => u.Id == userId);
            if (!userExists)
                throw new EntityNotFoundException("User not found");

            var favouriteTournament = new FavouriteTournament()
            {
                TournamentId = tournamentDto.TournamentId,
                UserId = userId,
            };
            _context.FavouriteTournaments.Add(favouriteTournament);

            await _context.SaveChangesAsync();
            
        }

        public async Task DeleteFavouriteTournamentAsync(Guid userId, TournamentDto tournamentDto)
        {
            var userExists = await _context.Users.AnyAsync(u => u.Id == userId);
            if (!userExists)
                throw new EntityNotFoundException("User not found");

            var favouriteTournament = await _context.FavouriteTournaments.FirstOrDefaultAsync(ft =>
                ft.TournamentId == tournamentDto.TournamentId && ft.UserId == userId);

            if (favouriteTournament == null)
                throw new EntityNotFoundException("favouriteTournament not found");

            _context.FavouriteTournaments.Remove(favouriteTournament);

            await _context.SaveChangesAsync();
        }

    }
}
