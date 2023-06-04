using AutoMapper;

namespace PortfolioApi.Profiles
{
    public class InterestProfile : Profile
    {
        public InterestProfile()
        {
            CreateMap<Entities.Interest, Models.InterestDto>();
        }
    }
}
