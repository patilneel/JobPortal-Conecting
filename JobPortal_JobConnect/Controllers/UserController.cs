namespace JobPortal_JobConnect.Controllers
{
    using JobPortal_JobConnect.Models;
    using JobPortal_JobConnect.Services;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<User>> GetUser(int userId)
        {
            var user = await _userService.GetUserAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            if (user == null)
            {
                return BadRequest("Invalid user data");
            }

            // Check if a user with the same username already exists
            var existingUser = await _userService.GetUserByUsernameAsync(user.Username);
            if (existingUser != null)
            {
                return Conflict("A user with this username already exists.");
            }

            var createdUser = await _userService.CreateUserAsync(user);
            return CreatedAtAction("GetUser", new { userId = createdUser.UserId }, createdUser);
        }
    }

}
