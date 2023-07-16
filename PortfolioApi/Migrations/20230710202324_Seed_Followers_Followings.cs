using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PortfolioApi.Migrations
{
    /// <inheritdoc />
    public partial class Seed_Followers_Followings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Follower");

            migrationBuilder.DropTable(
                name: "Following");

            migrationBuilder.CreateTable(
                name: "ForumProfileFollowers",
                columns: table => new
                {
                    FollowerId = table.Column<int>(type: "INTEGER", nullable: false),
                    FollowingId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumProfileFollowers", x => new { x.FollowerId, x.FollowingId });
                    table.ForeignKey(
                        name: "FK_ForumProfileFollowers_ForumProfiles_FollowerId",
                        column: x => x.FollowerId,
                        principalTable: "ForumProfiles",
                        principalColumn: "ForumProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ForumProfileFollowers_ForumProfiles_FollowingId",
                        column: x => x.FollowingId,
                        principalTable: "ForumProfiles",
                        principalColumn: "ForumProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ForumProfileFollowers",
                columns: new[] { "FollowerId", "FollowingId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ForumProfileFollowers_FollowingId",
                table: "ForumProfileFollowers",
                column: "FollowingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ForumProfileFollowers");

            migrationBuilder.CreateTable(
                name: "Follower",
                columns: table => new
                {
                    FollowerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ForumProfileId = table.Column<int>(type: "INTEGER", nullable: false),
                    DisplayName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    ProfileURL = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Follower", x => x.FollowerId);
                    table.ForeignKey(
                        name: "FK_Follower_ForumProfiles_ForumProfileId",
                        column: x => x.ForumProfileId,
                        principalTable: "ForumProfiles",
                        principalColumn: "ForumProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Following",
                columns: table => new
                {
                    FollowingId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ForumProfileId = table.Column<int>(type: "INTEGER", nullable: false),
                    DisplayName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    ProfileURL = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Following", x => x.FollowingId);
                    table.ForeignKey(
                        name: "FK_Following_ForumProfiles_ForumProfileId",
                        column: x => x.ForumProfileId,
                        principalTable: "ForumProfiles",
                        principalColumn: "ForumProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Follower_ForumProfileId",
                table: "Follower",
                column: "ForumProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Following_ForumProfileId",
                table: "Following",
                column: "ForumProfileId");
        }
    }
}
