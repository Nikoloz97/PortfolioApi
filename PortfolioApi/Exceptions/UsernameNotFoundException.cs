namespace PortfolioApi.Exceptions
{
    public class UsernameNotFoundException : Exception
    {
        public UsernameNotFoundException() : base() { }
        public UsernameNotFoundException(string message) : base(message) { }
        public UsernameNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
