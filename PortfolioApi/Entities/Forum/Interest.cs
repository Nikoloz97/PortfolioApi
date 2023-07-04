using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioApi.Entities.Forum
{
    public class Interest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InterestId { get; set; }

        [ForeignKey("ForumProfileId")]
        // Below = "navigation property" (connect with ProfileCard Entity)
        public ForumProfile? ForumProfile { get; set; }
        public int ForumProfileId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        // Statement that every interest requires a description
        public Interest(string description)
        {
            Description = description;
        }
    }
}
