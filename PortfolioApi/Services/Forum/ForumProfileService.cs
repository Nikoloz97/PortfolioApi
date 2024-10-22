using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.DataAccess.Forum;
using PortfolioApi.Entities.Forum;
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

        public async Task<IEnumerable<ForumProfileDto>> GetForumProfilesWithPostsAsync()
        {
            var forumProfileEntities = await _forumRepository.GetForumProfilesWithPostsAsync();
            return _mapper.Map<IEnumerable<ForumProfileDto>>(forumProfileEntities);
        }

        public async Task<IEnumerable<ForumProfileDto>> GetForumProfilesWithPostsExceptUserAsync(int userId)
        {
            var forumProfileEntities = await _forumRepository.GetForumProfilesWithPostsExceptUserAsync(userId);
            return _mapper.Map<IEnumerable<ForumProfileDto>>(forumProfileEntities);
        }

        public async Task<ForumProfileDto> GetUserForumProfileAsync(int userId)
        {
            var forumProfileEntity = await _forumRepository.GetUserForumProfileAsync(userId);

            return _mapper.Map<ForumProfileDto>(forumProfileEntity);
        }

        public async Task<ForumProfileDto> GetForumProfileAsync(int forumProfileId)
        {
            var forumProfileEntity = await _forumRepository.GetForumProfileAsync(forumProfileId);

            return _mapper.Map<ForumProfileDto>(forumProfileEntity);
        }

        public async Task<bool> ForumProfileExistsAsync(int forumProfileId)
        {
            return await _forumRepository.ForumProfileExistsAsync(forumProfileId);
        }

        public async Task<IActionResult> CreateForumProfileAsync(int userId, string username, string? profileURL)
        {
            var newFPToCreateEntity = new ForumProfile(userId, username)
            {
                ProfileURL = profileURL
            };

            var newlyCreatedFPEntity = await _forumRepository.CreateForumProfileAsync(newFPToCreateEntity, userId);

            var newFPDto = _mapper.Map<ForumProfileDto>(newlyCreatedFPEntity);

            return new OkObjectResult(newFPDto);
        }

        // Interest

        public async Task<IEnumerable<InterestDto>> GetAllInterestsForForumProfileAsync(int forumProfileId)
        {
            var interestEntities = await _forumRepository.GetAllInterestsForForumProfileAsync(forumProfileId);

            return _mapper.Map<IEnumerable<InterestDto>>(interestEntities);
        }

        public async Task<InterestDto> GetInterestForForumProfileAsync(int forumProfileId, int interestId)
        {
            var interestEntity = await _forumRepository.GetInterestForForumProfileAsync(forumProfileId, interestId);

            return _mapper.Map<InterestDto>(interestEntity);
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
