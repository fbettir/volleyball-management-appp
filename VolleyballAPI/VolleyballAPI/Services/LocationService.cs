using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using VolleyballAPI.Dtos;
using VolleyballAPI.Entities;
using VolleyballAPI.Exceptions;
using VolleyballAPI.Interfaces;

namespace VolleyballAPI.Services
{
    public class LocationService : ILocationService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public LocationService(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;   
            _context = context;
        }

        public async Task<LocationDto> GetLocationAsync(Guid locationId)
        {
            return await _context.Locations
                .ProjectTo<LocationDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(l => l.Id == locationId)
                ?? throw new EntityNotFoundException("Location not found");
        }
        public async Task<IEnumerable<LocationDto>> GetLocationsAsync()
        {
            var locations = await _context.Locations
                .ProjectTo<LocationDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return locations;
        }
        public async Task<LocationDto> InsertLocationAsync(LocationDto newLocation)
        {
            var efLocation = _mapper.Map<Location>(newLocation);
            _context.Locations.Add(efLocation);
            await _context.SaveChangesAsync();
            return await GetLocationAsync(efLocation.Id);
        }
        public async Task UpdateLocationAsync(LocationDto updatedLocation, Guid locationId)
        {
            var efLocation = _mapper.Map<Location>(updatedLocation);
            efLocation.Id = locationId;
            var entry = _context.Attach(efLocation);
            entry.State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Locations.AnyAsync(m => m.Id == locationId))
                    throw new EntityNotFoundException("Location not found");
                else
                    throw;
            }

        }
        public async Task DeleteLocationAsync(Guid locationId)
        {
            _context.Locations.Remove(new Location() { Id = locationId });
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Locations.AnyAsync(m => m.Id == locationId))
                    throw new EntityNotFoundException("Location not found");
                else
                    throw;
            }
        }
    }
}
