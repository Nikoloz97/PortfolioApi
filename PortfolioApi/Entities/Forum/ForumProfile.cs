using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace PortfolioApi.Entities.Forum
{
    public class ForumProfile
    {
        [Key]
        // Automatically generates new ID when new profile is added
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ForumProfileId { get; set; }

        [ForeignKey("UserId")]
        public User.User? User { get; set; }
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string DisplayName { get; set; }

        [Range(0, 100)]
        public int? Age { get; set; }

        public ICollection<Interest> Interests { get; set; } = new List<Interest>();

        public ICollection<Post> Posts { get; set; } = new List<Post>();

        public ICollection<Follow> Followers { get; set; } = new List<Follow>();
        public ICollection<Follow> Followings { get; set; } = new List<Follow>();


        public ForumProfile(int userId, string displayName)
        {
            DisplayName = displayName;
            UserId = userId;
        }
    }
}
