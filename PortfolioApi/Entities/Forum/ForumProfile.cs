using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioApi.Entities.Forum
{
    public class ForumProfile
    {
        [Key]
        // Automatically generates new ID when new profile is added
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ForumProfileId { get; set; }

        [ForeignKey("UserId")]
        //TODO: Fix this User reference
        public PortfolioApi.Entities.User.User? User { get; set; }
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Range(0, 100)]
        public int? Age { get; set; }
        [MaxLength(2000)]
        public string? ProfileURL { get; set; }

        public ICollection<Interest> Interests { get; set; } = new List<Interest>();
        public ICollection<Post> Posts { get; set; } = new List<Post>();
        //TODO: Think about creating a separate "follow" entity
            // Possible benefit = follow entity will have less properties to store/keep track of 
        public ICollection<ForumProfile> Followers { get; set; } = new List<ForumProfile>();
        public ICollection<ForumProfile> Following { get; set; } = new List<ForumProfile>();

        // TODO: Add UserId in constructor? (otherwise, get a FK constraint) 
        public ForumProfile(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

        }
    }
}
