using PortfolioApi.Models.GeoGame;

namespace PortfolioApi.Services.GeoGame
{
    public interface IGeoGameService
    {
        Task<IEnumerable<GeoCardDto>> GetAllGeoCardsAsync();
    }
}
