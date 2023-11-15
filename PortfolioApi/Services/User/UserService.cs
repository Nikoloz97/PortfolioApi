using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Models.User;
using PortfolioApi.Services.Authentication;

namespace PortfolioApi.Services.User
{
    public class UserService : IUserService
    {
        private readonly AzureStorageService _storageService;
        private readonly IAuthService _authService;

        public UserService(IAuthService authService)
        {
            string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=portfolioappmedia;AccountKey=VrsNP02howxuz2XojXM4NAfYJZsIiAbSoccQvf8lXdgLTq/11qjKyl+sJn854VQ+9hW7oZ7nOy5w+ASt+pzAaQ==;EndpointSuffix=core.windows.net";
            string containerName = "profileimagescontainer";
            _storageService = new AzureStorageService(storageConnectionString, containerName);
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        }

        public async Task<IActionResult> GetAllUsersAsync()
        {
            var UserEntities = await _userRepository.GetAllUsersAsync();

            return Ok(_mapper.Map<IEnumerable<UserDto_Return>>(UserEntities));
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
            var newUserEntity = new Entities.User.User(newUser.Username, newUser.Password, newUser.Email)
            {
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Bio = newUser.Bio,
                ProfileURL = imageUrl
            };

            await _userRepository.CreateUserAsync(newUserEntity);


        }

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

    }
}
