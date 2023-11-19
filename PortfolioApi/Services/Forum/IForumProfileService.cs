using PortfolioApi.Models.Forum.ForumProfile;

namespace PortfolioApi.Services.Forum
{
    public interface IForumProfileService
    {
        Task<ForumProfileDto> GetAllForumProfilesAsync();
        Task<ForumProfileDto> GetForumProfileAsync(int forumProfileId); 
    }
}
