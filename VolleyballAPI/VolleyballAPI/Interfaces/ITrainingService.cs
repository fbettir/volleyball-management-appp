using VolleyballAPI.Dtos;

namespace VolleyballAPI.Interfaces
{
    public interface ITrainingService
    {
        public Task<TrainingDetailsDto> GetTrainingAsync(Guid trainingId);
        public Task<IEnumerable<TrainingDetailsDto>> GetTrainingsAsync();
        public Task<TrainingDetailsDto> InsertTrainingAsync(TrainingDetailsDto newTraining);
        public Task UpdateTrainingAsync(TrainingDetailsDto updatedTraining, Guid trainingId);
        public Task DeleteTrainingAsync(Guid trainingId);
    }
}
