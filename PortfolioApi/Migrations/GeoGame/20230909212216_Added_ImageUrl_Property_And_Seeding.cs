using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioApi.Migrations.GeoGame
{
    /// <inheritdoc />
    public partial class Added_ImageUrl_Property_And_Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "GeoCards",
                type: "TEXT",
                maxLength: 200,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "GeoCards",
                keyColumn: "GeoCardId",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/thumb/6/67/Georgia_%28orthographic_projection_with_inset%29.svg/250px-Georgia_%28orthographic_projection_with_inset%29.svg.png");

            migrationBuilder.UpdateData(
                table: "GeoCards",
                keyColumn: "GeoCardId",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://www.freeworldmaps.net/southamerica/southamerica-blackandwhite-hd.jpg");

            migrationBuilder.UpdateData(
                table: "GeoCards",
                keyColumn: "GeoCardId",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://www.seabourn.com/content/dam/sbn65/inventory-assets/ports/o/bkk/port-laem-chabang-bangkok-1334x1001.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "GeoCards");
        }
    }
}
