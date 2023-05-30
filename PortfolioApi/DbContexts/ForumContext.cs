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

        // Where we can "seed our database" (start with data) 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProfileCard>().HasData(
                new ProfileCard("Future", "Hendrix")
                {
                    Id = 1,
                    Age = 30
                 },
                new ProfileCard("Drake", "Parker")
                {
                    Id = 2,
                    Age = 22

                },
                new ProfileCard("Tom", "Segura")
                {
                    Id = 3,
                    Age = 33
                });
            
            modelBuilder.Entity<Interest>().HasData(
                new Interest("Plays the guitar")
                {
                    Id = 1,
                    ProfileCardID = 2
                 },
                new Interest("Picks up girls")
                {
                    Id = 2,
                    ProfileCardID = 2
                },
                new Interest("Smokes weed and gets high")
                {
                    Id = 3,
                    ProfileCardID = 1

                },
                new Interest("Watches movies")
                {
                    Id = 4,
                    ProfileCardID = 3
                },
                new Interest("Loves melted cheese")
                {
                    Id = 5,
                    ProfileCardID = 3
                },
                new Interest("Prefers not to pull out")
                {
                    Id = 6,
                    ProfileCardID = 3
                }
                
                );



            base.OnModelCreating(modelBuilder);
        }
    }

    
}
