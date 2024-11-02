using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PortfolioApi.Entities.Forum
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostId { get; set; }

        [ForeignKey("ForumProfileId")]
        public ForumProfile? ForumProfile { get; set; }
        public int ForumProfileId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Text { get; set; }

        [Required]
        public DateTime PostedDate { get; set; }

        [Required]
        [Range(0, 1_000_000)]
        public int Likes { get; set; }
        [Required]
        [Range(0, 1_000_000)]
        public int Flags { get; set; }

        public string? PhotoURL { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public Post(string title, string text, DateTime postedDate)
        {
            Title = title;
            Text = text;
            PostedDate = postedDate; 
        }
    }
}
