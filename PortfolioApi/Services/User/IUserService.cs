using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Models.User;

namespace PortfolioApi.Services.User
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto_Return>> GetAllUsersAsync();
        Task<UserDto_Return> CreateUserAsync(UserDto_Creation newUser);
        Task<UserDto_Return> GetUserAsync(string username, string password);

        Task<string> UploadImage(IFormFile imageFile, string fileName);
        Task<Stream> GetImage(string imageName);
    }
}
