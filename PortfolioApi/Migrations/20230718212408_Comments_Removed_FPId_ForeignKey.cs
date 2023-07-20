using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioApi.Migrations
{
    /// <inheritdoc />
    public partial class Comments_Removed_FPId_ForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_ForumProfiles_ForumProfileId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ForumProfileId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ForumProfileId",
                table: "Comments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ForumProfileId",
                table: "Comments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "ForumProfileId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "ForumProfileId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "ForumProfileId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "ForumProfileId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ForumProfileId",
                table: "Comments",
                column: "ForumProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_ForumProfiles_ForumProfileId",
                table: "Comments",
                column: "ForumProfileId",
                principalTable: "ForumProfiles",
                principalColumn: "ForumProfileId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
