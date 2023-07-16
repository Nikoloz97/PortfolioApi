using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace PortfolioApi.Entities.Forum
{
    public class ForumProfileSimplified
    {
        [Key]
        // Automatically generates new ID when new profile is added
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ForumProfileSimplifiedId { get; set; }

        [Required]
        [MaxLength(50)]
        public string DisplayName { get; set; }

        [MaxLength(2000)]
        public string? ProfileURL { get; set; }

   
    }
}
