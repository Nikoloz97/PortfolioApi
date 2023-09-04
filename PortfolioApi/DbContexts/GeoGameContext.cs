using Microsoft.EntityFrameworkCore;
using PortfolioApi.Entities.GeoGame;

namespace PortfolioApi.DbContexts
{
    public class GeoGameContext : DbContext
    {
        public DbSet<GeoCard> GeoCards { get; set; }

        public GeoGameContext(DbContextOptions<GeoGameContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GeoCard>().HasData(
                new GeoCard("Georgia", "Eastern Europe", "What is the capital of Georgia?", "Multiple Choice", "Tbilisi")
                {
                    GeoCardId = 1,
                    OptionOne = "Tbilisi",
                    OptionTwo = "Yerevan",
                    OptionThree = "Paris",
                    OptionFour = "Berlin",
                },
                new GeoCard("Argentina", "South America", "Which of the following options is on the southern-most tip of South America?", "Multiple Choice", "Argentina")
                {
                    GeoCardId = 2,
                    OptionOne = "Peru",
                    OptionTwo = "Brazil",
                    OptionThree = "Uruguay",
                    OptionFour = "Argentina",
                },
                new GeoCard("Thailand", "Asia", "Which country is Bangkok located in?", "Free Response", "Thailand")
                {
                    GeoCardId = 3,
                    OptionOne = "Myanmar",
                    OptionTwo = "Thailand",
                    OptionThree = "Turkey",
                    OptionFour = "China",
                }
                );
        }
    }
}
