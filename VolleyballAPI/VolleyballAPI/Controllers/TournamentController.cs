using Microsoft.AspNetCore.Mvc;
using VolleyballAPI.Dtos;
using VolleyballAPI.Interfaces;
using VolleyballManagementAppBackend.Dtos;
using VolleyballManagementAppBackend.Entities;
using VolleyballManagementAppBackend.Interfaces;
using VolleyballManagementAppBackend.Services;

namespace VolleyballAPI.Controllers
{
    [Route("tournament")]
    [ApiVersion("1.0")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly ITournamentService _tournamentService;

        public TournamentController(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        [MapToApiVersion("1.0")]
        [HttpGet("{id}")]
        public async Task<ActionResult<TournamentDto>> Get(Guid id)
        {
            return await _tournamentService.GetTournamentAsync(id);
        }

        [MapToApiVersion("1.0")]
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<TournamentDto>>> Get()
        {
            return (await _tournamentService.GetTournamentsAsync()).ToList();
        }

        [MapToApiVersion("1.0")]
        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<TournamentDto>> Post([FromBody] TournamentDto tournament)
        {
            var created = await _tournamentService.InsertTournamentAsync(tournament);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [MapToApiVersion("1.0")]
        [HttpPut("update/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Put(Guid id, [FromBody] TournamentDto value)
        {
            await _tournamentService.UpdateTournamentAsync(value, id);
            return NoContent();
        }

        [MapToApiVersion("1.0")]
        [HttpDelete("{id}/delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _tournamentService.DeleteTournamentAsync(id);
            return NoContent();
        }


    }
}
