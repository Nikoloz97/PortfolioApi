namespace PortfolioApi.Models.User
{
    public class AuthResult
    {
        public bool Success { get; set; }
        public UserDto_Return User { get; set; }
        public string Token { get; set; }
    }
}
