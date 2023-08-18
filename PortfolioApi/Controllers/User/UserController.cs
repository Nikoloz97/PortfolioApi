using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.DataAccess.User;
using PortfolioApi.Entities.User;
using PortfolioApi.Models.User;
using PortfolioApi.Services;
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

        public UserController(IUserRepository userRepository, IMapper mapper, IUserService userService)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(UserRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
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
            string? imageUrl = null;

            if (newUser.ProfileImageFile != null && newUser.ProfileImageFile.Length != 0)
            {
                var fileName = newUser.Username + "\\" + DateTime.Now + "\\" + Path.GetExtension(newUser.ProfileImageFile.FileName);
                imageUrl = await _userService.UploadImage(newUser.ProfileImageFile, fileName);
            }

            // Manually map (due to ProfileURL)
            var newUserEntity = new Entities.User.User(newUser.Username, newUser.Password, newUser.Email)
            {
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Bio = newUser.Bio,
                ProfileURL = imageUrl
            };

            await _userRepository.CreateUserAsync(newUserEntity);

            var newUserToReturn = _mapper.Map<Models.User.UserDto_Return>(newUserEntity);

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
