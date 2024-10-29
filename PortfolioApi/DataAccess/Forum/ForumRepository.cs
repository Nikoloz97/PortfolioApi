using Microsoft.EntityFrameworkCore;
using PortfolioApi.DbContexts;
using PortfolioApi.Entities.Forum;

namespace PortfolioApi.DataAccess.Forum
{
    // All of business logic = repository 
    public class ForumRepository : IForumRepository
    {
        private readonly UserContext _userContext;

        public ForumRepository(UserContext userContext)
        {
            _userContext = userContext ?? throw new ArgumentNullException(nameof(userContext));
        }

        // Forum profile

        public async Task<IEnumerable<ForumProfile>> GetAllForumProfilesAsync()
        {
                return await _userContext.ForumProfiles
                                        .Include(p => p.Interests)
                                        .Include(p => p.Posts)
                                        .ThenInclude(post => post.Comments)
                                        //.Include(p => p.Followings)
                                        //.Include(p => p.Followers)
                                        .OrderBy(p => p.ForumProfileId)
                                        .ToListAsync();
        }

        public async Task<IEnumerable<ForumProfile>> GetForumProfilesWithPostsAsync()
        {
            return await _userContext.ForumProfiles
                                    .Include(p => p.User)
                                    .Where(p => p.Posts.Count > 0)
                                    .Include(p => p.Interests)
                                    .Include(p => p.Posts)
                                    .ThenInclude(post => post.Comments)
                                    //.Include(p => p.Followings)
                                    //.Include(p => p.Followers)
                                    .OrderBy(p => p.ForumProfileId)
                                    .ToListAsync();
        }

        public async Task<IEnumerable<ForumProfile>> GetForumProfilesWithPostsExceptUserAsync(int userId)
        {
            return await _userContext.ForumProfiles
                                    .Where(p => p.Posts.Count > 0 && p.UserId != userId)
                                    .Include(p => p.Interests)
                                    .Include(p => p.Posts)
                                    .ThenInclude(post => post.Comments)
                                    //.Include(p => p.Followings)
                                    //.Include(p => p.Followers)
                                    .OrderBy(p => p.ForumProfileId)
                                    .ToListAsync();
        }

        public async Task<ForumProfile?> GetUserForumProfileAsync(int userId)
        {
            return await _userContext.ForumProfiles
                                        .Include(p => p.Interests)
                                        //.Include(p => p.Followings)
                                        //.Include(p => p.Followers)
                                        .Include(p => p.Posts)
                                        .Where(p => p.UserId == userId)
                                        .FirstOrDefaultAsync();
        }

        public async Task<ForumProfile?> GetForumProfileAsync(int forumProfileId)
        {
                return await _userContext.ForumProfiles
                                            .Include(p => p.Interests)
                                            //.Include(p => p.Followings)
                                            //.Include(p => p.Followers)
                                            .Include(p => p.Posts)
                                            .Where(p => p.ForumProfileId == forumProfileId)
                                            .FirstOrDefaultAsync();
        }

        public async Task<bool> ForumProfileExistsAsync(int forumProfileId)
        {
            return await _userContext.ForumProfiles.AnyAsync(pc => pc.ForumProfileId == forumProfileId);
        }

        public async Task<Entities.Forum.ForumProfile?> CreateForumProfileAsync(Entities.Forum.ForumProfile newForumProfileEntity, int userId)
        {
            _userContext.ForumProfiles.Add(newForumProfileEntity);
            await _userContext.SaveChangesAsync();
            return await _userContext.ForumProfiles.Where(fp => fp.UserId == userId).FirstOrDefaultAsync();   
        }


        // Interest

        public async Task<IEnumerable<Interest>> GetAllInterestsForForumProfileAsync(int forumProfileId)
        {
            return await _userContext.Interests.Where(i => i.ForumProfileId == forumProfileId).ToListAsync();

        }

        public async Task<Interest?> GetInterestForForumProfileAsync(int forumProfileId, int interestId)
        {
            return await _userContext.Interests.Where(i => i.ForumProfileId == forumProfileId && i.InterestId == interestId).FirstOrDefaultAsync();
        }

        // Post

        public async Task<IEnumerable<Post>> GetAllPostsForForumProfileAsync(int forumProfileId)
        {
            return await _userContext.Posts.Where(p => p.ForumProfileId == forumProfileId).ToListAsync();
        }

        public async Task<Post?> GetPostForForumProfileAsync(int forumProfileId, int postId)
        {
            return await _userContext.Posts.Where(p => p.ForumProfileId == forumProfileId && p.PostId == postId).FirstOrDefaultAsync();
        }


    }
}
