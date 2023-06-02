using PortfolioApi.Entities;

namespace PortfolioApi.Services
{
    public interface IForumRepository
    {
        public Task<IEnumerable<ProfileCard>> GetProfileCardsAsync();

        public Task<ProfileCard?> GetProfileCardAsync(int profileCardId, bool isInterestsListIncluded);

        public Task<IEnumerable<Interest>> GetInterestsForProfileCardAsync(int profileCardId);

        public Task<Interest?> GetInterestForProfileCardAsync(int profileCardId, int interestId);
    }
}
