using PortfolioApi.Models.Forum.ForumProfile;
using PortfolioApi.Models.Forum.Post;

namespace PortfolioApi.Services.Forum
{
    public interface IForumProfileService
    {
        Task<IEnumerable<ForumProfileDto>> GetAllForumProfilesAsync();
        Task<ForumProfileDto> GetForumProfileAsync(int forumProfileId);
        Task<IEnumerable<InterestDto>> GetAllInterestsForForumProfileAsync(int forumProfileId);
        Task<IEnumerable<PostDto>> GetAllPostsForForumProfileAsync(int forumProfileId);
        Task<PostDto?> GetPostForForumProfileAsync(int forumProfileId, int postId);
    }
}
