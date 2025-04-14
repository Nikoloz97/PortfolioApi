using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Models.User;
using PortfolioApi.Services.User;

namespace PortfolioApi.Controllers.User
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        // Get

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var userDtos = await _userService.GetAllUsersAsync();

            return Ok(userDtos);
        }

        // Post

        [HttpPost("login", Name = "GetUser")]
        public async Task<IActionResult> GetUser([FromBody] LoginRequestDto loginRequest)
        {
            var userDto = await _userService.GetUserAsync(loginRequest);

            return Ok(userDto);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto_Return>> CreateUser([FromForm] UserDto_Creation newUser)
        {
            await _userService.CreateUserAsync(newUser);

            return Ok();
        }

    }
}
