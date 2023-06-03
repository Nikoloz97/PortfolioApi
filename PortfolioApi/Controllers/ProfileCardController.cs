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

        public ProfileCardController(IForumRepository forumRepository)
        {
            _forumRepository = forumRepository ?? throw new ArgumentNullException(nameof(forumRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfileCardDtoWithoutInterestsDto>>> GetAllProfileCards()
        {
            // TODO: Create bool expression for interests (like getting singular PC)

            var profileCardEntities = await _forumRepository.GetAllProfileCardsAsync();
            var results = new List<ProfileCardDtoWithoutInterestsDto>();
            foreach (var card in profileCardEntities)
            {
                results.Add(new ProfileCardDtoWithoutInterestsDto
                {
                    Id = card.Id,
                    Age = card.Age,
                    FirstName = card.FirstName,
                    LastName = card.LastName,
                });
            }
            return Ok(results);
        }

        [HttpGet("{profileCardId}")]
        public async Task<ActionResult<IEnumerable<ProfileCardDtoWithoutInterestsDto>>> GetProfileCard(int profileCardId, bool areInterestsIncluded)
        {
 
            var profileCardEntity = await _forumRepository.GetProfileCardAsync(profileCardId, areInterestsIncluded);
            if (areInterestsIncluded)
            {
                var result = new ProfileCardDto() {
                    Id = profileCardEntity.Id,
                    Age = profileCardEntity.Age,
                    FirstName = profileCardEntity.FirstName,
                    LastName = profileCardEntity.LastName, 
                    Interests = profileCardEntity.Interests,
                };
                return Ok(result);
            }
            var result = new ProfileCardDtoWithoutInterestsDto()
            {
                Id = profileCardEntity.Id,
                Age = profileCardEntity.Age,
                FirstName = profileCardEntity.FirstName,
                LastName = profileCardEntity.LastName,
            };
            return Ok(result);


        }
    }
}
