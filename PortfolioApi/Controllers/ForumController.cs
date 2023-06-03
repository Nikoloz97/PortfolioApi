using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Models;
using PortfolioApi.Services;

namespace PortfolioApi.Controllers
{
    [ApiController]
    [Route("api/forum")]
    public class ForumController : Controller
    {
        private readonly IForumRepository _forumRepository;

        public ForumController(IForumRepository forumRepository)
        {
            _forumRepository = forumRepository ?? throw new ArgumentNullException(nameof(forumRepository));
        }

        [HttpGet]
        public async ActionResult<IEnumerable<ProfileCardDto>> GetProfileCards()
        {
            var profileCardEntities = await _forumRepository.GetProfileCardsAsync();

        }
    }
}
