using Microsoft.AspNetCore.Mvc;
using VolleyballAPI.Dtos;
using VolleyballAPI.Interfaces;
using VolleyballAPI.Exceptions;

namespace VolleyballAPI.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<ActionResult<TournamentDetailsDto>> GetTournamentById(Guid id)
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
        //[Authorize]
        public async Task<ActionResult<IEnumerable<TournamentHeaderDto>>> GetAllTournaments()
        {
            try
            {
                var tournamentsList = (await _tournamentsService.GetTournamentsAsync()).ToList();
                return Ok(tournamentsList);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [MapToApiVersion("1.0")]
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<RegisterTournamentDto>> CreateTournament([FromBody] RegisterTournamentDto tournament)
        {
            try
            {
                var created = await _tournamentsService.InsertTournamentAsync(tournament);
                return CreatedAtAction(nameof(GetTournamentById), new { id = created.Id }, created);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [MapToApiVersion("1.0")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> UpdateTournament(Guid id, [FromBody] RegisterTournamentDto value)
        {
            try
            {
                await _tournamentsService.UpdateTournamentAsync(value, id);
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
        public async Task<ActionResult> DeleteTournament(Guid id)
        {
            try
            {
                await _tournamentsService.DeleteTournamentAsync(id); 
                return Ok();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [MapToApiVersion("1.0")]
        [HttpPost("{id}/teams")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> RegisterTeam(Guid id, [FromBody] RegisterTeamDto team)
        {
            try
            {
                await _tournamentsService.RegisterTeamAsync(id, team.TeamId);
                return Ok();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [MapToApiVersion("1.0")]
        [HttpGet("{id}/teams")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<TeamDetailsDto>>> GetTeams(Guid id)
        {
            try
            {
                var teams = await _tournamentsService.GetTeamsAsync(id);
                return Ok(teams);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
