using VolleyballAPI.Dtos;

namespace VolleyballAPI.Interfaces
{
    public interface IUserService
    {
        public Task<UserDto> GetUserAsync(Guid userId);
        public Task<IEnumerable<UserDto>> GetUsersAsync();
        public Task<UserDto> InsertUserAsync(UserDto newUser);
        public Task UpdateUserAsync(UserDto updatedUser, Guid userId);
        public Task DeleteUserAsync(Guid userId);
    }
}
