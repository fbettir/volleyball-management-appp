using Microsoft.AspNetCore.Mvc;
using VolleyballAPI.Dtos;
using VolleyballAPI.Interfaces;
using VolleyballAPI.Exceptions;

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
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<UserHeaderDto>> Post([FromBody] UserHeaderDto user)
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
        public async Task<ActionResult> Put(Guid id, [FromBody] UserDetailsDto value)
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

    }
}
