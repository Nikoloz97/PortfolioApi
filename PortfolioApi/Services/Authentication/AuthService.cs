using Microsoft.IdentityModel.Tokens;
using PortfolioApi.DataAccess.User;
using PortfolioApi.Models.User;
using PortfolioApi.Services.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PortfolioApi.Services.Authentication
{
    public class AuthService : IAuthService
    {
        // Replace this with your actual secret key
        private const string JwtSecretKey = "your_secret_key";

        public async Task<string> GenerateJwtToken(UserDto_Return user)
        {
            // Generate JWT token with user claims
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JwtSecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, user.Username),
                    // You can add more claims as needed
                }),
                Expires = DateTime.UtcNow.AddHours(1), // Token expiration time
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
