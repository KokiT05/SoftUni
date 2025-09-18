using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeSharingPlatform.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddQueryFilter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd372d58-aae6-4dcc-ba45-cca00613558b", "AQAAAAIAAYagAAAAEHOVxppNliXOR8/H8SpqLv5hcoC9xKdJb2EL5pU1wb7FVV/d8oEZR9GLiPcwLSsL7A==", "7341c14b-76e0-46c3-814b-fa693bab4c9f" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 9, 4, 20, 8, 6, 113, DateTimeKind.Local).AddTicks(3540));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 9, 4, 20, 8, 6, 113, DateTimeKind.Local).AddTicks(3600));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 9, 4, 20, 8, 6, 113, DateTimeKind.Local).AddTicks(3602));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8bf3a049-a383-4854-a4eb-b5d9852a9120", "AQAAAAIAAYagAAAAEGRFmFSDzTPJGt1HojhYf0JrgYp9ygDu1k1+OKFo0T1vrlaogXoEHombA8mUXCRFbA==", "896f3d1b-6686-44e0-976c-58fad4868a14" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 9, 4, 20, 5, 42, 739, DateTimeKind.Local).AddTicks(5690));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 9, 4, 20, 5, 42, 739, DateTimeKind.Local).AddTicks(5751));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 9, 4, 20, 5, 42, 739, DateTimeKind.Local).AddTicks(5754));
        }
    }
}
