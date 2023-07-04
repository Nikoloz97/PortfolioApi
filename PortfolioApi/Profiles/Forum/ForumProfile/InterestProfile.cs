using AutoMapper;
using PortfolioApi.Entities.Forum;
using PortfolioApi.Models.Forum.ForumProfile;

namespace PortfolioApi.Profiles.Forum.ForumProfile
{
    public class InterestProfile : Profile
    {
        public InterestProfile()
        {
            CreateMap<Interest, InterestDto>();
        }
    }
}
