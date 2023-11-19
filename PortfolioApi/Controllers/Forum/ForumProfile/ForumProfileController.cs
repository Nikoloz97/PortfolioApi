using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Models.Forum.ForumProfile;
using PortfolioApi.Services.Forum;

namespace PortfolioApi.Controllers.Forum.ForumProfile
{
    [Route("api/forum")]
    [ApiController]
    public class ForumProfileController : Controller
    {
        private readonly IForumProfileService _forumProfileService;

        public ForumProfileController(IForumProfileService forumProfileService)
        {
            _forumProfileService = forumProfileService ?? throw new ArgumentNullException(nameof(forumProfileService));
        }

        // ForumProfile
        // Get 

        [HttpGet]
        public async Task<IActionResult> GetAllForumProfiles()
        {
            var forumProfileDtoList = await _forumProfileService.GetAllForumProfilesAsync();

            return Ok(forumProfileDtoList);
        }

        [HttpGet("{forumProfileId}")]
        public async Task<IActionResult> GetForumProfile(int forumProfileId)
        {
            var forumProfileDto = await _forumProfileService.GetForumProfileAsync(forumProfileId);
            
            return Ok(forumProfileDto);

        }

        // Interest 
        // Get 
        [HttpGet("Interest/{forumProfileId}")]
        public async Task<ActionResult<IEnumerable<InterestDto>>> GetAllInterests(int forumProfileId)
        {
            if (!await _forumProfileService.ForumProfileExistsAsync(forumProfileId))
            {
                return NotFound();
            }

            var interestEntities = await _forumProfileService.GetAllInterestsForForumProfileAsync(forumProfileId);

            return Ok(_mapper.Map<IEnumerable<InterestDto>>(interestEntities));
        }

        [HttpGet("Interest/{forumProfileId}/{interestId}")]
        public async Task<ActionResult<InterestDto>> GetInterest(int forumProfileId, int interestId)
        {
            if (!await _forumRepository.ForumProfileExistsAsync(forumProfileId))
            {
                return NotFound();
            }
            var interestEntity = await _forumRepository.GetInterestForForumProfileAsync(forumProfileId, interestId);

            if (interestEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<InterestDto>(interestEntity));
        }


    }
}
