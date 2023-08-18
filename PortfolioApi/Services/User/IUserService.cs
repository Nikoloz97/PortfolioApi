using Microsoft.AspNetCore.Mvc;

namespace PortfolioApi.Services.User
{
    public interface IUserService
    {
        Task<string> UploadImage(IFormFile imageFile, string fileName);
        Task<Stream> GetImage(string imageName);
    }
}
