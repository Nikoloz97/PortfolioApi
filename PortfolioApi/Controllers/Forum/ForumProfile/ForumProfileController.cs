using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Models.Forum.ForumProfile;
using PortfolioApi.Services;
using PortfolioApi.Services.Forum;

namespace PortfolioApi.Controllers.Forum.ForumProfile
{
    [ApiController]
    [Route("api/forum")]
    public class ForumProfileController : Controller
    {
        private readonly IForumRepository _forumRepository;
        private readonly IMapper _mapper;

        public ForumProfileController(IForumRepository forumRepository, IMapper mapper)
        {
            _forumRepository = forumRepository ?? throw new ArgumentNullException(nameof(forumRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllForumProfiles(bool areInterestsIncluded = true)
        {
            var forumProfileEntities = await _forumRepository.GetAllForumProfilesAsync(areInterestsIncluded);

            if (areInterestsIncluded)
            {
                return Ok(_mapper.Map<IEnumerable<ForumProfileDto>>(forumProfileEntities));
            }
            return Ok(_mapper.Map<IEnumerable<ForumProfileWithoutInterestsDto>>(forumProfileEntities));
        }

        [HttpGet("{forumProfileId}")]
        public async Task<IActionResult> GetForumProfile(int forumProfileId, bool areInterestsIncluded = true)
        {
            var profileCardEntity = await _forumRepository.GetForumProfileAsync(forumProfileId, areInterestsIncluded);

            if (profileCardEntity == null)
            {
                return NotFound();
            }

            if (areInterestsIncluded)
            {
                return Ok(_mapper.Map<ForumProfileDto>(profileCardEntity));
            }

            return Ok(_mapper.Map<ForumProfileWithoutInterestsDto>(profileCardEntity));
        }

    }
}
