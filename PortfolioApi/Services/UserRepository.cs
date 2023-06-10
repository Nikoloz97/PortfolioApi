﻿using Microsoft.EntityFrameworkCore;
using PortfolioApi.DbContexts;
using PortfolioApi.Entities.User;
using PortfolioApi.Models;

namespace PortfolioApi.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _userContext;

        public UserRepository(UserContext userContext)
        {
            _userContext = userContext ?? throw new ArgumentException(nameof(userContext)); 
        }
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userContext.Users
                                    .OrderBy(x => x.Id)
                                    .ToListAsync();
        }
        public async Task<User?> GetUserAsync(string username)
        {
            return await _userContext.Users
                                        .Where(x => x.Username == username)
                                        .FirstOrDefaultAsync();
        }

        public async Task<bool> UserExistsAsync(string username)
        {
            return await _userContext.Users.AnyAsync(x => x.Username == username);
        }
    }
}
