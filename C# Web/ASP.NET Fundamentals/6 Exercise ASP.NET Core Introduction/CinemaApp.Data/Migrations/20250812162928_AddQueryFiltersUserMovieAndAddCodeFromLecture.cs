using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddQueryFiltersUserMovieAndAddCodeFromLecture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMovies_AspNetUsers_UserId",
                table: "UserMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMovies_Movies_MovieId",
                table: "UserMovies");

            migrationBuilder.AlterTable(
                name: "UserMovies",
                comment: "User Watchlist entry in the system.");

            migrationBuilder.AlterColumn<Guid>(
                name: "MovieId",
                table: "UserMovies",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Foreign key to the referenced Movie. Part of the entity composite PK.",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserMovies",
                type: "nvarchar(450)",
                nullable: false,
                comment: "Foreign key to the referenced AspNetUser. Part of the entity composite PK.",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserMovies",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Show if UserMovie entry is deleted");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovies_AspNetUsers_UserId",
                table: "UserMovies",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovies_Movies_MovieId",
                table: "UserMovies",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMovies_AspNetUsers_UserId",
                table: "UserMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMovies_Movies_MovieId",
                table: "UserMovies");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserMovies");

            migrationBuilder.AlterTable(
                name: "UserMovies",
                oldComment: "User Watchlist entry in the system.");

            migrationBuilder.AlterColumn<Guid>(
                name: "MovieId",
                table: "UserMovies",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Foreign key to the referenced Movie. Part of the entity composite PK.");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserMovies",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "Foreign key to the referenced AspNetUser. Part of the entity composite PK.");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovies_AspNetUsers_UserId",
                table: "UserMovies",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovies_Movies_MovieId",
                table: "UserMovies",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
