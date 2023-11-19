using AutoMapper;
using PortfolioApi.DataAccess.Forum;
using PortfolioApi.Entities.Forum;
using PortfolioApi.Models.Forum.ForumProfile;

namespace PortfolioApi.Services.Forum
{
    public class ForumProfileService
    {
        private readonly IForumRepository _forumRepository;
        private readonly IMapper _mapper;

        public ForumProfileService(IForumRepository forumRepository, IMapper mapper)
        {
            _forumRepository = forumRepository ?? throw new ArgumentNullException(nameof(forumRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }
        public async Task<IEnumerable<ForumProfileDto>> GetAllForumProfilesAsync()
        {
            var forumProfileEntities = await _forumRepository.GetAllForumProfilesAsync();
            return _mapper.Map<IEnumerable<ForumProfileDto>>(forumProfileEntities);
        }

        public async Task<ForumProfileDto> GetForumProfileAsync(int forumProfileId)
        {
            var forumProfileEntity = await _forumRepository.GetForumProfileAsync(forumProfileId);

            return _mapper.Map<ForumProfileDto>(forumProfileEntity);
        }

    }
}
