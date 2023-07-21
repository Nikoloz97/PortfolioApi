using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PortfolioApi.Migrations
{
    /// <inheritdoc />
    public partial class Seeded_More_Posts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Flags", "ForumProfileId", "Likes", "PhotoURL", "PostedDate", "Text", "Title" },
                values: new object[,]
                {
                    { 4, 0, 1, 0, "https://i.iheart.com/v3/re/new_assets/6059042c7270e66c113c9c35?ops=contain(1480,0)", new DateTime(2023, 7, 10, 17, 38, 15, 0, DateTimeKind.Unspecified), "Test Text", "Test Title" },
                    { 5, 0, 1, 0, "https://i.iheart.com/v3/re/new_assets/6059042c7270e66c113c9c35?ops=contain(1480,0)", new DateTime(2023, 7, 11, 17, 38, 15, 0, DateTimeKind.Unspecified), "Test Text 2", "Test Title 2" },
                    { 6, 0, 1, 0, "https://i.iheart.com/v3/re/new_assets/6059042c7270e66c113c9c35?ops=contain(1480,0)", new DateTime(2023, 7, 12, 17, 38, 15, 0, DateTimeKind.Unspecified), "Test Text 3", "Test Title 3" },
                    { 7, 0, 1, 0, "https://i.iheart.com/v3/re/new_assets/6059042c7270e66c113c9c35?ops=contain(1480,0)", new DateTime(2023, 7, 13, 17, 38, 15, 0, DateTimeKind.Unspecified), "Test Text 4", "Test Title 4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 7);
        }
    }
}
