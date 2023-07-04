using PortfolioApi.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PortfolioApi.Models.Forum.ForumProfile
{
    public class ForumProfileWithoutInterestsDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public int? Age { get; set; }
        public string? ProfileURL { get; set; }
    }
}
