using AutoMapper;
using PortfolioApi.Models.Forum.ForumProfile;

namespace PortfolioApi.Profiles.Forum.ForumProfile
{
    public class FollowerProfile : Profile
    {
        public FollowerProfile()
        {
            CreateMap<PortfolioApi.Entities.Forum.Follower, FollowerDto>();
        }
    }
}
