using Microsoft.EntityFrameworkCore;
using PortfolioApi.DbContexts;
using PortfolioApi.Entities.GeoGame;

namespace PortfolioApi.DataAccess.GeoGame
{
    public class GeoGameRepository : IGeoGameRepository
    {
        private readonly UserContext _userContext;

        public GeoGameRepository(UserContext userContext)
        {
            _userContext = userContext ?? throw new ArgumentNullException(nameof(userContext));
        }

        public async Task<IEnumerable<GeoCard>> GetAllGeoCardsAsync()
        {
            return await _userContext.GeoCards
                                        .OrderBy(gc => gc.GeoCardId)
                                        .ToListAsync();
        }

    }
}
