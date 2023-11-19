using AutoMapper;
using PortfolioApi.DataAccess.Forum;
using PortfolioApi.DataAccess.GeoGame;
using PortfolioApi.Models.GeoGame;

namespace PortfolioApi.Services.GeoGame
{
    public class GeoGameService : IGeoGameService
    {
        private readonly IGeoGameRepository _geoGameRepository;
        private readonly IMapper _mapper;
        public GeoGameService(GeoGameRepository geoGameRepository, IMapper mapper)
        {
            _geoGameRepository = geoGameRepository ?? throw new ArgumentException(nameof(geoGameRepository));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        public async Task<IEnumerable<GeoCardDto>> GetAllGeoCardsAsync()
        {
            var geoCardDtos = await _geoGameRepository.GetAllGeoCardsAsync();

            return _mapper.Map<IEnumerable<GeoCardDto>>(geoCardDtos);
        }


    }
}
