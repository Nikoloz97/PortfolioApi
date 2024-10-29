using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioApi.Migrations.User
{
    /// <inheritdoc />
    public partial class created_forumprofile_follow_relationship_onmodelcreating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Followers_ForumProfiles_ForumProfileId",
                table: "Followers");

            migrationBuilder.DropTable(
                name: "Followings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Followers",
                table: "Followers");

            migrationBuilder.DropColumn(
                name: "PhotoURL",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ProfileURL",
                table: "ForumProfiles");

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "Followers");

            migrationBuilder.DropColumn(
                name: "ProfileUrl",
                table: "Followers");

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ProfileUrl",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "ForumProfileId",
                table: "Followers",
                newName: "FollowingForumProfileId");

            migrationBuilder.RenameColumn(
                name: "FollowerId",
                table: "Followers",
                newName: "FollowerForumProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Followers_ForumProfileId",
                table: "Followers",
                newName: "IX_Followers_FollowingForumProfileId");

            migrationBuilder.AlterColumn<int>(
                name: "FollowerForumProfileId",
                table: "Followers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "FollowId",
                table: "Followers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ForumProfileId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Followers",
                table: "Followers",
                column: "FollowId");

            migrationBuilder.CreateIndex(
                name: "IX_Followers_FollowerForumProfileId",
                table: "Followers",
                column: "FollowerForumProfileId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Followers_ForumProfiles_FollowerForumProfileId",
                table: "Followers",
                column: "FollowerForumProfileId",
                principalTable: "ForumProfiles",
                principalColumn: "ForumProfileId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Followers_ForumProfiles_FollowingForumProfileId",
                table: "Followers",
                column: "FollowingForumProfileId",
                principalTable: "ForumProfiles",
                principalColumn: "ForumProfileId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_ForumProfiles_ForumProfileId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Followers_ForumProfiles_FollowerForumProfileId",
                table: "Followers");

            migrationBuilder.DropForeignKey(
                name: "FK_Followers_ForumProfiles_FollowingForumProfileId",
                table: "Followers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Followers",
                table: "Followers");

            migrationBuilder.DropIndex(
                name: "IX_Followers_FollowerForumProfileId",
                table: "Followers");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ForumProfileId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "FollowId",
                table: "Followers");

            migrationBuilder.DropColumn(
                name: "ForumProfileId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "FollowingForumProfileId",
                table: "Followers",
                newName: "ForumProfileId");

            migrationBuilder.RenameColumn(
                name: "FollowerForumProfileId",
                table: "Followers",
                newName: "FollowerId");

            migrationBuilder.RenameIndex(
                name: "IX_Followers_FollowingForumProfileId",
                table: "Followers",
                newName: "IX_Followers_ForumProfileId");

            migrationBuilder.AddColumn<string>(
                name: "PhotoURL",
                table: "Posts",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfileURL",
                table: "ForumProfiles",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FollowerId",
                table: "Followers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "Followers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfileUrl",
                table: "Followers",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "Comments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfileUrl",
                table: "Comments",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Followers",
                table: "Followers",
                column: "FollowerId");

            migrationBuilder.CreateTable(
                name: "Followings",
                columns: table => new
                {
                    FollowingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ForumProfileId = table.Column<int>(type: "int", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProfileUrl = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Followings", x => x.FollowingId);
                    table.ForeignKey(
                        name: "FK_Followings_ForumProfiles_ForumProfileId",
                        column: x => x.ForumProfileId,
                        principalTable: "ForumProfiles",
                        principalColumn: "ForumProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Followings_ForumProfileId",
                table: "Followings",
                column: "ForumProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Followers_ForumProfiles_ForumProfileId",
                table: "Followers",
                column: "ForumProfileId",
                principalTable: "ForumProfiles",
                principalColumn: "ForumProfileId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
