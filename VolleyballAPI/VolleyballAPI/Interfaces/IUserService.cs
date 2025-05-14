using VolleyballAPI.Dtos.TeamDtos;
using VolleyballAPI.Dtos.TournamentDtos;
using VolleyballAPI.Dtos.TrainingDtos;
using VolleyballAPI.Dtos.UserDtos;

namespace VolleyballAPI.Interfaces
{
    public interface IUserService
    {
        public Task<UserDetailsDto> GetUserDetailsAsync(Guid userId);
        public Task<IEnumerable<UserHeaderDto>> GetUsersAsync();
        public Task<EditUserDto> InsertUserAsync(EditUserDto newUser);
        public Task UpdateUserAsync(EditUserDto updatedUser, Guid userId);
        public Task DeleteUserAsync(Guid userId);
        public Task RegisterFavouriteTeamAsync(Guid userId, TeamDto teamDto);
        public Task DeleteFavouriteTeamAsync(Guid userId, TeamDto teamDto);
        public Task RegisterFavouriteTrainingAsync(Guid userId, TrainingDto trainingDto);
        public Task DeleteFavouriteTrainingAsync(Guid userId, TrainingDto trainingDto);
        public Task RegisterFavouriteTournamentAsync(Guid userId, TournamentDto tournamentDto);
        public Task DeleteFavouriteTournamentAsync(Guid userId, TournamentDto tournamentDto);
    }
}
