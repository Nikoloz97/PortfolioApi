using PortfolioApi.DbContexts;
using PortfolioApi.Entities.User;

namespace PortfolioApi.Services
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserAsync(string username);
        Task<bool> UserExistsAsync(string username);
    }
}
