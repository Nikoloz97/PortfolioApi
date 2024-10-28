using AutoMapper;
using PortfolioApi.Models.Forum.ForumProfile;

namespace PortfolioApi.Profiles.Forum.ForumProfile
{
    public class ForumProfileProfile : Profile
    {
        public ForumProfileProfile()
        {
            CreateMap<PortfolioApi.Entities.Forum.ForumProfile, ForumProfileDto>();
        }
    }
}
