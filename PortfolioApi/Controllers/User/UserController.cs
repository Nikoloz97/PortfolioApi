using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.DataAccess.User;
using PortfolioApi.Models.User;
using PortfolioApi.Services.User;

namespace PortfolioApi.Controllers.User
{
    [ApiController]
    [Route("api/user")]
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

        [HttpGet("{username}/{password}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(string username, string password)
        {
            var userDto = await _userService.GetUserAsync(username, password);

            return Ok(userDto);
        }

        // Post

        [HttpPost]
        public async Task<ActionResult<UserDto_Return>> CreateUser([FromForm] UserDto_Creation newUser)
        {
            var newUserDto = await _userService.CreateUserAsync(newUser);

            return CreatedAtRoute("GetUser",
                new
                {
                    username = newUserDto.Username,
                    password = newUserDto.Password
                },
                newUserDto);
        }



    }
}
