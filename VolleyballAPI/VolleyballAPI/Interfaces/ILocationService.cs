using VolleyballAPI.Dtos;

namespace VolleyballAPI.Interfaces
{
    public interface ILocationService
    {
        public Task<LocationDto> GetLocationAsync(Guid locationId);
        public Task<IEnumerable<LocationDto>> GetLocationsAsync();
        public Task<LocationDto> InsertLocationAsync(LocationDto newLocation);
        public Task UpdateLocationAsync(LocationDto updatedLocation, Guid locationId);
        public Task DeleteLocationAsync(Guid locationId);
    }
}
