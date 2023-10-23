namespace JobPortal_JobConnect.Controllers
{
    using JobPortal_JobConnect.Models;
    using JobPortal_JobConnect.Services;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using FluentValidation;
    using Microsoft.Extensions.Logging;
    using Swashbuckle.AspNetCore.Annotations;
  

    [Route("api/users")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet("{userId}")]
        [SwaggerOperation(Summary = "Get a user by ID")]
        [SwaggerResponse(200, "The user was found.", typeof(User))]
        [SwaggerResponse(404, "User not found.")]
        public async Task<ActionResult<User>> GetUser(int userId)
        {
            var user = await _userService.GetUserAsync(userId);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            return Ok(user);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new user")]
        [SwaggerResponse(201, "User created.", typeof(User))]
        [SwaggerResponse(400, "Invalid user data.")]
        [SwaggerResponse(409, "A user with the same username already exists.")]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            try
            {
                new UserValidator().ValidateAndThrow(user); 

                var existingUser = await _userService.GetUserByUsernameAsync(user.Username);
                if (existingUser != null)
                {
                    return Conflict("A user with this username already exists.");
                }

                var createdUser = await _userService.CreateUserAsync(user);
                return CreatedAtAction("GetUser", new { userId = createdUser.UserId }, createdUser);
            }
            catch (ValidationException ex)
            {
                _logger.LogError(ex, "User validation failed.");
                return BadRequest(ex.Errors);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the user.");
                return StatusCode(500, "An error occurred.");
            }
        }

        [HttpPut("{userId}")]
        [SwaggerOperation(Summary = "Update a user by ID")]
        [SwaggerResponse(200, "User updated.", typeof(User))]
        [SwaggerResponse(400, "Invalid user data.")]
        [SwaggerResponse(404, "User not found.")]
        public async Task<ActionResult<User>> UpdateUser(int userId, User user)
        {
            try
            {
                if (userId != user.UserId)
                {
                    return BadRequest("User ID in the URL does not match the user object.");
                }

                var existingUser = await _userService.GetUserAsync(userId);
                if (existingUser == null)
                {
                    return NotFound("User not found.");
                }

                new UserValidator().ValidateAndThrow(user); // FluentValidation check

                var updatedUser = await _userService.UpdateUserAsync(user);
                return Ok(updatedUser);
            }
            catch (ValidationException ex)
            {
                _logger.LogError(ex, "User validation failed.");
                return BadRequest(ex.Errors);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the user.");
                return StatusCode(500, "An error occurred.");
            }
        }

        [HttpDelete("{userId}")]
        [SwaggerOperation(Summary = "Delete a user by ID")]
        [SwaggerResponse(204, "User deleted.")]
        [SwaggerResponse(404, "User not found.")]
        public async Task<ActionResult> DeleteUser(int userId)
        {
            var existingUser = await _userService.GetUserAsync(userId);
            if (existingUser == null)
            {
                return NotFound("User not found.");
            }

            await _userService.DeleteUserAsync(userId);
            return NoContent();
        }
    }
}
