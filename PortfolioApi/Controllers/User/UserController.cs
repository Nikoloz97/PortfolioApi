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
        // Used for returning file paths (for media) 
        private readonly string baseURL_nonSSL = "http://localhost:5190/";
        private readonly string baseURL_SSL = "https://localhost:7047/";


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
            // TODO: change guid -> date (with minutes/seconds to make it unique)
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(newUser.ProfileURL.FileName);

            // Create 'Media' directory 
            var mediaDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Media");
            if (!Directory.Exists(mediaDirectory))
            {
                Directory.CreateDirectory(mediaDirectory);
            }

            // Create subdirectory <User.Username>
            var userDirectory = Path.Combine(mediaDirectory, newUser.Username);
            if (!Directory.Exists(userDirectory))
            {
                Directory.CreateDirectory(userDirectory);
            }

            // Create 'ProfileImage' subdirectory 
            var profileImageDirectory = Path.Combine(userDirectory, "ProfileImage");

            if (!Directory.Exists(profileImageDirectory))
            {
                Directory.CreateDirectory(profileImageDirectory);
            }

             // Save the file to location (e.g., "Media/<User.Username>/ProfileImage")
            var relativeFilePath = Path.Combine("Media", newUser.Username, "ProfileImage", fileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), relativeFilePath);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await newUser.ProfileURL.CopyToAsync(stream);
            }

            // Create FullFilePath for front-end to use 
            var FullFilePathToStore = (baseURL_nonSSL + relativeFilePath).Replace("\\", "/");

            // Manually map (due to ProfileURL)
            var newUserEntity = new Entities.User.User(newUser.Username, newUser.Password, newUser.Email)
            {
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Bio = newUser.Bio,
                ProfileURL = FullFilePathToStore
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
