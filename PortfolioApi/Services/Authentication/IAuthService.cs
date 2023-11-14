
using PortfolioApi.Models.User;

namespace PortfolioApi.Services.Authentication
{
    public interface IAuthService
    {
        Task<UserDto_Return> Register(UserDto_Creation user);
        Task<UserDto_Return> Login(string username, string password);
        Task<string> GenerateJwtToken(UserDto_Return user);
    }
}
