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
        // ProfileCardID property = corresponds to key of our navigation property (ProfileCard Entity) 
        [ForeignKey("ProfileCardID")]
        // Known as a "navigation property" (connect with ProfileCard Entity)
        public ProfileCard? ProfileCard { get; set; }
        public int ProfileCardID { get; set; }  

        public Interest(string description)
        {
            Description = description;
        }
    }
}
