using Microsoft.AspNetCore.Mvc;
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

    }
}
