using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Storage.Shared.Protocol;
using PortfolioApi.Services;

namespace PortfolioApi.Controllers.User
{
    [ApiController]
    [Route("api/forum/[controller]")]
    public class ImagesController : Controller
    {
        private readonly IAzureStorageService _storageService;

        public ImagesController(IAzureStorageService storageService)
        {
            _storageService = storageService;
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

            return File(imageStream, "image/jpeg");
        }
    }
}
