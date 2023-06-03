using AutoMapper;

namespace PortfolioApi.Profiles
{
    public class ProfileCardProfile : Profile
    {
        public ProfileCardProfile()
        {
             CreateMap<Entities.ProfileCard, Models.ProfileCardDtoWithoutInterestsDto>();
        }
    }
}
