using Microsoft.AspNetCore.Mvc;
using VolleyballAPI.Dtos;
using VolleyballAPI.Exceptions;
using VolleyballAPI.Interfaces;

namespace VolleyballAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class LocationController : ControllerBase
    {

        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [MapToApiVersion("1.0")]
        [HttpGet("{id}")]
        public async Task<ActionResult<LocationDto>> Get(Guid id)
        {
            try
            {
                var location = await _locationService.GetLocationAsync(id);
                return Ok(location);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [MapToApiVersion("1.0")]
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<LocationDto>>> Get()
        {
            try
            {
                var locationList = (await _locationService.GetLocationsAsync()).ToList();
                return Ok(locationList);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [MapToApiVersion("1.0")]
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<LocationDto>> Post([FromBody] LocationDto location)
        {
            try
            {
                var created = await _locationService.InsertLocationAsync(location);
                return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [MapToApiVersion("1.0")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Put(Guid id, [FromBody] LocationDto location)
        {
            try
            {
                await _locationService.UpdateLocationAsync(location, id);
                return Ok();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [MapToApiVersion("1.0")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await _locationService.DeleteLocationAsync(id);
                return Ok();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
