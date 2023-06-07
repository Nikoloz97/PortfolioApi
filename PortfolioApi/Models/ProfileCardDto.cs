using PortfolioApi.Entities;

namespace PortfolioApi.Models
{
    public class ProfileCardDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int? Age { get; set; }
        public string? ProfileURL { get; set; }

        public int NumberOfInterests
        {
            get { return Interests.Count; }
        }

        public ICollection<InterestDto> Interests { get; set; } = new List<InterestDto>();
    }
}
