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

        [ForeignKey("ForumProfileId")]
        public ForumProfile? ForumProfile { get; set; }
        public int ForumProfileId { get; set; }

        [Required]
        [MaxLength(50)]
        public string DisplayName { get; set; }

        [MaxLength(2000)]
        public string? ProfileURL { get; set; }

        public Following(int forumProfileId, string displayName)
        {
            ForumProfileId = forumProfileId;
            DisplayName = displayName;
        }
    }
}
