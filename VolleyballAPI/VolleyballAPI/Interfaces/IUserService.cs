using VolleyballAPI.Dtos;

namespace VolleyballAPI.Interfaces
{
    public interface IUserService
    {
        public Task<UserDetailsDto> GetUserDetailsAsync(Guid userId);
        public Task<UserHeaderDto> GetUserHeaderAsync(Guid userId);
        public Task<IEnumerable<UserHeaderDto>> GetUsersAsync();
        public Task<UserHeaderDto> InsertUserAsync(UserHeaderDto newUser);
        public Task UpdateUserAsync(UserDetailsDto updatedUser, Guid userId);
        public Task DeleteUserAsync(Guid userId);
    }
}
