﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioApi.Entities.Forum
{
    public class ProfileCard
    {
        [Key]
        // Automatically generates new ID when new profile is added
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(10)]
        public int? Age { get; set; }

        [MaxLength(2000)]
        public string? ProfileURL { get; set; }

        public ICollection<Interest> Interests { get; set; } = new List<Interest>();

        public ProfileCard(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

        }
    }
}