
using PortfolioApi.Models.User;

namespace PortfolioApi.Services.Authentication
{
    public interface IAuthService
    {
        Task<string> GenerateJwtToken(UserDto_Return user);
    }
}
