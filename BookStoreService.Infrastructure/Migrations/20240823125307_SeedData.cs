using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStoreService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "IsFeatured", "Price", "Rating", "Sales", "Stock", "Title" },
                values: new object[,]
                {
                    { new Guid("1e209cbf-5175-4205-89cb-0cd33ea24987"), "George Orwell", false, 0m, 0.0, 0, 0, "1984" },
                    { new Guid("38711e05-66c6-4d8d-8a72-0894346fa4c5"), "Harper Lee", false, 0m, 0.0, 0, 0, "To Kill a Mockingbird" },
                    { new Guid("cfe0191a-bde6-4b6c-8bd3-d097cf557043"), "F. Scott Fitzgerald", false, 0m, 0.0, 0, 0, "The Great Gatsby" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("1e209cbf-5175-4205-89cb-0cd33ea24987"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("38711e05-66c6-4d8d-8a72-0894346fa4c5"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("cfe0191a-bde6-4b6c-8bd3-d097cf557043"));
        }
    }
}
