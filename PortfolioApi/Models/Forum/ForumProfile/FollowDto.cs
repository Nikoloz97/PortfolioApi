namespace PortfolioApi.Models.Forum.ForumProfile
{
    public class FollowDto
    {
        public int FollowId { get; set; }
        public int FollowerForumProfileId { get; set; }
        public int FollowingForumProfileId { get; set; }
    }
}
