using System.Net;
using Microsoft.EntityFrameworkCore;
using PortfolioApi.DbContexts;
using PortfolioApi.Entities.User;
using PortfolioApi.Models;
using PortfolioApi.Exceptions;

namespace PortfolioApi.DataAccess.User
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _userContext;

        public UserRepository(UserContext userContext)
        {
            _userContext = userContext ?? throw new ArgumentException(nameof(userContext));
        }
        public async Task<IEnumerable<Entities.User.User>> GetAllUsersAsync()
        {
            return await _userContext.Users
                                    .OrderBy(x => x.UserId)
                                    .ToListAsync();
        }
        public async Task<Entities.User.User?> GetUserAsync(string username, string password)
        {
            bool doesUserNameExist = await DoesUsernameExistAsync(username);
            if (!doesUserNameExist)
            {
                throw new UsernameNotFoundException();
            }
            else
            {
                Entities.User.User? potentialUser = await _userContext.Users
                                            .Where(x => x.Username == username && x.Password == password)
                                            .FirstOrDefaultAsync();

                if (potentialUser == null)
                {
                    throw new PasswordNotFoundException();
                }

                else { return potentialUser; }
            }
        }

        public async Task<bool> DoesUsernameExistAsync(string username)
        {
            return await _userContext.Users.AnyAsync(x => x.Username == username);
        }

        public async Task CreateUserAsync(Entities.User.User newUserEntity)
        {
            _userContext.Users.Add(newUserEntity);
            await _userContext.SaveChangesAsync();
        }
    }
}
