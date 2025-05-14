using VolleyballAPI.Dtos.TrainingDtos;

namespace VolleyballAPI.Interfaces
{
    public interface ITrainingService
    {
        public Task<TrainingDetailsDto> GetTrainingAsync(Guid trainingId);
        public Task<IEnumerable<TrainingHeaderDto>> GetTrainingsAsync();
        public Task<EditTrainingDto> InsertTrainingAsync(EditTrainingDto newTraining);
        public Task UpdateTrainingAsync(EditTrainingDto updatedTraining, Guid trainingId);
        public Task DeleteTrainingAsync(Guid trainingId);
    }
}
