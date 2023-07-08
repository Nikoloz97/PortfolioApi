using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PortfolioApi.Entities.User
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Username { get; set; } 
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }
        [Required]
        [MaxLength(200)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string? FirstName { get; set; }

        [MaxLength(100)]
        public string? LastName { get; set; }

        [MaxLength(100)]    
        public string? ProfileURL { get; set; } 

        [MaxLength(1000)]
        public string? Bio { get; set; }

        public User(string username, string password, string email)
        {
            Username = username;
            Password = password;   
            Email = email;
        }

    }
}
