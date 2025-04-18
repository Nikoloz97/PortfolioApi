﻿using PortfolioApi.Models.Forum.Post;

namespace PortfolioApi.Models.Forum.ForumProfile
{
    public class ForumProfileDto
    {
        public int ForumProfileId { get; set; }
        public int UserId { get; set; }

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
        public ICollection<FollowDto> Followers { get; set; } = new List<FollowDto>();
        public ICollection<FollowDto> Followings { get; set; } = new List<FollowDto>();
    }
}
