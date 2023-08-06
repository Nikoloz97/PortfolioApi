using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Entities.User;
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
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(newUser.ProfileURL.FileName);

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "ProfileImages", fileName);

            // Creates new file under "ProfileImages" directory 
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await newUser.ProfileURL.CopyToAsync(stream);
            }

            // Manually map (due to ProfileURL)
            var newUserEntity = new Entities.User.User(newUser.Username, newUser.Password, newUser.Email)
            {
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Bio = newUser.Bio,
                ProfileURL = fileName
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
