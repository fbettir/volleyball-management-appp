using Microsoft.AspNetCore.Mvc;
using VolleyballManagementAppBackend.Dtos;
using VolleyballManagementAppBackend.Interfaces;

namespace VolleyballManagementAppBackend.Controllers
{
    [Route("team")]
    [ApiVersion("1.0")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }
        
        [MapToApiVersion("1.0")]
        [HttpGet("{id}")]
        public async Task<ActionResult<TeamDto>> Get(Guid id)
        {
            return await _teamService.GetTeamAsync(id);
        }

        [MapToApiVersion("1.0")]
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<TeamDto>>> Get()
        {
            return (await _teamService.GetTeamsAsync()).ToList();
        }

        [MapToApiVersion("1.0")]
        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<TeamDto>> Post([FromBody] TeamDto team)
        {
            var created = await _teamService.InsertTeamAsync(team);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [MapToApiVersion("1.0")]
        [HttpPut("update/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Put(Guid id, [FromBody] TeamDto value)
        {
            await _teamService.UpdateTeamAsync(value, id);
            return NoContent();
        }

        [MapToApiVersion("1.0")]
        [HttpDelete("{id}/delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _teamService.DeleteTeamAsync(id);
            return NoContent();
        }
    }
}
