using Microsoft.AspNetCore.Mvc;
using VolleyballAPI.Interfaces;
using VolleyballAPI.Exceptions;
using VolleyballAPI.Dtos.TournamentDtos;
using VolleyballAPI.Dtos.TeamDtos;
using VolleyballAPI.Dtos.UserDtos;
using VolleyballAPI.Services;

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
        public async Task<ActionResult<EditTournamentDto>> CreateTournament([FromBody] EditTournamentDto tournament)
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
        public async Task<ActionResult> UpdateTournament(Guid id, [FromBody] EditTournamentDto value)
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
        [HttpPost("{id}/tournamentCompetitors")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> RegisterTournamentCompetitor(Guid id, [FromBody] TeamDto team)
        {
            try
            {
                await _tournamentsService.RegisterTournamentCompetitorAsync(id, team);
                return Ok();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [MapToApiVersion("1.0")]
        [HttpDelete("{id}/tournamentCompetitors/{teamId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteTournamentCompetitor(Guid id, Guid teamId)
        {
            try
            {
                await _tournamentsService.DeleteTournamentCompetitorAsync(id, teamId);
                return Ok();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [MapToApiVersion("1.0")]
        [HttpPut("{id}/schedule")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> SetTournamentMatches(Guid id, [FromBody] List<TeamDto> newTeams)
        {
            try
            {
                await _tournamentsService.SetTournamentMatchesAsync(id, newTeams);
                return Ok();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
