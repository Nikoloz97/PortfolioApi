using PortfolioApi.Models.Contact;

namespace PortfolioApi.Services.Email
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailDto email);

    }
}
