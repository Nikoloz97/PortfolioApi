using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Models.Forum.ForumProfile;
using PortfolioApi.Services.Forum;

namespace PortfolioApi.Controllers.Forum.ForumProfile
{
    [Route("api/forum/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        private readonly IForumRepository _forumRepository;
        private readonly IMapper _mapper;

        public InterestController(IForumRepository forumRepository, IMapper mapper)
        {
            _forumRepository = forumRepository ?? throw new ArgumentException(nameof(forumRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet("{forumProfileId}")]
        public async Task<ActionResult<IEnumerable<InterestDto>>> GetAllInterests(int forumProfileId)
        {
            if (!await _forumRepository.ForumProfileExistsAsync(forumProfileId))
            {
                return NotFound();
            }

            var interestEntities = await _forumRepository.GetAllInterestsForForumProfileAsync(forumProfileId);

            return Ok(_mapper.Map<IEnumerable<InterestDto>>(interestEntities));
        }

        [HttpGet("{forumProfileId}/{interestId}")]
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
