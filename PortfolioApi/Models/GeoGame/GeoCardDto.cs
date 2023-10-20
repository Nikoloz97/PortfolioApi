namespace PortfolioApi.Models.GeoGame
{
    public class GeoCardDto
    {

        public int GeoCardId { get; set; }
        public string CountryName { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string Prompt { get; set; } = string.Empty;
        public string QuestionType { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public string? OptionOne { get; set; }
        public string? OptionTwo { get; set; }
        public string? OptionThree { get; set; }
        public string? OptionFour { get; set; }
    }
}
