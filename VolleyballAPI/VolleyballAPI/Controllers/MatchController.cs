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
    public class MatchController : ControllerBase
    { 
        private readonly IMatchService _matchService;

        public MatchController(IMatchService matchService)
        {
            _matchService = matchService;
        }

        [MapToApiVersion("1.0")]
        [HttpGet("{id}")]
        public async Task<ActionResult<MatchDetailsDto>> Get(Guid id)
        {
            try
            {
                var match = await _matchService.GetMatchAsync(id);
                return Ok(match);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [MapToApiVersion("1.0")]
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<MatchDetailsDto>>> Get()
        {
            try
            {
                var matchesList = (await _matchService.GetMatchesAsync()).ToList();
                return Ok(matchesList);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [MapToApiVersion("1.0")]
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<MatchDetailsDto>> Post([FromBody] MatchDetailsDto match)
        {
            try
            {
                var created = await _matchService.InsertMatchAsync(match);
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
        public async Task<ActionResult> Put(Guid id, [FromBody] MatchDetailsDto value)
        {
            try
            {
                await _matchService.UpdateMatchAsync(value, id);
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
                await _matchService.DeleteMatchAsync(id);
                return Ok();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [MapToApiVersion("1.0")]
        [HttpGet("{id}/teams")]
        public async Task<ActionResult<IEnumerable<TeamDetailsDto>>> GetTeams(Guid id)
        {
            try
            {
                var matchTeams = (await _matchService.GetMatchTeamsAsync(id)).ToList();
                return Ok(matchTeams);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
