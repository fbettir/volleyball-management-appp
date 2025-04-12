using Microsoft.AspNetCore.Mvc;
using VolleyballAPI.Dtos;
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
        public async Task<ActionResult<IEnumerable<TeamDetailsDto>>> Get()
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
        public async Task<ActionResult<TeamDetailsDto>> Post([FromBody] TeamDetailsDto team)
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
        public async Task<ActionResult> Put(Guid id, [FromBody] TeamDetailsDto value)
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
        [HttpGet("{id}/players")]
        public async Task<ActionResult<IEnumerable<UserDetailsDto>>> GetPlayers(Guid id)
        {
            try
            {
                var teamPlayers = (await _teamsService.GetTeamPlayersAsync(id)).ToList();
                return Ok(teamPlayers);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [MapToApiVersion("1.0")]
        [HttpPost("{id}/players")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> RegisterTeamPlayer(Guid id, [FromBody] UserDetailsDto playerDetailsDto)
        {
            try
            {
                await _teamsService.RegisterTeamPlayerAsync(id, playerDetailsDto);
                return Ok();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [MapToApiVersion("1.0")]
        [HttpGet("{id}/trainings")]
        public async Task<ActionResult<IEnumerable<TrainingDetailsDto>>> GetTrainingsAsync(Guid id)
        {
            try
            {
                var trainings = (await _teamsService.GetTrainingsAsync(id)).ToList();
                return Ok(trainings);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
