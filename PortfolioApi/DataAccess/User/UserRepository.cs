using Microsoft.EntityFrameworkCore;
using PortfolioApi.DbContexts;

namespace PortfolioApi.DataAccess.User
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _userContext;

        public UserRepository(UserContext userContext)
        {
            _userContext = userContext ?? throw new ArgumentException(nameof(userContext));
        }

        // Get

        public async Task<IEnumerable<Entities.User.User>> GetAllUsersAsync()
        {
            return await _userContext.Users
                                    .OrderBy(x => x.UserId)
                                    .ToListAsync();
        }

        public async Task<Entities.User.User?> GetUserAsync(string username, string password)
        {
           var potentialUser = await _userContext.Users
                                            .Where(x => x.Username == username && x.Password == password)
                                            .FirstOrDefaultAsync();
            return potentialUser;
        }

        // Post

        public async Task<Entities.User.User?> CreateUserAsync(Entities.User.User newUserEntity)
        {
            _userContext.Users.Add(newUserEntity);
            await _userContext.SaveChangesAsync();
            return newUserEntity;
        }

        // Helpers

        public async Task<bool> DoesUsernameExistAsync(string username)
        {
            return await _userContext.Users.AnyAsync(x => x.Username == username);
        }
      
    }
}
