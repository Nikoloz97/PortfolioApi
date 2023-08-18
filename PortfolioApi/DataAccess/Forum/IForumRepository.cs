using PortfolioApi.Entities.Forum;

namespace PortfolioApi.DataAccess.Forum
{
    public interface IForumRepository
    {
        Task<IEnumerable<ForumProfile>> GetAllForumProfilesAsync(bool areInterstsIncluded);

        Task<ForumProfile?> GetForumProfileAsync(int profileCardId, bool isInterestsListIncluded);

        Task<IEnumerable<Interest>> GetAllInterestsForForumProfileAsync(int profileCardId);

        Task<Interest?> GetInterestForForumProfileAsync(int profileCardId, int interestId);

        Task<bool> ForumProfileExistsAsync(int profileCardId);

        Task<IEnumerable<Post>> GetAllPostsForForumProfileAsync(int forumProfileId);

        Task<Post?> GetPostForForumProfileAsync(int forumProfileId, int postId);


    }
}
