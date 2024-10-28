using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PortfolioApi.Entities.Forum
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }

        [ForeignKey("PostId")]
        public Post? Post { get; set; }
        public int PostId { get; set; }

        [ForeignKey("ForumProfileId")]
        public ForumProfile? ForumProfile { get; set; }
        public int ForumProfileId { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Text { get; set; }
        
        public int Likes { get; set; } = 0;

        public int Flags { get; set; } = 0;

        [Required]
        public DateTime CommentDate { get; set; }

        public Comment(string text, DateTime commentDate)
        {
            Text = text;
            CommentDate = commentDate;
        }

    }
}
