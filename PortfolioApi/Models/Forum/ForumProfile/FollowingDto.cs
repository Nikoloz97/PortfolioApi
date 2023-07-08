namespace PortfolioApi.Models.Forum.ForumProfile
{
    public class FollowingDto
    {
        public int FollowingId { get; set; }
        public string DisplayName { get; set; } = string.Empty;

        public string? ProfileURL { get; set; }
    }
}
