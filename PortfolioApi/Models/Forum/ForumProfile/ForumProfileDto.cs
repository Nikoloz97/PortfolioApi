using PortfolioApi.Entities;
using PortfolioApi.Models.Forum.Post;

namespace PortfolioApi.Models.Forum.ForumProfile
{
    public class ForumProfileDto
    {
        public int ForumProfileId { get; set; }
        public string DisplayName { get; set; } = string.Empty;

        public int? Age { get; set; }
        public string? ProfileURL { get; set; }

        public int PostsCount
        {
            get { return Posts.Count; }
        }
        public int FollowerCount
        {
            get { return Followers.Count; }
        }
        public int FollowingCount
        {
            get { return Followings.Count; }
        }

        public ICollection<InterestDto> Interests { get; set; } = new List<InterestDto>();
        public ICollection<PostDto> Posts { get; set; } = new List<PostDto>();
        public ICollection<FollowerDto> Followers { get; set; } = new List<FollowerDto>();
        public ICollection<FollowingDto> Followings { get; set; } = new List<FollowingDto>();
    }
}
