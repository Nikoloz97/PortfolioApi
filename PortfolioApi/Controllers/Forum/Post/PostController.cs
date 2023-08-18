using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.DataAccess.Forum;
using PortfolioApi.Models.Forum.Post;
using PortfolioApi.Models.User;
using PortfolioApi.Services;

namespace PortfolioApi.Controllers.Forum.Post
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IForumRepository _forumRepository;
        private readonly IMapper _mapper;
        public PostController(IForumRepository forumRepository, IMapper mapper)
        {
            _forumRepository = forumRepository ?? throw new ArgumentNullException(nameof(forumRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("{forumProfileId}")]
        public async Task<IActionResult> GetAllPostsForProfile(int forumProfileId)
        {
            var commentEntities = await _forumRepository.GetAllPostsForForumProfileAsync(forumProfileId);

            return Ok(_mapper.Map<IEnumerable<PostDto>>(commentEntities));
        }

        [HttpGet("{forumProfileId}/{postId}")]
        public async Task<IActionResult> GetPostForProfile(int forumProfileId, int postId)
        {
            var commentEntities = await _forumRepository.GetPostForForumProfileAsync(forumProfileId, postId);

            return Ok(_mapper.Map<IEnumerable<UserDto_Return>>(commentEntities));
        }
    }
}
