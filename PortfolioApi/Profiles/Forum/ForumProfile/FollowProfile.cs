using AutoMapper;
using PortfolioApi.Models.Forum.ForumProfile;

namespace PortfolioApi.Profiles.Forum.ForumProfile
{
    public class FollowProfile : Profile
    {
        public FollowProfile()
        {
            CreateMap<PortfolioApi.Entities.Forum.Follow, FollowDto>();
        }
    }
}
