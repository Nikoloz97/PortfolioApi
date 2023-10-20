using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.DataAccess.Forum;
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
        private readonly IMapper _mapper;
        private string _mailTo = "nikolectures@gmail.com";

        public ContactController(IEmailService emailService, IMapper mapper)
        {
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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
