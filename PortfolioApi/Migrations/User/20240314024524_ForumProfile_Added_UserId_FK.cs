using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioApi.Migrations.User
{
    /// <inheritdoc />
    public partial class ForumProfile_Added_UserId_FK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ForumProfiles",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ForumProfiles_UserId",
                table: "ForumProfiles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumProfiles_Users_UserId",
                table: "ForumProfiles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumProfiles_Users_UserId",
                table: "ForumProfiles");

            migrationBuilder.DropIndex(
                name: "IX_ForumProfiles_UserId",
                table: "ForumProfiles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ForumProfiles");
        }
    }
}
