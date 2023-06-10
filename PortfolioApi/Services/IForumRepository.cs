using PortfolioApi.Entities.Forum;

namespace PortfolioApi.Services
{
    public interface IForumRepository
    {
        Task<IEnumerable<ProfileCard>> GetAllProfileCardsAsync(bool areInterstsIncluded);

        Task<ProfileCard?> GetProfileCardAsync(int profileCardId, bool isInterestsListIncluded);

        Task<IEnumerable<Interest>> GetInterestsForProfileCardAsync(int profileCardId);

        Task<Interest?> GetInterestForProfileCardAsync(int profileCardId, int interestId);

        Task<bool> ProfileCardExistsAsync(int profileCardId);
    }
}
