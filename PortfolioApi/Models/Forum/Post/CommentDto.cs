namespace PortfolioApi.Models.Forum.Post
{
    public class CommentDto
    {
        public int CommentId { get; set; }
        public string Text { get; set; } = string.Empty;
        public int Likes { get; set; } = 0;
        public int Flags { get; set; } = 0;
        public DateTime CommentDate { get; set; }
        public string DisplayName { get; set; }
        public string ProfileUrl { get; set; }
    }
}
