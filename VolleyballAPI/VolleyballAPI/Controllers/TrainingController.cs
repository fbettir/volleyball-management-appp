using Microsoft.AspNetCore.Mvc;
using VolleyballAPI.Dtos;
using VolleyballAPI.Exceptions;
using VolleyballAPI.Interfaces;
using VolleyballAPI.Services;

namespace VolleyballAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingService _trainingService;

        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        [MapToApiVersion("1.0")]
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingDetailsDto>> Get(Guid id)
        {
            try
            {
                var training = await _trainingService.GetTrainingAsync(id);
                return Ok(training);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [MapToApiVersion("1.0")]
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<TrainingHeaderDto>>> Get()
        {
            try
            {
                var trainingsList = (await _trainingService.GetTrainingsAsync()).ToList();
                return Ok(trainingsList);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [MapToApiVersion("1.0")]
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<TrainingDetailsDto>> Post([FromBody] TrainingDetailsDto training)
        {
            try
            {
                var created = await _trainingService.InsertTrainingAsync(training);
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
        public async Task<ActionResult> Put(Guid id, [FromBody] TrainingDetailsDto value)
        {
            try
            {
                await _trainingService.UpdateTrainingAsync(value, id);
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
                await _trainingService.DeleteTrainingAsync(id);
                return Ok();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
