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

        public InterestController(IForumRepository forumRepository)
        {
            _forumRepository = forumRepository ?? throw new ArgumentException(nameof(forumRepository));
        }


        [HttpGet("{profileCardId}")]
        public async Task<ActionResult<IEnumerable<InterestDto>>> GetInterests(int profileCardId)
        {
            var InterestEntities = await _forumRepository.GetInterestsForProfileCardAsync(profileCardId);
            var results = new List<InterestDto>();
            foreach (var interestEntity in InterestEntities) {
                results.Add(new InterestDto
                {
                    Id = interestEntity.Id,
                    Description = interestEntity.Description,
                });
            }
            return Ok(results);
        }

        [HttpGet("{profileCardId}/{interestId}")]
        public async Task<ActionResult<IEnumerable<InterestDto>>> GetInterests(int profileCardId, int interestId)
        {
            var InterestEntity = await _forumRepository.GetInterestForProfileCardAsync(profileCardId, interestId);
            var result = new InterestDto()
            {
                Id = InterestEntity.Id,
                Description = InterestEntity.Description
            };

            return Ok(result);
        }





    }

}
