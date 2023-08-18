using Microsoft.AspNetCore.Mvc;

namespace PortfolioApi.Services.User
{
    public class UserService : IUserService
    {
        private readonly AzureStorageService _storageService;

        public UserService()
        {
            string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=portfolioappmedia;AccountKey=VrsNP02howxuz2XojXM4NAfYJZsIiAbSoccQvf8lXdgLTq/11qjKyl+sJn854VQ+9hW7oZ7nOy5w+ASt+pzAaQ==;EndpointSuffix=core.windows.net";
            string containerName = "profileimagescontainer";
            _storageService = new AzureStorageService(storageConnectionString, containerName);
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
