using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorAppGames.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RelaseData",
                table: "Game",
                newName: "YTUrl");

            migrationBuilder.AddColumn<DateTime>(
                name: "RelaseDate",
                table: "Game",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RelaseDate",
                table: "Game");

            migrationBuilder.RenameColumn(
                name: "YTUrl",
                table: "Game",
                newName: "RelaseData");
        }
    }
}
