using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.DataAccess.User;
using PortfolioApi.DbContexts;
using PortfolioApi.Exceptions;
using PortfolioApi.Models.User;
using PortfolioApi.Services.Authentication;

namespace PortfolioApi.Services.User
{
    public class UserService : IUserService
    {
        private readonly AzureStorageService _storageService;
/*        private readonly IAuthService _authService;
*/        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper, IUserRepository userRepository
/*            IAuthService authService
*/            )
        {
/*            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
*/
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));

            // TODO: Find why this works without dependency injecting _storageService  
            string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=portfolioappmedia;AccountKey=VrsNP02howxuz2XojXM4NAfYJZsIiAbSoccQvf8lXdgLTq/11qjKyl+sJn854VQ+9hW7oZ7nOy5w+ASt+pzAaQ==;EndpointSuffix=core.windows.net";
            string containerName = "profileimagescontainer";
            _storageService = new AzureStorageService(storageConnectionString, containerName);
        }

        // Get

        public async Task<IEnumerable<UserDto_Return>> GetAllUsersAsync()
        {
            var UserEntities = await _userRepository.GetAllUsersAsync();

            var UserDtos = _mapper.Map<IEnumerable<UserDto_Return>>(UserEntities);

            return UserDtos;
        }

        public async Task<UserDto_Return> GetUserAsync(string username, string password)
        {
            bool doesUsernameExist = await DoesUsernameExistAsync(username);

            if (!doesUsernameExist)
            {
                throw new UsernameNotFoundException();
            }
            else
            {
                var potentialUserEntity = await _userRepository.GetUserAsync(username, password);

                if (potentialUserEntity == null)
                {
                    throw new PasswordNotFoundException();
                }


                else {
                    var UserDto = _mapper.Map<UserDto_Return>(potentialUserEntity);

                    return UserDto;
                }
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
            var newUserEntityToCreate = new Entities.User.User(newUser.Username, newUser.Password, newUser.Email)
            {
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Bio = newUser.Bio,
                ProfileURL = imageUrl
            };

            var newUserEntity = await _userRepository.CreateUserAsync(newUserEntityToCreate);

            var newUserDto = _mapper.Map<UserDto_Return>(newUserEntity);

            return newUserDto;
        }

        // Helpers

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
