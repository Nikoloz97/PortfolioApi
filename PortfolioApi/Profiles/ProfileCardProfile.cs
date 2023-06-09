using AutoMapper;
using PortfolioApi.Entities.Forum;

namespace PortfolioApi.Profiles
{
    public class ProfileCardProfile : Profile
    {
        public ProfileCardProfile()
        {
             CreateMap<ProfileCard, Models.ProfileCardDtoWithoutInterestsDto>();
             CreateMap<ProfileCard, Models.ProfileCardDto>();
        }
    }
}
