using AutoMapper;
using PortfolioApi.DataAccess.Forum;
using PortfolioApi.Models.Forum.ForumProfile;
using PortfolioApi.Models.Forum.Post;

namespace PortfolioApi.Services.Forum
{
    public class ForumProfileService : IForumProfileService
    {
        private readonly IForumRepository _forumRepository;
        private readonly IMapper _mapper;

        public ForumProfileService(IForumRepository forumRepository, IMapper mapper)
        {
            _forumRepository = forumRepository ?? throw new ArgumentNullException(nameof(forumRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }

        // Forum Profile

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

        // Interest

        public async Task<IEnumerable<InterestDto>> GetAllInterestsForForumProfileAsync(int forumProfileId)
        {
            var interestEntities = await _forumRepository.GetForumProfileAsync(forumProfileId);

            return _mapper.Map<IEnumerable<InterestDto>>(interestEntities);
        }

        // Post

        public async Task<IEnumerable<PostDto>> GetAllPostsForForumProfileAsync(int forumProfileId)
        {
            var postEntities = await _forumRepository.GetAllInterestsForForumProfileAsync(forumProfileId);

            return _mapper.Map<IEnumerable<PostDto>>(postEntities);
        }

        public async Task<PostDto?> GetPostForForumProfileAsync(int forumProfileId, int postId)
        {
            var postEntity = await _forumRepository.GetInterestForForumProfileAsync(forumProfileId, postId);

            return _mapper.Map<PostDto?>(postEntity);
        }

    }
}
