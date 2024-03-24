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
            var forumProfileDtos = await _forumProfileService.GetAllForumProfilesAsync();

            return Ok(forumProfileDtos);
        }

        [HttpGet("ForumProfilesWithPosts")]
        public async Task<IActionResult> GetForumProfilesWithPosts()
        {
            var forumProfileDtos = await _forumProfileService.GetForumProfilesWithPostsAsync();

            return Ok(forumProfileDtos);
        }

        [HttpGet("ForumProfilesWithPosts/{userId}")]
        public async Task<IActionResult> GetForumProfilesWithPostsExceptUser(int userId)
        {
            var forumProfileDtos = await _forumProfileService.GetForumProfilesWithPostsExceptUserAsync(userId);

            return Ok(forumProfileDtos);
        }

        [HttpGet("UserProfile/{userId}")]
        public async Task<IActionResult> GetUserForumProfile(int userId)
        {
            var userForumProfileDto = await _forumProfileService.GetUserForumProfileAsync(userId);

            return Ok(userForumProfileDto);
        }

        [HttpGet("ForumProfile/{forumProfileId}")]
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
