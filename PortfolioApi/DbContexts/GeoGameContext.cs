using Microsoft.EntityFrameworkCore;
using PortfolioApi.Entities.GeoGame;
using static System.Net.WebRequestMethods;

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
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/67/Georgia_%28orthographic_projection_with_inset%29.svg/250px-Georgia_%28orthographic_projection_with_inset%29.svg.png",
                    OptionOne = "Tbilisi",
                    OptionTwo = "Yerevan",
                    OptionThree = "Paris",
                    OptionFour = "Berlin",
                },
                new GeoCard("Argentina", "South America", "Which of the following options is on the southern-most tip of South America?", "Multiple Choice", "Argentina")
                {
                    GeoCardId = 2,
                    ImageUrl = "https://www.freeworldmaps.net/southamerica/southamerica-blackandwhite-hd.jpg",
                    OptionOne = "Peru",
                    OptionTwo = "Brazil",
                    OptionThree = "Uruguay",
                    OptionFour = "Argentina",
                },
                new GeoCard("Thailand", "Asia", "Which country is Bangkok located in?", "Free Response", "Thailand")
                {
                    GeoCardId = 3,
                    ImageUrl = "https://www.seabourn.com/content/dam/sbn65/inventory-assets/ports/o/bkk/port-laem-chabang-bangkok-1334x1001.jpg",
                    OptionOne = "Myanmar",
                    OptionTwo = "Thailand",
                    OptionThree = "Turkey",
                    OptionFour = "China",
                }
                );
            base.OnModelCreating(modelBuilder);

        }
    }
}
