using Microsoft.AspNetCore.Mvc;
using VolleyballAPI.Dtos;
using VolleyballManagementAppBackend.Dtos;
using VolleyballManagementAppBackend.Interfaces;

namespace VolleyballManagementAppBackend.Controllers
{
    [Route("teams")]
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
        public async Task<ActionResult<TeamDto>> Get(Guid id)
        {
            return await _teamsService.GetTeamAsync(id);
        }

        [MapToApiVersion("1.0")]
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<TeamDto>>> Get()
        {
            return (await _teamsService.GetTeamsAsync()).ToList();
        }

        [MapToApiVersion("1.0")]
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<TeamDto>> Post([FromBody] TeamDto team)
        {
            var created = await _teamsService.InsertTeamAsync(team);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [MapToApiVersion("1.0")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Put(Guid id, [FromBody] TeamDto value)
        {
            await _teamsService.UpdateTeamAsync(value, id);
            return NoContent();
        }

        [MapToApiVersion("1.0")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _teamsService.DeleteTeamAsync(id);
            return NoContent();
        }

        [MapToApiVersion("1.0")]
        [HttpGet("{id}/players")]
        public async Task<ActionResult<IEnumerable<PlayerDetailsDto>>> GetPlayers(Guid id)
        {
            return (await _teamsService.GetTeamPlayersAsync(id)).ToList();
        }
    }
}
