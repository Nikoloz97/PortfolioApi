using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.DataAccess.User;
using PortfolioApi.Models.User;
using PortfolioApi.Services.Authentication;
using PortfolioApi.Services.User;

namespace PortfolioApi.Controllers.User
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public UserController(IUserRepository userRepository, IMapper mapper, IUserService userService, IAuthService authService)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            // TODO: Mapping should be happening in the service, not in controller
            // Instead of awaiting for UserEntities, it should be UserDto_Return 

            var UserEntities = await _userRepository.GetAllUsersAsync();

            return Ok(_mapper.Map<IEnumerable<UserDto_Return>>(UserEntities));
        }

        [HttpGet("{username}/{password}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(string username, string password)
        {
            var UserEntity = await _userRepository.GetUserAsync(username, password);

            return Ok(_mapper.Map<UserDto_Return>(UserEntity));
        }

        [HttpPost]
        public async Task<ActionResult<UserDto_Return>> CreateUser([FromForm] UserDto_Creation newUser)
        {
            var newUserEntity = await _userService.CreateUserAsync(newUser);

            var newUserToReturn = _mapper.Map<UserDto_Return>(newUserEntity);

            return CreatedAtRoute("GetUser",
                new
                {
                    username = newUserToReturn.Username,
                    password = newUserToReturn.Password
                },
                newUserToReturn);
        }



    }
}
