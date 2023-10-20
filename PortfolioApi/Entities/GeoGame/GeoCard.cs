using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioApi.Entities.GeoGame
{
    public class GeoCard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GeoCardId { get; set; }

        [Required]
        [MaxLength(200)]
        public string CountryName { get; set; }   
        [Required]
        [MaxLength(200)]
        public string Region { get; set; }
        [Required]
        [MaxLength(200)]
        public string Prompt { get; set; }
        [Required]
        [MaxLength(200)]
        public string QuestionType { get; set; }
        [Required]
        [MaxLength(200)]
        public string Answer { get; set; }

        [MaxLength(200)]
        public string? ImageUrl { get; set; }
        [MaxLength(200)]
        public string? OptionOne { get; set; }
        [MaxLength(200)]
        public string? OptionTwo { get; set; }
        [MaxLength(200)]
        public string? OptionThree { get; set; }
        [MaxLength(200)]
        public string? OptionFour { get; set; }

        public GeoCard(string countryName, string region, string prompt, string questionType, string answer)
        {
            Region = region;
            CountryName = countryName;
            Prompt = prompt;
            QuestionType = questionType;
            Answer = answer;    
        }
    }
}
