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

        [Required]
        [MaxLength(2000)]
        public string Text { get; set; }
        [Required]
        public DateTime CommentDate { get; set; }
        [Required]
        [MaxLength(50)]
        public string DisplayName { get; set; }
        [MaxLength(2000)]
        public string? ProfileUrl { get; set; }

        public int Likes { get; set; } 
        public int Flags { get; set; } 

        public Comment(string text)
        {
            Text = text;
        }

    }
}
