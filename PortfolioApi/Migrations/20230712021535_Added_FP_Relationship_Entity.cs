using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PortfolioApi.Migrations
{
    /// <inheritdoc />
    public partial class Added_FP_Relationship_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ForumProfileFollowers");

            migrationBuilder.CreateTable(
                name: "ForumProfileSimplified",
                columns: table => new
                {
                    ForumProfileSimplifiedId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DisplayName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    ProfileURL = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    ForumProfileId = table.Column<int>(type: "INTEGER", nullable: true),
                    ForumProfileId1 = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumProfileSimplified", x => x.ForumProfileSimplifiedId);
                    table.ForeignKey(
                        name: "FK_ForumProfileSimplified_ForumProfiles_ForumProfileId",
                        column: x => x.ForumProfileId,
                        principalTable: "ForumProfiles",
                        principalColumn: "ForumProfileId");
                    table.ForeignKey(
                        name: "FK_ForumProfileSimplified_ForumProfiles_ForumProfileId1",
                        column: x => x.ForumProfileId1,
                        principalTable: "ForumProfiles",
                        principalColumn: "ForumProfileId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ForumProfileSimplified_ForumProfileId",
                table: "ForumProfileSimplified",
                column: "ForumProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumProfileSimplified_ForumProfileId1",
                table: "ForumProfileSimplified",
                column: "ForumProfileId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ForumProfileSimplified");

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
    }
}
