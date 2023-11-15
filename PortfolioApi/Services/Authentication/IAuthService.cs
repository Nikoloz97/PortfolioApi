
using PortfolioApi.Models.User;

namespace PortfolioApi.Services.Authentication
{
    public interface IAuthService
    {
        Task<UserDto_Return> GetUserAsync(string username, string password);
        Task<string> GenerateJwtToken(UserDto_Return user);
    }
}
