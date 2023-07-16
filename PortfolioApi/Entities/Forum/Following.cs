using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PortfolioApi.Entities.Forum
{
    public class Following
    {
        [Key]
        // Automatically generates new ID when new profile is added
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FollowingId { get; set; }

        // Of profile following
        [ForeignKey("ForumProfileId")]
        public ForumProfile? ForumProfile { get; set; }
        public int ForumProfileId { get; set; }

        // Of profile being followed
        [Required]
        [MaxLength(50)]
        public string DisplayName { get; set; }

        // Of profile being followed
        [MaxLength(2000)]
        public string? ProfileUrl { get; set; }

        public Following(int forumProfileId, string displayName)
        {
            ForumProfileId = forumProfileId;
            DisplayName = displayName;
        }
    }
}
