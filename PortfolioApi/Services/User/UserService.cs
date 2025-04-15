using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PortfolioApi.DataAccess.User;
using PortfolioApi.Exceptions;
using PortfolioApi.Models.User;
using PortfolioApi.Services.Authentication;
using PortfolioApi.Services.Forum;

namespace PortfolioApi.Services.User
{
    public class UserService : IUserService
    {
        private readonly IAzureStorageService _storageService;
        private readonly IAuthService _authService;
        private readonly IForumProfileService _forumProfileService;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<Entities.User.User> _passwordHasher;

        public UserService(IMapper mapper, IUserRepository userRepository,
            IAuthService authService, IPasswordHasher<Entities.User.User> passwordHasher, IForumProfileService forumProfileService,
            IAzureStorageService storageService
            )
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
            _forumProfileService = forumProfileService ?? throw new ArgumentNullException(nameof(authService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _storageService = storageService;
            _passwordHasher = passwordHasher;
        }

        // User
        // Get

        public async Task<IEnumerable<UserDto_Return>> GetAllUsersAsync()
        {
            var UserEntities = await _userRepository.GetAllUsersAsync();

            var UserDtos = _mapper.Map<IEnumerable<UserDto_Return>>(UserEntities);

            return UserDtos;
        }

        public async Task<AuthResult> AuthenticateUserAsync(LoginRequestDto loginRequest)
        {
            // take the same amount of time regardless of whether the user exists
            var userExists = await _userRepository.DoesUsernameExistAsync(loginRequest.Username);

            if (!userExists)
            {
                // dummy password verification to prevent timing attacks
                _passwordHasher.VerifyHashedPassword(null,
                    "$PBKDF2$V=3$I=10000$GasJ4AkSLPgPKVnqTVLgYw==$XGUL7XiG1m/UOoQuw+8nF3KwvLIzVYLMbw1H8TJYNp4=",
                    loginRequest.Password);

                return new AuthResult { Success = false };
            }

            var user = await _userRepository.GetUserAsync(loginRequest.Username);
            var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(
                null, user.Password, loginRequest.Password);

            if (passwordVerificationResult == PasswordVerificationResult.Success)
            {
                var userDto = _mapper.Map<UserDto_Return>(user);
                var token = await _authService.GenerateJwtToken(userDto);

                return new AuthResult
                {
                    Success = true,
                    User = userDto,
                    Token = token
                };
            }

            return new AuthResult { Success = false };
        }

        public async Task<UserDto_Return> CreateUserAsync(UserDto_Creation newUser)
        {
            string? imageUrl = null;

            if (newUser.ProfileImageFile != null && newUser.ProfileImageFile.Length != 0)
            {
                var fileName = newUser.Username + "\\" + DateTime.Now + "\\" + Path.GetExtension(newUser.ProfileImageFile.FileName);
                imageUrl = await UploadImage(newUser.ProfileImageFile, fileName);
            }

            // Manually map (due to ProfileURL)
            var newUserEntityToCreate = new Entities.User.User(newUser.Username, HashPassword(newUser.Password), newUser.Email)
            {
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Bio = newUser.Bio,
                ProfileURL = imageUrl
            };

            var newUserEntity = await _userRepository.CreateUserAsync(newUserEntityToCreate);

            // TODO: Do we want this here? 
            // Should FP be automatically created when user is created? Or should we give user the option whether they want it? 
            // await _forumProfileService.CreateForumProfileAsync(newUserEntity.UserId, newUserEntity.Username, newUserEntity.ProfileURL);

            var newUserDto = _mapper.Map<UserDto_Return>(newUserEntity);

            return newUserDto;
        }

        // Helpers

        private string HashPassword(string password)
        {
            var passwordHasher = new PasswordHasher<UserDto_Creation>(); 
            return passwordHasher.HashPassword(null, password);
        }

        private bool VerifyPassword(string providedPassword, string hashedPassword)
        {
            var passwordHasher = new PasswordHasher<UserDto_Creation>();
            var result = passwordHasher.VerifyHashedPassword(null, hashedPassword, providedPassword);

            // TODO: Create hashing error exception 

            return result == PasswordVerificationResult.Success;
        }

        public async Task<bool> DoesUsernameExistAsync(string username)
        {
            return await _userRepository.DoesUsernameExistAsync(username);
        }

        // StorageService

        public async Task<string> UploadImage(IFormFile imageFile, string fileName)
        {
            using (var imageStream = imageFile.OpenReadStream())
            {
                string imageUrl = await _storageService.UploadImageAsync(fileName, imageStream);
                return imageUrl;
            }
        }

        public async Task<Stream> GetImage(string imageName)
        {
            return await _storageService.GetImageAsync(imageName);
        }

        // TODO: Implement AuthService

    }
}
