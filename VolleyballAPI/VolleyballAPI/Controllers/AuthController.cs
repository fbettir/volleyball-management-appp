using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using VolleyballAPI.Dtos;
using VolleyballManagementAppBackend.Exceptions;

namespace VolleyballAPI.Controllers
{
    [Route("auth")]
    [ApiVersion("1.0")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthenticationService _authService;
        public AuthController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        //[MapToApiVersion("1.0")]
        //[HttpGet("{id}")]
        //public async Task<ActionResult<AuthDto>> Get(Guid id)
        //{
        //    try
        //    {
        //        var userName = await _authService
        //        return Ok(userName);
        //    }
        //    catch (EntityNotFoundException ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //}
    }
}
