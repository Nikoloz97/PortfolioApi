namespace PortfolioApi.Exceptions
{
    public class PasswordNotFoundException : Exception
    {
        public PasswordNotFoundException() : base() { }
        public PasswordNotFoundException(string message) : base(message) { }
        public PasswordNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
