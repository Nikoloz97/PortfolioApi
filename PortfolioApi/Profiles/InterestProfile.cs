using AutoMapper;
using PortfolioApi.Entities.Forum;

namespace PortfolioApi.Profiles
{
    public class InterestProfile : Profile
    {
        public InterestProfile()
        {
            CreateMap<Interest, Models.InterestDto>();
        }
    }
}
