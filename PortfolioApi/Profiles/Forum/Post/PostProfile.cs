using AutoMapper;
using PortfolioApi.Entities.Forum;
using PortfolioApi.Models.Forum.Post;

namespace PortfolioApi.Profiles.Forum.Post
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<PortfolioApi.Entities.Forum.Post, PostDto>();
        }
    }
}
