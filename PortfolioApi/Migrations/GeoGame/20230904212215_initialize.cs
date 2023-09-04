using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PortfolioApi.Migrations.GeoGame
{
    /// <inheritdoc />
    public partial class initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeoCards",
                columns: table => new
                {
                    GeoCardId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CountryName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Region = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Prompt = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    QuestionType = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Answer = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    OptionOne = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    OptionTwo = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    OptionThree = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    OptionFour = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeoCards", x => x.GeoCardId);
                });

            migrationBuilder.InsertData(
                table: "GeoCards",
                columns: new[] { "GeoCardId", "Answer", "CountryName", "OptionFour", "OptionOne", "OptionThree", "OptionTwo", "Prompt", "QuestionType", "Region" },
                values: new object[,]
                {
                    { 1, "Tbilisi", "Georgia", "Berlin", "Tbilisi", "Paris", "Yerevan", "What is the capital of Georgia?", "Multiple Choice", "Eastern Europe" },
                    { 2, "Argentina", "Argentina", "Argentina", "Peru", "Uruguay", "Brazil", "Which of the following options is on the southern-most tip of South America?", "Multiple Choice", "South America" },
                    { 3, "Thailand", "Thailand", "China", "Myanmar", "Turkey", "Thailand", "Which country is Bangkok located in?", "Free Response", "Asia" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeoCards");
        }
    }
}
