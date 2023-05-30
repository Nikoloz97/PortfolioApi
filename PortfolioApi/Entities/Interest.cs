using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioApi.Entities
{
    public class Interest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [ForeignKey("ProfileCardID")]
        // Below = "navigation property" (connect with ProfileCard Entity)
        public ProfileCard? ProfileCard { get; set; }
        public int ProfileCardID { get; set; }  

        // Statement that every interest requires a description
        public Interest(string description)
        {
            Description = description;
        }
    }
}
