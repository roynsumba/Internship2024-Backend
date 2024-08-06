using AppraisalTracker.Modules.Users.Models;
using AppraisalTracker.Modules.Users.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppraisalTracker.Modules.Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // Add new user
        [HttpPost("register-user")]
        public async Task<IActionResult> AddUser([FromBody] User newUser)
        {
            var addedUser = await _userService.AddUser(newUser);
            return Ok(addedUser);
        }

        // GET: api/Users
        [HttpGet("get-all-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        // Get single user
        [HttpGet("get-user/{userId}")]
        public async Task<IActionResult> GetSingleUser(Guid userId)
        {
            var user = await _userService.GetSingleUser(userId);
            return Ok(user);
        }

        // Delete user
        [HttpDelete("delete-user/{userId}")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            var deletedUser = await _userService.DeleteUser(userId);
            return Ok(deletedUser);
        }

        // Authenticate User
        [HttpPost("login")]
        public async Task<UserLoginViewModel> AuthenticateUser([FromBody] LoginModel user)
        {
            var authenticated = await _userService.AuthenticateUser(user.Username, user.Password);
            return authenticated;
        }
    }
}
