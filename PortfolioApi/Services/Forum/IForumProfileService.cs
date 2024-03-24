using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Models.Forum.ForumProfile;
using PortfolioApi.Models.Forum.Post;

namespace PortfolioApi.Services.Forum
{
    public interface IForumProfileService
    {
        // Forum Profile
        Task<IEnumerable<ForumProfileDto>> GetAllForumProfilesAsync();
        Task<IEnumerable<ForumProfileDto>> GetForumProfilesWithPostsAsync();
        Task<IEnumerable<ForumProfileDto>> GetForumProfilesWithPostsExceptUserAsync(int userId);
        Task<ForumProfileDto> GetUserForumProfileAsync(int userId);
        Task<ForumProfileDto> GetForumProfileAsync(int forumProfileId);
        Task<bool> ForumProfileExistsAsync(int forumProfileId);
        Task<IActionResult> CreateForumProfileAsync(int userId, string username, string profileURL);

        // Interests
        Task<IEnumerable<InterestDto>> GetAllInterestsForForumProfileAsync(int forumProfileId);
        Task<InterestDto> GetInterestForForumProfileAsync(int forumProfileId, int interestId);

        // Posts
        Task<IEnumerable<PostDto>> GetAllPostsForForumProfileAsync(int forumProfileId);
        Task<PostDto?> GetPostForForumProfileAsync(int forumProfileId, int postId);
    }
}
