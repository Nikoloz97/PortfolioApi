using PortfolioApi.DbContexts;
using PortfolioApi.Entities.User;

namespace PortfolioApi.DataAccess.User
{
    public interface IUserRepository
    {
        Task<IEnumerable<Entities.User.User>> GetAllUsersAsync();
        Task<Entities.User.User?> GetUserAsync(string username, string password);
        Task<bool> DoesUsernameExistAsync(string username);
        Task CreateUserAsync(Entities.User.User newUserEntity);
    }
}
