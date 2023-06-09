using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PortfolioApi.Entities.User
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Username { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Password { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string DisplayName { get; set; } = string.Empty;

        [MaxLength(100)]    
        public string ProfileURL { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Email { get; set; }

        [MaxLength(1000)]
        public string Bio { get; set; }

        public User(string username, string password, string email, string displayName)
        {
            Username = username;
            Password = password;   
            DisplayName = displayName;
            Email = email;
        }

    }
}
