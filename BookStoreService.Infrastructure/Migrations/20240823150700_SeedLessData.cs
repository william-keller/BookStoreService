using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedLessData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("38711e05-66c6-4d8d-8a72-0894346fa4c5"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "IsFeatured", "Price", "Rating", "Sales", "Stock", "Title" },
                values: new object[] { new Guid("38711e05-66c6-4d8d-8a72-0894346fa4c5"), "Harper Lee", false, 0m, 0.0, 0, 0, "To Kill a Mockingbird" });
        }
    }
}
