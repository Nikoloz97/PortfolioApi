using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Services;

namespace PortfolioApi.Controllers.User
{
    [ApiController]
    [Route("api/forum/[controller]")]
    public class ImagesController : Controller
    {
        private readonly AzureStorageService _storageService;

        public ImagesController()
        {
            string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=portfolioappmedia;AccountKey=VrsNP02howxuz2XojXM4NAfYJZsIiAbSoccQvf8lXdgLTq/11qjKyl+sJn854VQ+9hW7oZ7nOy5w+ASt+pzAaQ==;EndpointSuffix=core.windows.net";
            string containerName = "profileimagescontainer";
            _storageService = new AzureStorageService(storageConnectionString, containerName);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage(IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
                return BadRequest("Invalid image file");

            using (var imageStream = imageFile.OpenReadStream())
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                string imageUrl = await _storageService.UploadImageAsync(fileName, imageStream);
                return Ok(imageUrl);
            }
        }

        [HttpGet("{imageName}")]
        public async Task<IActionResult> GetImage(string imageName)
        {
            Stream imageStream = await _storageService.GetImageAsync(imageName);
            if (imageStream == null)
                return NotFound();

            return File(imageStream, "image/jpeg"); // Adjust the content type based on your image type
        }
    }
}
