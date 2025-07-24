using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMovieModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "Movies",
                comment: "Movie in the system");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Movies",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "Movie Title",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "ReleaseDate",
                table: "Movies",
                type: "date",
                nullable: false,
                comment: "Movie Release Date",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Movies",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: true,
                comment: "Movie image url",
                oldClrType: typeof(string),
                oldType: "nvarchar(2048)",
                oldMaxLength: 2048,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Genre",
                table: "Movies",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "Movie Genre",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "Movies",
                type: "int",
                maxLength: 300,
                nullable: false,
                comment: "Movie Duration",
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "Director",
                table: "Movies",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "Movie Director",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Movies",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                comment: "Movie Description",
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Movies",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Movie Identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("02b52bb0-1c2b-49a4-ba66-6d33f81d38d1"),
                column: "ReleaseDate",
                value: new DateOnly(2008, 7, 18));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("16376cc6-b3e0-4bf7-a0e4-9cbd1490522c"),
                column: "ReleaseDate",
                value: new DateOnly(2014, 11, 7));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("4491b6f5-2a11-4c4c-8c6b-c371f47d2152"),
                column: "ReleaseDate",
                value: new DateOnly(1994, 10, 14));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("54082f99-023b-4d68-89ac-44c00a0958d0"),
                column: "ReleaseDate",
                value: new DateOnly(1994, 7, 6));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("68fb84b9-ef2a-402f-b4fc-595006f5c275"),
                column: "ReleaseDate",
                value: new DateOnly(2010, 7, 16));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("777634e2-3bb6-4748-8e91-7a10b70c78ac"),
                column: "ReleaseDate",
                value: new DateOnly(2001, 5, 1));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("811a1a9e-61a8-4f6f-acb0-55a252c2b713"),
                column: "ReleaseDate",
                value: new DateOnly(2009, 12, 18));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("844d9abd-104d-41ab-b14a-ce059779ad91"),
                column: "ReleaseDate",
                value: new DateOnly(1999, 3, 31));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("ab2c3213-48a7-41ea-9393-45c60ef813e6"),
                column: "ReleaseDate",
                value: new DateOnly(1997, 12, 19));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("ae50a5ab-9642-466f-b528-3cc61071bb4c"),
                column: "ReleaseDate",
                value: new DateOnly(2005, 11, 1));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("bf9ff8b3-3209-4b18-9f4b-5172c45b73f9"),
                column: "ReleaseDate",
                value: new DateOnly(2000, 5, 5));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("e00208b1-cb12-4bd4-8ac1-36ab62f7b4c9"),
                column: "ReleaseDate",
                value: new DateOnly(1994, 9, 23));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "Movies",
                oldComment: "Movie in the system");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Movies",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Movie Title");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldComment: "Movie Release Date");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Movies",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2048)",
                oldMaxLength: 2048,
                oldNullable: true,
                oldComment: "Movie image url");

            migrationBuilder.AlterColumn<string>(
                name: "Genre",
                table: "Movies",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "Movie Genre");

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "Movies",
                type: "int",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 300,
                oldComment: "Movie Duration");

            migrationBuilder.AlterColumn<string>(
                name: "Director",
                table: "Movies",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Movie Director");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Movies",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldComment: "Movie Description");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Movies",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Movie Identifier");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("02b52bb0-1c2b-49a4-ba66-6d33f81d38d1"),
                column: "ReleaseDate",
                value: new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("16376cc6-b3e0-4bf7-a0e4-9cbd1490522c"),
                column: "ReleaseDate",
                value: new DateTime(2014, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("4491b6f5-2a11-4c4c-8c6b-c371f47d2152"),
                column: "ReleaseDate",
                value: new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("54082f99-023b-4d68-89ac-44c00a0958d0"),
                column: "ReleaseDate",
                value: new DateTime(1994, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("68fb84b9-ef2a-402f-b4fc-595006f5c275"),
                column: "ReleaseDate",
                value: new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("777634e2-3bb6-4748-8e91-7a10b70c78ac"),
                column: "ReleaseDate",
                value: new DateTime(2001, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("811a1a9e-61a8-4f6f-acb0-55a252c2b713"),
                column: "ReleaseDate",
                value: new DateTime(2009, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("844d9abd-104d-41ab-b14a-ce059779ad91"),
                column: "ReleaseDate",
                value: new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("ab2c3213-48a7-41ea-9393-45c60ef813e6"),
                column: "ReleaseDate",
                value: new DateTime(1997, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("ae50a5ab-9642-466f-b528-3cc61071bb4c"),
                column: "ReleaseDate",
                value: new DateTime(2005, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("bf9ff8b3-3209-4b18-9f4b-5172c45b73f9"),
                column: "ReleaseDate",
                value: new DateTime(2000, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("e00208b1-cb12-4bd4-8ac1-36ab62f7b4c9"),
                column: "ReleaseDate",
                value: new DateTime(1994, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
