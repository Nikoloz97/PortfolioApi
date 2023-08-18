namespace PortfolioApi.Models.User
{
    public class UserDto_Creation
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public IFormFile? ProfileImageFile { get; set; }
        public string? Bio { get; set; }
    }
}
