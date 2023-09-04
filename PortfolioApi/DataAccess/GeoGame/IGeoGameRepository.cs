using PortfolioApi.Entities.GeoGame;

namespace PortfolioApi.DataAccess.GeoGame
{
    public interface IGeoGameRepository
    {
        Task<IEnumerable<GeoCard>> GetAllGeoCardsAsync();
    }
}
