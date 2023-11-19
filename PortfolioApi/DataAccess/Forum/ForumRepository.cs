using Microsoft.EntityFrameworkCore;
using PortfolioApi.DbContexts;
using PortfolioApi.Entities.Forum;

namespace PortfolioApi.DataAccess.Forum
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

        public async Task<IEnumerable<ForumProfile>> GetAllForumProfilesAsync()
        {
                return await _forumContext.ForumProfiles
                                        .Include(p => p.Interests)
                                        .Include(p => p.Posts)
                                        .ThenInclude(post => post.Comments)
                                        .Include(p => p.Followers)
                                        .Include(p => p.Followings)
                                        .OrderBy(p => p.ForumProfileId)
                                        .ToListAsync();
        }

        public async Task<ForumProfile?> GetForumProfileAsync(int forumProfileId)
        {

                return await _forumContext.ForumProfiles
                                            .Include(p => p.Interests)
                                            .Include(p => p.Followers)
                                            .Include(p => p.Followings)
                                            .Include(p => p.Posts)
                                            .Where(p => p.ForumProfileId == forumProfileId)
                                            .FirstOrDefaultAsync();
        }

        public async Task<bool> ForumProfileExistsAsync(int forumProfileId)
        {
            return await _forumContext.ForumProfiles.AnyAsync(pc => pc.ForumProfileId == forumProfileId);
        }


        // Interest

        public async Task<IEnumerable<Interest>> GetAllInterestsForForumProfileAsync(int forumProfileId)
        {
            return await _forumContext.Interests.Where(i => i.ForumProfileId == forumProfileId).ToListAsync();

        }

        public async Task<Interest?> GetInterestForForumProfileAsync(int forumProfileId, int interestId)
        {
            return await _forumContext.Interests.Where(i => i.ForumProfileId == forumProfileId && i.InterestId == interestId).FirstOrDefaultAsync();
        }

        // Post

        public async Task<IEnumerable<Post>> GetAllPostsForForumProfileAsync(int forumProfileId)
        {
            return await _forumContext.Posts.Where(p => p.ForumProfileId == forumProfileId).ToListAsync();
        }

        public async Task<Post?> GetPostForForumProfileAsync(int forumProfileId, int postId)
        {
            return await _forumContext.Posts.Where(p => p.ForumProfileId == forumProfileId && p.PostId == postId).FirstOrDefaultAsync();
        }


    }
}
