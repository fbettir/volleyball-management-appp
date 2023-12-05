using Microsoft.AspNetCore.Mvc;
using VolleyballAPI.Dtos;
using VolleyballAPI.Interfaces;
using VolleyballManagementAppBackend.Dtos;
using VolleyballManagementAppBackend.Entities;
using VolleyballManagementAppBackend.Exceptions;
using VolleyballManagementAppBackend.Interfaces;
using VolleyballManagementAppBackend.Services;

namespace VolleyballAPI.Controllers
{
    [Route("tournaments")]
    [ApiVersion("1.0")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly ITournamentService _tournamentsService;

        public TournamentController(ITournamentService tournamentService)
        {
            _tournamentsService = tournamentService;
        }

        [MapToApiVersion("1.0")]
        [HttpGet("{id}")]
        public async Task<ActionResult<TournamentDto>> GetTournamentById(Guid id)
        {
            try
            {
                var tournament = await _tournamentsService.GetTournamentAsync(id);
                return Ok(tournament);
            }
            catch (EntityNotFoundException ex) 
            {
                return NotFound(ex.Message);
            }

        }

        [MapToApiVersion("1.0")]
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<TournamentDto>>> GetAllTournaments()
        {
            return (await _tournamentsService.GetTournamentsAsync()).ToList();
        }

        [MapToApiVersion("1.0")]
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<TournamentDto>> CreateTournament([FromBody] TournamentDto tournament)
        {
            var created = await _tournamentsService.InsertTournamentAsync(tournament);
            return CreatedAtAction(nameof(GetTournamentById), new { id = created.Id }, created);
        }

        [MapToApiVersion("1.0")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> UpdateTournament(Guid id, [FromBody] TournamentDto value)
        {
            await _tournamentsService.UpdateTournamentAsync(value, id);
            return NoContent();
        }

        [MapToApiVersion("1.0")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteTournament(Guid id)
        {
            await _tournamentsService.DeleteTournamentAsync(id);
            return NoContent();
        }

        [MapToApiVersion("1.0")]
        [HttpPost("{id}/teams")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> RegisterTeam(Guid id, [FromBody] RegisterTeamDto team)
        {
            await _tournamentsService.RegisterTeamAsync(id, team.TeamId);
            return NoContent();
        }
    }
}
