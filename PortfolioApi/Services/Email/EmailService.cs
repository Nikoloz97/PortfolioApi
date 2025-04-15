using PortfolioApi.Models.Contact;
using System.Net;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace PortfolioApi.Services.Email
{
    public class EmailService  : IEmailService
    {
        private readonly IConfiguration _configuration;
        // TODO: Make _mailFrom a contact email service (e.g. NicksPortfolioEmailService@gmail.com) 
        private string _mailFrom = "nikolectures@gmail.com";


        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(EmailDto email)
        {
            var apiKey = _configuration["SendGridApiKey"];

            var client = new SendGridClient(apiKey);

            var msg = new SendGridMessage()
            {
                From = new EmailAddress(_mailFrom, email.FirstName + " " + email.LastName),
                Subject = email.Subject,

                // TODO: pick one of these properties for body? 
                // TODO: Format contact email within the Content
                PlainTextContent = email.Body + " " + email.EmailAddress,
                HtmlContent = email.Body + " " + email.EmailAddress
            };

            msg.AddTo(new EmailAddress("nick.gotsy@gmail.com"));

            var response = await client.SendEmailAsync(msg);

            // TODO: fix error message (see Exceptions folder) 
            if (response.StatusCode != HttpStatusCode.Accepted)
            {
                Console.WriteLine("The email did not go through...");
                Console.WriteLine(response.StatusCode);
            }
        }
    }
}
