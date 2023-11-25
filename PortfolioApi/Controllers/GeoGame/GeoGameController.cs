using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Services.GeoGame;

namespace PortfolioApi.Controllers.GeoGame
{
    [ApiController]
    [Route("api/geoGame")]
    public class GeoGameController : Controller
    {
        private readonly IGeoGameService _geoGameService;
        public GeoGameController(IGeoGameService geoGameService)
        {
            _geoGameService = geoGameService ?? throw new ArgumentNullException(nameof(geoGameService));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCards()
        {
            var geoGameDtos = await _geoGameService.GetAllGeoCardsAsync();

            return Ok();
        }
    }
}
