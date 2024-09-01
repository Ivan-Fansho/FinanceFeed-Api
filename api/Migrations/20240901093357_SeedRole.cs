using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class SeedRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "29cc1473-d9d6-4792-8695-d92ed35ca621", "8b84a496-ae64-4e13-aa7c-b70f6d0f21cd", "User", "User" },
                    { "db56533c-52b3-4667-b4c5-dccfac87864f", "c6307f7b-62ed-4e03-accd-57331167a763", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29cc1473-d9d6-4792-8695-d92ed35ca621");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db56533c-52b3-4667-b4c5-dccfac87864f");
        }
    }
}
