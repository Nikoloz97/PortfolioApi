using PortfolioApi.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PortfolioApi.Models.Forum.Post;

namespace PortfolioApi.Models.Forum.ForumProfile
{
    public class ForumProfileWithoutInterestsDto
    {
        public int ForumProfileId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

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
            get { return Following.Count; }
        }

        public ICollection<PostDto> Posts { get; set; } = new List<PostDto>();
        public ICollection<ForumProfileDto> Followers { get; set; } = new List<ForumProfileDto>();
        public ICollection<ForumProfileDto> Following { get; set; } = new List<ForumProfileDto>();
    }
}
