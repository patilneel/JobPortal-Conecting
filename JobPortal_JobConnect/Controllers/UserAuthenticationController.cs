using JobPortal_JobConnect.Models;
using JobPortal_JobConnect.Services;
using JobPortal_JobConnect.Services.JobPortal_JobConnect.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal_JobConnect.Controllers
{
    /// <summary>
    /// User Authentication Controller
    /// </summary>
    /// <tag>Authentication</tag>

    [Route("api/auth")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class UserAuthenticationController : ControllerBase
    {
        private readonly IUserAuthService _authService;

        public UserAuthenticationController(IUserAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register(UserAuthModel model)
        {
            if (ModelState.IsValid)
            {
                _authService.Register(model);
                return Ok("Registration successful");
            }

            return BadRequest(ModelState);
        }

        [HttpPost("login")]
        public IActionResult Login(UserAuthModel model)
        {
            var user = _authService.GetUserByUsername(model.UserAuthName, model.UserAuthPassword);

            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }

            // Implement JWT token generation or other authentication mechanisms.
            // Return an authentication token to the client.
            // Example: return new { Token = GenerateJwtToken(user) };

            return Ok("Login successful");
        }
    }

}
