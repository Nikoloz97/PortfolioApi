using AutoMapper;
using PortfolioApi.Models.GeoGame;

namespace PortfolioApi.Profiles.GeoGame
{
    public class GeoGameProfile : Profile
    {
        public GeoGameProfile()
        {
            CreateMap<PortfolioApi.Entities.GeoGame.GeoCard, GeoCardDto>();
        }
    }
}
