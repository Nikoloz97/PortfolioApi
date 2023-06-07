﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioApi.Migrations
{
    /// <inheritdoc />
    public partial class ForumDbProfileCard_Add_ProfileURL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "ProfileCards",
                type: "INTEGER",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<string>(
                name: "ProfileURL",
                table: "ProfileCards",
                type: "TEXT",
                maxLength: 500,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ProfileCards",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProfileURL",
                value: "https://www.google.com/imgres?imgurl=https%3A%2F%2Fupload.wikimedia.org%2Fwikipedia%2Fcommons%2F9%2F93%2FFuture_-_Openair_Frauenfeld_2019_01_%2528cropped%2529.jpg&tbnid=qN1q-b-Wi0r3-M&vet=12ahUKEwiukaSe0a7_AhWEKt4AHYSpD1QQMygFegUIARD0AQ..i&imgrefurl=https%3A%2F%2Fen.wikipedia.org%2Fwiki%2FFuture_(rapper)&docid=gYBGH5SZQh0QGM&w=2865&h=3556&q=future&ved=2ahUKEwiukaSe0a7_AhWEKt4AHYSpD1QQMygFegUIARD0AQ");

            migrationBuilder.UpdateData(
                table: "ProfileCards",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProfileURL",
                value: "data:image/jpeg;base64,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");

            migrationBuilder.UpdateData(
                table: "ProfileCards",
                keyColumn: "Id",
                keyValue: 3,
                column: "ProfileURL",
                value: "data:image/jpeg;base64,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");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileURL",
                table: "ProfileCards");

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "ProfileCards",
                type: "INTEGER",
                maxLength: 10,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldMaxLength: 10,
                oldNullable: true);
        }
    }
}
