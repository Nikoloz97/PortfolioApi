using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Models;
using PortfolioApi.Services;

namespace PortfolioApi.Controllers
{
    [ApiController]
    [Route("api/forum")]
    public class ProfileCardController : Controller
    {
        private readonly IForumRepository _forumRepository;
        private readonly IMapper _mapper;

        public ProfileCardController(IForumRepository forumRepository, IMapper mapper)
        {
            _forumRepository = forumRepository ?? throw new ArgumentNullException(nameof(forumRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProfileCards(bool areInterestsIncluded = true)
        {
            var profileCardEntities = await _forumRepository.GetAllProfileCardsAsync(areInterestsIncluded);

            if (areInterestsIncluded)
            {
                return Ok(_mapper.Map<IEnumerable<ProfileCardDto>>(profileCardEntities));
            }
            return Ok(_mapper.Map<IEnumerable<ProfileCardDtoWithoutInterestsDto>>(profileCardEntities));
        }

        [HttpGet("{profileCardId}")]
        public async Task<IActionResult> GetProfileCard(int profileCardId, bool areInterestsIncluded = true)
        { 
            var profileCardEntity = await _forumRepository.GetProfileCardAsync(profileCardId, areInterestsIncluded);

            if (profileCardEntity == null)
            {
                return NotFound();
            }

            if (areInterestsIncluded)
            {
                return Ok(_mapper.Map<ProfileCardDto>(profileCardEntity));
            }

            return Ok(_mapper.Map<ProfileCardDtoWithoutInterestsDto>(profileCardEntity));
        }

    }
}
