using Microsoft.EntityFrameworkCore;
using PortfolioApi.DbContexts;
using PortfolioApi.Entities.Forum;

namespace PortfolioApi.Services.Forum
{
    // All of business logic = repository 
    public class ForumRepository : IForumRepository
    {
        private readonly ForumContext _forumContext;

        public ForumRepository(ForumContext forumContext)
        {
            _forumContext = forumContext ?? throw new ArgumentNullException(nameof(forumContext));
        }


        // Forum profile

        public async Task<IEnumerable<ForumProfile>> GetAllForumProfilesAsync(bool areInterestsIncluded)
        {
            if (areInterestsIncluded)
            {
                return await _forumContext.ProfileCards
                                        .Include(p => p.Interests)
                                        .OrderBy(p => p.LastName)
                                        .ToListAsync();
            }
            return await _forumContext.ProfileCards
                                        .OrderBy(p => p.LastName)
                                        .ToListAsync();
        }

        public async Task<ForumProfile?> GetForumProfileAsync(int forumProfileId, bool isInterestsListIncluded)
        {
            if (isInterestsListIncluded)
            {
                return await _forumContext.ProfileCards
                                            .Include(p => p.Interests)
                                            .Where(p => p.ProfileCardID == forumProfileId)
                                            .FirstOrDefaultAsync();
            }
            return await _forumContext.ProfileCards
                                            .Where(p => p.ProfileCardID == forumProfileId)
                                            .FirstOrDefaultAsync();
        }

        public async Task<bool> ForumProfileExistsAsync(int forumProfileId)
        {
            return await _forumContext.ProfileCards.AnyAsync(pc => pc.ProfileCardID == forumProfileId);
        }


        // Interest

        public async Task<IEnumerable<Interest>> GetAllInterestsForForumProfileAsync(int forumProfileId)
        {
            return await _forumContext.Interests.Where(i => i.ProfileCardID == forumProfileId).ToListAsync();

        }

        public async Task<Interest?> GetInterestForForumProfileAsync(int forumProfileId, int interestId)
        {
            return await _forumContext.Interests.Where(i => i.ProfileCardID == forumProfileId && i.InterestId == interestId).FirstOrDefaultAsync();
        }

        // Post

        public async Task<IEnumerable<Post>> GetAllPostsForForumProfileAsync(int forumProfileId)
        {
            return await _forumContext.Posts.Where(p => p.ProfileCardID == forumProfileId).ToListAsync();
        }

        public async Task<Post?> GetPostForForumProfileAsync(int forumProfileId, int postId)
        {
            return await _forumContext.Posts.Where(p => p.ProfileCardID == forumProfileId && p.PostId == postId).FirstOrDefaultAsync();
        }


    }
}
