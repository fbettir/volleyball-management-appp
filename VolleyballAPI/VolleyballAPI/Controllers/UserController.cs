using Microsoft.AspNetCore.Mvc;
using VolleyballAPI.Interfaces;
using VolleyballAPI.Exceptions;
using VolleyballAPI.Dtos.UserDtos;
using VolleyballAPI.Services;
using VolleyballAPI.Dtos.TeamDtos;
using VolleyballAPI.Dtos.TrainingDtos;
using VolleyballAPI.Dtos.TournamentDtos;
using Microsoft.EntityFrameworkCore;
using VolleyballAPI.Entities;

namespace VolleyballAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [MapToApiVersion("1.0")]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDetailsDto>> Get(Guid id)
        {
            try
            {
                var user = await _userService.GetUserDetailsAsync(id);
                return Ok(user);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [MapToApiVersion("1.0")]
        [HttpPost("sync")]
        public async Task<ActionResult<UserDetailsDto>> SyncUserFromAuth0([FromBody] Auth0UserDto dto)
        {
            try
            {
                var user = await _userService.GetOrCreateByAuth0Async(dto);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [MapToApiVersion("1.0")]
        [HttpGet("auth0/{auth0Id}")]
        public async Task<ActionResult<UserDetailsDto>> GetByAuth0Id(string auth0Id)
        {
            try
            {
                var user = await _userService.GetByAuth0IdAsync(auth0Id);
                return Ok(user);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [MapToApiVersion("1.0")]
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<UserHeaderDto>>> Get()
        {
            try
            {
                var usersList = (await _userService.GetUsersAsync()).ToList();
                return Ok(usersList);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [MapToApiVersion("1.0")]
        [HttpGet("coaches")]
        public async Task<ActionResult<IEnumerable<UserHeaderDto>>> GetCoaches()
        {
            try
            {
                var coachesList = (await _userService.GetCoachesAsync()).ToList();
                return Ok(coachesList);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [MapToApiVersion("1.0")]
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<EditUserDto>> Post([FromBody] EditUserDto user)
        {
            try
            {
                var created = await _userService.InsertUserAsync(user);
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
        public async Task<ActionResult> Put(Guid id, [FromBody] EditUserDto value)
        {
            try
            {
                await _userService.UpdateUserAsync(value, id);
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
                await _userService.DeleteUserAsync(id);
                return Ok();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [MapToApiVersion("1.0")]
        [HttpPost("{id}/favouriteTeams")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> RegisterFavouriteTeam(Guid id, [FromBody] TeamDto teamDto)
        {
            try
            {
                await _userService.RegisterFavouriteTeamAsync(id, teamDto);
                return Ok();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [MapToApiVersion("1.0")]
        [HttpDelete("{id}/favouriteTeams")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteFavouriteTeam(Guid id, [FromBody] TeamDto teamDto)
        {
            try
            {
                await _userService.DeleteFavouriteTeamAsync(id, teamDto);
                return Ok();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [MapToApiVersion("1.0")]
        [HttpPost("{id}/favouriteTrainings")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> RegisterFavouriteTraining(Guid id, [FromBody] TrainingDto trainingDto)
        {
            try
            {
                await _userService.RegisterFavouriteTrainingAsync(id, trainingDto);
                return Ok();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [MapToApiVersion("1.0")]
        [HttpDelete("{id}/favouriteTrainings")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteFavouriteTraining(Guid id, [FromBody] TrainingDto trainingDto)
        {
            try
            {
                await _userService.DeleteFavouriteTrainingAsync(id, trainingDto);
                return Ok();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [MapToApiVersion("1.0")]
        [HttpPost("{id}/favouriteTournaments")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> RegisterFavouriteTournament(Guid id, [FromBody] TournamentDto tournamentDto)
        {
            try
            {
                await _userService.RegisterFavouriteTournamentAsync(id, tournamentDto);
                return Ok();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [MapToApiVersion("1.0")]
        [HttpDelete("{id}/favouriteTournaments")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteFavouriteTournament(Guid id, [FromBody] TournamentDto tournamentDto)
        {
            try
            {
                await _userService.DeleteFavouriteTournamentAsync(id, tournamentDto);
                return Ok();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
