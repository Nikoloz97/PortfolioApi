using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PortfolioApi.Entities.Forum
{
    public class Follower
    {
        [Key]
        // Automatically generates new ID when new profile is added
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FollowerId { get; set; }

        // Of person being followed 
        [ForeignKey("ForumProfileId")]
        public ForumProfile? ForumProfile { get; set; }
        public int ForumProfileId { get; set; }

        // Of person following profile 
        [Required]
        [MaxLength(50)]
        public string DisplayName { get; set; }

        // Of person following profile 
        [MaxLength(2000)]
        public string? ProfileUrl { get; set; }

        public Follower(int forumProfileId, string displayName)
        {
            ForumProfileId = forumProfileId;
            DisplayName = displayName;
        }

    }
}
