using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Services.Forum;

namespace PortfolioApi.Controllers.Forum.Post
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IForumProfileService _forumProfileService;
        public PostController(IForumProfileService forumProfileService)
        {
            _forumProfileService = forumProfileService ?? throw new ArgumentNullException(nameof(forumProfileService));
        }

        // Post
        // Get

        [HttpGet("{forumProfileId}")]
        public async Task<IActionResult> GetAllPostsForProfile(int forumProfileId)
        {
            var postDtos = await _forumProfileService.GetAllPostsForForumProfileAsync(forumProfileId);

            return Ok(postDtos);
        }

        [HttpGet("{forumProfileId}/{postId}")]
        public async Task<IActionResult> GetPostForProfile(int forumProfileId, int postId)
        {
            var postDto = await _forumProfileService.GetPostForForumProfileAsync(forumProfileId, postId);

            return Ok(postDto);
        }

        // Comment 
        // Get
    }
}
