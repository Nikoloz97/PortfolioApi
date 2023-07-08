using AutoMapper;
using PortfolioApi.Models.Forum.ForumProfile;

namespace PortfolioApi.Profiles.Forum.ForumProfile
{
    public class FollowingProfile : Profile
    {
        public FollowingProfile()
        {
            CreateMap<PortfolioApi.Entities.Forum.Following, FollowingDto>();
        }
    }
}
