using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using VolleyballAPI.Dtos;
using VolleyballAPI.Entities;
using VolleyballAPI.Exceptions;
using VolleyballAPI.Interfaces;

namespace VolleyballAPI.Services
{
    public class TrainingService : ITrainingService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public TrainingService(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<TrainingDetailsDto> GetTrainingAsync(Guid trainingId)
        {
            return await _context.Trainings
                .ProjectTo<TrainingDetailsDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(t => t.Id == trainingId)
                ?? throw new EntityNotFoundException("Training not found");
        }

        public async Task<IEnumerable<TrainingDetailsDto>> GetTrainingsAsync()
        {
            var trainings = await _context.Trainings
                .ProjectTo<TrainingDetailsDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return trainings;
        }

        public async Task<TrainingDetailsDto> InsertTrainingAsync(TrainingDetailsDto newTraining)
        {
            var efTraining = _mapper.Map<Training>(newTraining);
            _context.Trainings.Add(efTraining);
            await _context.SaveChangesAsync();
            return await GetTrainingAsync(efTraining.Id);
        }

        public async Task UpdateTrainingAsync(TrainingDetailsDto updatedTraining, Guid trainingId)
        {
            var efTraining = _mapper.Map<Training>(updatedTraining);
            efTraining.Id = trainingId;
            var entry = _context.Attach(efTraining);
            entry.State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Trainings.AnyAsync(t => t.Id == trainingId))
                    throw new EntityNotFoundException("Training not found");
                else
                    throw;
            }
        }

        public async Task DeleteTrainingAsync(Guid trainingId)
        {
            _context.Trainings.Remove(new Training() { Id = trainingId });
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Trainings.AnyAsync(t => t.Id == trainingId))
                    throw new EntityNotFoundException("Training not found");
                else
                    throw;
            }
        }
    }

}
