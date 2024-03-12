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

        [HttpGet("{userProfile/user/}")]
        public async Task<IActionResult> GetUserProfile()
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
        public async Task<ActionResult<IEnumerable<InterestDto>>> GetAllInterestsForForumProfile(int forumProfileId)
        {
            if (!await _forumProfileService.ForumProfileExistsAsync(forumProfileId))
            {
                return NotFound();
            }

            var interestDtos = await _forumProfileService.GetAllInterestsForForumProfileAsync(forumProfileId);

            return Ok(interestDtos);
        }

        [HttpGet("Interest/{forumProfileId}/{interestId}")]
        public async Task<ActionResult<InterestDto>> GetInterestForForumProfile(int forumProfileId, int interestId)
        {
            if (!await _forumProfileService.ForumProfileExistsAsync(forumProfileId))
            {
                return NotFound();
            }
            var interestDto = await _forumProfileService.GetInterestForForumProfileAsync(forumProfileId, interestId);

            if (interestDto == null)
            {
                return NotFound();
            }

            return Ok(interestDto);
        }


    }
}
