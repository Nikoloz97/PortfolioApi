using Microsoft.EntityFrameworkCore;
using PortfolioApi.DbContexts;
using PortfolioApi.Entities.GeoGame;

namespace PortfolioApi.DataAccess.GeoGame
{
    public class GeoGameRepository : IGeoGameRepository
    {
        private readonly GeoGameContext _geoGameContext;

        public GeoGameRepository(GeoGameContext geoGameContext)
        {
            _geoGameContext = geoGameContext ?? throw new ArgumentNullException(nameof(geoGameContext));
        }

        public async Task<IEnumerable<GeoCard>> GetAllGeoCardsAsync()
        {
            return await _geoGameContext.GeoCards
                                        .OrderBy(gc => gc.GeoCardId)
                                        .ToListAsync();
        }

    }
}
