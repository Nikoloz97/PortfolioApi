using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PortfolioApi.DataAccess.User;
using PortfolioApi.Exceptions;
using PortfolioApi.Models.User;
using PortfolioApi.Services.Authentication;

namespace PortfolioApi.Services.User
{
    public class UserService : IUserService
    {
        private readonly AzureStorageService _storageService;
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper, IUserRepository userRepository,
            IAuthService authService
            )
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));

            // TODO: Find why this works without dependency injecting _storageService  
            string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=portfolioappmedia;AccountKey=VrsNP02howxuz2XojXM4NAfYJZsIiAbSoccQvf8lXdgLTq/11qjKyl+sJn854VQ+9hW7oZ7nOy5w+ASt+pzAaQ==;EndpointSuffix=core.windows.net";
            string containerName = "profileimagescontainer";
            _storageService = new AzureStorageService(storageConnectionString, containerName);
        }

        // User
        // Get

        public async Task<IEnumerable<UserDto_Return>> GetAllUsersAsync()
        {
            var UserEntities = await _userRepository.GetAllUsersAsync();

            var UserDtos = _mapper.Map<IEnumerable<UserDto_Return>>(UserEntities);

            return UserDtos;
        }

        public async Task<UserDto_Return> GetUserAsync(string username, string password)
        {
            var potentialUserEntity = await _userRepository.GetUserAsync(username) ?? throw new UsernameNotFoundException();

            if (VerifyPassword(password, potentialUserEntity.Password))
            {
                var userDto = _mapper.Map<UserDto_Return>(potentialUserEntity);

                userDto.Token = await _authService.GenerateJwtToken(userDto);

                return userDto;
            }
            else
            {
                throw new PasswordNotFoundException();
            }
        }


        // Post

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

            var newUserDto = _mapper.Map<UserDto_Return>(newUserEntity);

            var token = await _authService.GenerateJwtToken(newUserDto);

            newUserDto.Token = token;

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
