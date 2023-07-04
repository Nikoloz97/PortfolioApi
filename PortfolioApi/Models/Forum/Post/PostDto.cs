namespace PortfolioApi.Models.Forum.Post
{
    public class PostDto
    {
        public int PostId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public int Likes { get; set; } = 0;
        public int Flags { get; set; } = 0;

        public string? PhotoURL { get; set; }

        public int CommentCount
        {
            get
            { return Comments.Count; }
        }

        public ICollection<CommentDto> Comments { get; set; } = new List<CommentDto>();
    }
}
