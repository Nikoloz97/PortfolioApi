using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Models.Contact;
using PortfolioApi.Models.User;
using PortfolioApi.Services.Email;

namespace PortfolioApi.Controllers.Contact
{
    [Route("api/contact")]
    [ApiController]
    public class ContactController : Controller
    {
        private readonly IEmailService _emailService;

        public ContactController(IEmailService emailService)
        {
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
        }


        // TODO: Return confirmation that it went through
        [HttpPost]
        public async Task<ActionResult<UserDto_Return>> SendEmail([FromForm] EmailDto email)
        {
            // TODO: Keep this function named as async?? 
            await _emailService.SendEmailAsync(email);
            return Ok(email);
        }




    }
}
