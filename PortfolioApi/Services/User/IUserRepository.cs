using PortfolioApi.DbContexts;
using PortfolioApi.Entities.User;

namespace PortfolioApi.Services.User
{
    public interface IUserRepository
    {
        Task<IEnumerable<PortfolioApi.Entities.User.User>> GetAllUsersAsync();
        Task<PortfolioApi.Entities.User.User?> GetUserAsync(string username);
        Task<bool> UserExistsAsync(string username);
    }
}
