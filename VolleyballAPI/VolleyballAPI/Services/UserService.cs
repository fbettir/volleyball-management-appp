using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using VolleyballAPI.Dtos;
using VolleyballAPI.Interfaces;
using VolleyballAPI.Entities;
using VolleyballAPI.Exceptions;


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
        
        public async Task<UserHeaderDto> GetUserHeaderAsync(Guid userId)
        {
            return await _context.Users
                .ProjectTo<UserHeaderDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(r => r.Id == userId)
                ?? throw new EntityNotFoundException("User not found");
        }

        public async Task<IEnumerable<UserHeaderDto>> GetUsersAsync()
        {
            var users = await _context.Users
                .ProjectTo<UserHeaderDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return users;
        }

        public async Task<UserHeaderDto> InsertUserAsync(UserHeaderDto newUser)
        {
            var efUser = _mapper.Map<User>(newUser);
            _context.Users.Add(efUser);
            await _context.SaveChangesAsync();
            return await GetUserHeaderAsync(efUser.Id);
        }

        public async Task UpdateUserAsync(UserDetailsDto updatedUser, Guid userId)
        {
            var efUser = _mapper.Map<User>(updatedUser);
            efUser.Id = userId;
            var entry = _context.Attach(efUser);
            entry.State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Users.AnyAsync(p => p.Id == userId))
                    throw new EntityNotFoundException("User not found");
                else
                    throw;
            }
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

    }
}
