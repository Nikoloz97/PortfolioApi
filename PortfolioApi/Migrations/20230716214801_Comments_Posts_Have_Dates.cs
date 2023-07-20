using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioApi.Migrations
{
    /// <inheritdoc />
    public partial class Comments_Posts_Have_Dates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PostedDate",
                table: "Posts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CommentDate",
                table: "Comments",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "CommentDate",
                value: new DateTime(2023, 7, 12, 20, 38, 15, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "CommentDate",
                value: new DateTime(2023, 7, 13, 20, 38, 15, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "CommentDate",
                value: new DateTime(2023, 7, 14, 20, 38, 15, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "CommentDate",
                value: new DateTime(2023, 7, 15, 20, 38, 15, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "PostedDate",
                value: new DateTime(2023, 7, 9, 17, 38, 15, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "PostedDate",
                value: new DateTime(2023, 7, 10, 19, 38, 15, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "PostedDate",
                value: new DateTime(2023, 7, 11, 20, 38, 15, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostedDate",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CommentDate",
                table: "Comments");
        }
    }
}
