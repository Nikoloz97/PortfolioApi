using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PortfolioApi.Entities.Forum
{
    public class Follow
    {
        [Key]
        // Automatically generates new ID when new profile is added
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FollowId { get; set; }

        public int FollowerForumProfileId { get; set; }

        [ForeignKey("FollowerForumProfileId")]
        public ForumProfile? FollowerForumProfile { get; set; }

        public int FollowingForumProfileId { get; set; }

        [ForeignKey("FollowingForumProfileId")]
        public ForumProfile? FollowingForumProfile { get; set; }

        public Follow(int followerForumProfileId, int followingForumProfileId)
        {
            FollowerForumProfileId = followerForumProfileId;
            FollowingForumProfileId = followingForumProfileId;
        }
    }
}
