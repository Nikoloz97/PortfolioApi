using PortfolioApi.Entities;

namespace PortfolioApi.Models
{
    public class ProfileCardDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
        public ICollection<Interest> Interests { get; set; } = new List<Interest>();

        public int NumberOfInterests
        {
            get { return Interests.Count; }
        }

    }
}
