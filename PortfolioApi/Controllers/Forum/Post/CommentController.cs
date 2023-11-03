using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Models.User;

namespace PortfolioApi.Controllers.Forum.Post
{
    [Route("api/forum/post/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Test()
        {
            return Ok("Tacos");
        }
    }
}
