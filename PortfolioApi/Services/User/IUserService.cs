using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Models.User;

namespace PortfolioApi.Services.User
{
    public interface IUserService
    {
        Task<string> UploadImage(IFormFile imageFile, string fileName);
        Task<Stream> GetImage(string imageName);
        Task<UserDto_Return> CreateUserAsync(UserDto_Creation newUser);
    }
}
