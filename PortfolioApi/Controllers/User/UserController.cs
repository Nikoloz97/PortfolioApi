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

        [HttpGet("{username}")]
        public async Task<IActionResult> GetUser(string username, string password)
        {
            var UserEntity = await _userRepository.GetUserAsync(username, password);

            return Ok(_mapper.Map<UserDto>(UserEntity));
        }

    }
}
