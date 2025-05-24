using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using VolleyballAPI.Dtos.TrainingDtos;
using VolleyballAPI.Dtos.UserDtos;
using VolleyballAPI.Entities;
using VolleyballAPI.Exceptions;
using VolleyballAPI.Interfaces;
using VolleyballAPI.JoinTableTypes;

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

        public async Task<IEnumerable<TrainingHeaderDto>> GetTrainingsAsync()
        {
            var trainings = await _context.Trainings
                .ProjectTo<TrainingHeaderDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return trainings;
        }

        public async Task<EditTrainingDto> InsertTrainingAsync(EditTrainingDto newTraining)
        {
            var efTraining = _mapper.Map<Training>(newTraining);
            _context.Trainings.Add(efTraining);
            await _context.SaveChangesAsync();

            var fullDetails = await GetTrainingAsync(efTraining.Id);
            return _mapper.Map<EditTrainingDto>(fullDetails);
        }

        public async Task UpdateTrainingAsync(EditTrainingDto updatedTraining, Guid trainingId)
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

        public async Task RegisterTrainingParticipantAsync(Guid trainingId, UserDto dto)
        {
            var training = await _context.Trainings.FindAsync(trainingId);
            if (training == null)
                throw new EntityNotFoundException("Training not found");

            var user = await _context.Users.FindAsync(dto.UserId);
            if (user == null)
                throw new EntityNotFoundException("User not found");

            var alreadyJoined = await _context.TrainingParticipants
                .AnyAsync(tp => tp.TrainingId == trainingId && tp.UserId == dto.UserId);
            if (alreadyJoined)
                return;

            var participant = new TrainingParticipant
            {
                TrainingId = trainingId,
                UserId = dto.UserId
            };

            _context.TrainingParticipants.Add(participant);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTrainingParticipantAsync(Guid trainingId, Guid userId)
        {
            var participant = await _context.TrainingParticipants
                .FirstOrDefaultAsync(tp => tp.TrainingId == trainingId && tp.UserId == userId);

            if (participant == null)
                throw new EntityNotFoundException("Participant not found");

            _context.TrainingParticipants.Remove(participant);
            await _context.SaveChangesAsync();
        }

    }

}
