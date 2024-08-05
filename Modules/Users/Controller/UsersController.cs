using Microsoft.AspNetCore.Mvc;
using AppraisalTracker.Modules.Users.Service;
using System.Threading.Tasks;
using System;
using AppraisalTracker.Modules.Login;

namespace AppraisalTracker.Modules.Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        // Add new user
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User newUser)
        {
            var addedUser = await _usersService.AddUser(newUser);
            return Ok(addedUser);
        }

        // GET: api/Users
        [HttpGet("all-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _usersService.GetAllUsers();
            return Ok(users);
        }

        // Get single user
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetSingleUser(Guid userId)
        {
            var user = await _usersService.GetSingleUser(userId);
            return Ok(user);
        }

        // Delete user
        [HttpDelete("delete-user/{userId}")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            var deletedUser = await _usersService.DeleteUser(userId);
            return Ok(deletedUser);
        }

        // Authenticate User
        [HttpPost("login")]
        public async Task<UserLoginViewModel> AuthenticateUser([FromBody] LoginModel user)
        {
            Console.WriteLine($"Received Username: {user}");

           var authenticated= await _usersService.AuthenticateUser(user.Username, user.Password);

            // var authenticated = await _usersService.AuthenticateUser(user.Username, user.Password);
            return authenticated;
        }
    }
}
