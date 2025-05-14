using Microsoft.AspNetCore.Mvc;
using VolleyballAPI.Dtos.TeamDtos;
using VolleyballAPI.Dtos.TrainingDtos;
using VolleyballAPI.Dtos.UserDtos;
using VolleyballAPI.Exceptions;
using VolleyballAPI.Interfaces;

namespace VolleyballAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamsService;

        public TeamController(ITeamService teamService)
        {
            _teamsService = teamService;
        }
        
        [MapToApiVersion("1.0")]
        [HttpGet("{id}")]
        public async Task<ActionResult<TeamDetailsDto>> Get(Guid id)
        {
            try
            {
                var team =  await _teamsService.GetTeamAsync(id);
                return Ok(team);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [MapToApiVersion("1.0")]
        [HttpGet()]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<TeamHeaderDto>>> Get()
        {
            try
            {
                var teamsList = (await _teamsService.GetTeamsAsync()).ToList();
                return Ok(teamsList);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [MapToApiVersion("1.0")]
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<EditTeamDto>> Post([FromBody] EditTeamDto team)
        {
            try
            {
                var created = await _teamsService.InsertTeamAsync(team);
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
        public async Task<ActionResult> Put(Guid id, [FromBody] EditTeamDto value)
        {
            try
            {
                await _teamsService.UpdateTeamAsync(value, id);
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
                await _teamsService.DeleteTeamAsync(id);
                return Ok();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [MapToApiVersion("1.0")]
        [HttpPost("{id}/players")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> RegisterTeamPlayer(Guid id, [FromBody] UserDto userDto)
        {
            try
            {
                await _teamsService.RegisterTeamPlayerAsync(id, userDto);
                return Ok();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [MapToApiVersion("1.0")]
        [HttpDelete("{id}/players")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteTeamPlayer(Guid id, [FromBody] UserDto userDto)
        {
            try
            {
                await _teamsService.DeleteTeamPlayerAsync(id, userDto);
                return Ok();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [MapToApiVersion("1.0")]
        [HttpPost("{id}/coaches")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> RegisterTeamCoach(Guid id, [FromBody] UserDto userDto)
        {
            try
            {
                await _teamsService.RegisterTeamCoachAsync(id, userDto);
                return Ok();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [MapToApiVersion("1.0")]
        [HttpDelete("{id}/coaches")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteTeamCoach(Guid id, [FromBody] UserDto userDto)
        {
            try
            {
                await _teamsService.DeleteTeamCoachAsync(id, userDto);
                return Ok();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
