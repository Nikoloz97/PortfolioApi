using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PortfolioApi.Migrations.User
{
    /// <inheritdoc />
    public partial class Added_GeoCards : Migration
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
                    ImageUrl = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
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
                columns: new[] { "GeoCardId", "Answer", "CountryName", "ImageUrl", "OptionFour", "OptionOne", "OptionThree", "OptionTwo", "Prompt", "QuestionType", "Region" },
                values: new object[,]
                {
                    { 1, "Tbilisi", "Georgia", "https://upload.wikimedia.org/wikipedia/commons/thumb/6/67/Georgia_%28orthographic_projection_with_inset%29.svg/250px-Georgia_%28orthographic_projection_with_inset%29.svg.png", "Berlin", "Tbilisi", "Paris", "Yerevan", "What is the capital of Georgia?", "Multiple Choice", "Eastern Europe" },
                    { 2, "Argentina", "Argentina", "https://www.freeworldmaps.net/southamerica/southamerica-blackandwhite-hd.jpg", "Argentina", "Peru", "Uruguay", "Brazil", "Which of the following options is on the southern-most tip of South America?", "Multiple Choice", "South America" },
                    { 3, "Thailand", "Thailand", "https://www.seabourn.com/content/dam/sbn65/inventory-assets/ports/o/bkk/port-laem-chabang-bangkok-1334x1001.jpg", "China", "Myanmar", "Turkey", "Thailand", "Which country is Bangkok located in?", "Free Response", "Asia" }
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
