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

        [Required]
        [MaxLength(50)]
        public string DisplayName { get; set; }

        [Range(0, 100)]
        public int? Age { get; set; }
        [MaxLength(2000)]
        public string? ProfileURL { get; set; }

        public ICollection<Interest> Interests { get; set; } = new List<Interest>();
        public ICollection<Post> Posts { get; set; } = new List<Post>();

        //TODO: Think about creating a separate "follow" entity
            // Possible benefit = follow entity will have less properties to store/keep track of 
        public ICollection<Follower> Followers { get; set; } = new List<Follower>();
        public ICollection<Following> Followings { get; set; } = new List<Following>();

        public ForumProfile(string displayName)
        {
            DisplayName = displayName;
        }
    }
}
