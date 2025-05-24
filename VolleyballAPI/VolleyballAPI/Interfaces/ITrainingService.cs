using VolleyballAPI.Dtos.TrainingDtos;
using VolleyballAPI.Dtos.UserDtos;

namespace VolleyballAPI.Interfaces
{
    public interface ITrainingService
    {
        public Task<TrainingDetailsDto> GetTrainingAsync(Guid trainingId);
        public Task<IEnumerable<TrainingHeaderDto>> GetTrainingsAsync();
        public Task<EditTrainingDto> InsertTrainingAsync(EditTrainingDto newTraining);
        public Task UpdateTrainingAsync(EditTrainingDto updatedTraining, Guid trainingId);
        public Task DeleteTrainingAsync(Guid trainingId);
        public Task RegisterTrainingParticipantAsync(Guid trainingId, UserDto dto);
        public Task DeleteTrainingParticipantAsync(Guid trainingId, Guid userId);
    }
}
