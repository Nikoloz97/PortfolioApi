using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Models.User;
using PortfolioApi.Services.User;

namespace PortfolioApi.Controllers.User
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserController(IUserRepository UserRepository, IMapper mapper)
        {
            _userRepository = UserRepository ?? throw new ArgumentNullException(nameof(UserRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var UserEntities = await _userRepository.GetAllUsersAsync();

            return Ok(_mapper.Map<IEnumerable<UserDto>>(UserEntities));
        }

        [HttpGet("{username}/{password}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(string username, string password)
        {
            var UserEntity = await _userRepository.GetUserAsync(username, password);

            return Ok(_mapper.Map<UserDto>(UserEntity));
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] UserDto_Creation newUser)
        {
            var newUserEntity = _mapper.Map<Entities.User.User>(newUser);

            await _userRepository.CreateUserAsync(newUserEntity);

            var newUserToReturn = _mapper.Map<Models.User.UserDto>(newUserEntity);

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
