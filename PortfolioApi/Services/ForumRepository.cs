using Microsoft.EntityFrameworkCore;
using PortfolioApi.DbContexts;
using PortfolioApi.Entities;

namespace PortfolioApi.Services
{
    // Right now, all of our business logic = repository 
    public class ForumRepository : IForumRepository
    {
        private readonly ForumContext _forumContext;

        public ForumRepository(ForumContext forumContext)
        {
            _forumContext = forumContext ?? throw new ArgumentNullException(nameof(forumContext));
        }

        public async Task<IEnumerable<ProfileCard>> GetProfileCardsAsync()
        {
            return await _forumContext.ProfileCards.OrderBy(p => p.LastName).ToListAsync();
        }

        public async Task<ProfileCard?> GetProfileCardAsync(int profileCardId, bool isInterestsListIncluded)
        {
            if (isInterestsListIncluded)
            {
                return await _forumContext.ProfileCards.Include(p => p.Interests)
                    .Where(p => p.Id == profileCardId).FirstOrDefaultAsync();
            }
            return await _forumContext.ProfileCards.Where(p => p.Id == profileCardId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Interest>> GetInterestsForProfileCardAsync(int profileCardId)
        {
            return await _forumContext.Interests.Where(i => i.ProfileCardID == profileCardId).ToListAsync();

        }

        public async Task<Interest?> GetInterestForProfileCardAsync(int profileCardId, int interestId)
        {
            return await _forumContext.Interests.Where(i => i.ProfileCardID == profileCardId && i.Id == interestId).FirstOrDefaultAsync();
        }
    }
}
