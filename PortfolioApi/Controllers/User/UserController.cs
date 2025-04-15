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

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var userDtos = await _userService.GetAllUsersAsync();

            return Ok(userDtos);
        }


        [HttpPost("login", Name = "GetUser")]
        public async Task<IActionResult> GetUser([FromBody] LoginRequestDto loginRequest)
        {
            var result = await _userService.AuthenticateUserAsync(loginRequest);

            // Set JWT token in httpOnly cookie
            if (result.Success)
            {
                // Set cookie with the token
                HttpContext.Response.Cookies.Append("auth_token", result.Token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true, // For HTTPS only
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTime.UtcNow.AddHours(1) // Short expiration time
                });

                return Ok(result.User);
            }

            // Generic error to not leak information
            return Unauthorized(new { message = "Invalid username or password" });
        }

        [HttpPost]
        public async Task<ActionResult<UserDto_Return>> CreateUser([FromForm] UserDto_Creation newUser)
        {
            await _userService.CreateUserAsync(newUser);

            return Ok();
        }

    }
}
