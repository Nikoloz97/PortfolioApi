using AutoMapper;
using PortfolioApi.Entities.Forum;
using PortfolioApi.Models.Forum.Post;

namespace PortfolioApi.Profiles.Forum.Post
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentDto>();
        }
    }
}
