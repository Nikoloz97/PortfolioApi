using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Models;
using PortfolioApi.Services;

namespace PortfolioApi.Controllers
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


        [HttpGet("{profileCardId}")]
        public async Task<ActionResult<IEnumerable<InterestDto>>> GetAllInterests(int profileCardId)
        {
            if (!await _forumRepository.ProfileCardExistsAsync(profileCardId))
            {
                return NotFound();
            }

            var interestEntities = await _forumRepository.GetInterestsForProfileCardAsync(profileCardId);

            return Ok(_mapper.Map<IEnumerable<InterestDto>>(interestEntities));
        }

        [HttpGet("{profileCardId}/{interestId}")]
        public async Task<ActionResult<InterestDto>> GetInterest(int profileCardId, int interestId)
        {
            if (!await _forumRepository.ProfileCardExistsAsync(profileCardId))
            {
                return NotFound();
            }
            var interestEntity = await _forumRepository.GetInterestForProfileCardAsync(profileCardId, interestId);

            if (interestEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<InterestDto>(interestEntity));
        }





    }

}
