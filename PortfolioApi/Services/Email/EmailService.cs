using PortfolioApi.Models.Contact;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;

namespace PortfolioApi.Services.Email
{
    public class EmailService  : IEmailService
    {
        private readonly IConfiguration _configuration;
        private string _mailTo = "nikolectures@gmail.com";

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(EmailDto email)
        {
            // Email sending logic here
            var apikey = _configuration.GetSection("MyApiSettings").GetValue<string>("ApiKey");

            Console.WriteLine(apikey);
        }
    }
}
