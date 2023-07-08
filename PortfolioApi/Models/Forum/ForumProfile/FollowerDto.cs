namespace PortfolioApi.Models.Forum.ForumProfile
{
    public class FollowerDto
    {
        public int FollowerId { get; set; }
        public string DisplayName { get; set; } = string.Empty;

        public string? ProfileURL { get; set; }
    }
}
