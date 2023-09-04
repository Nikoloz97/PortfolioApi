using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.DataAccess.GeoGame;
using PortfolioApi.Models.GeoGame;

namespace PortfolioApi.Controllers.GeoGame
{
    [ApiController]
    [Route("api/geoGame")]
    public class GeoCardController : Controller
    {
        private readonly IGeoGameRepository _geoGameRepository;
        private readonly IMapper _mapper;
        public GeoCardController(IGeoGameRepository geoGameRepository, IMapper mapper)
        {
            _geoGameRepository = geoGameRepository ?? throw new ArgumentNullException(nameof(geoGameRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCards()
        {
            var geoGameEntities = await _geoGameRepository.GetAllGeoCardsAsync();

            return Ok(_mapper.Map<IEnumerable<GeoCardDto>>(geoGameEntities));
        }
    }
}
