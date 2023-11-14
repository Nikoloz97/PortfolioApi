using PortfolioApi.Models.User;

namespace PortfolioApi.Services.Authentication
{
    public class AuthService : IAuthService
    {
        public async Task<UserDto_Return> Register(UserDto_Creation user)
        {
            return new UserDto_Return();
        }
        public async Task<UserDto_Return> Login(string username, string password)
        {
            return new UserDto_Return();
        }
        public async Task<string> GenerateJwtToken(UserDto_Return user)
        {
            return "";
        }
    }
}
