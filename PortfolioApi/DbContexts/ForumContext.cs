using Microsoft.EntityFrameworkCore;
using PortfolioApi.Entities;

namespace PortfolioApi.DbContexts
{
    public class ForumContext : DbContext
    {
        public DbSet<ProfileCard> ProfileCards { get; set; }
        public DbSet<Interest> Interests { get; set; }

        public ForumContext(DbContextOptions<ForumContext> options)
            : base(options) 
        {
            
        }
    }

    
}
