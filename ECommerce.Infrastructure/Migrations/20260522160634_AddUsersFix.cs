using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUsersFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0a853afe-0ec4-44e8-afbb-b45b4fd6e41d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("13c92f2e-d5ce-4871-9db2-a71fba189aa0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("888d4b24-fe7a-43af-a46e-9f5737639754"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { new Guid("751f8899-d03c-4f1f-9770-b4da4f0765f5"), new Guid("c6d6cafa-51a8-402b-871c-ec452dbc9c26"), "128GB Negro", "iPhone 15", 999.99m, 8 },
                    { new Guid("95126df2-d3bf-432d-9128-aa4a9c2e4301"), new Guid("17b1b21d-58f3-4d1f-bbe1-1884b604baf5"), "Protección integral", "Casco Moto", 89.99m, 25 },
                    { new Guid("f6b9d1da-b7cf-4e32-8636-6506580db6d1"), new Guid("5977da60-fdfa-49cb-916c-ff937b947bb4"), "Laptop i7 16GB", "Laptop Dell", 899.99m, 15 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("751f8899-d03c-4f1f-9770-b4da4f0765f5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("95126df2-d3bf-432d-9128-aa4a9c2e4301"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f6b9d1da-b7cf-4e32-8636-6506580db6d1"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { new Guid("0a853afe-0ec4-44e8-afbb-b45b4fd6e41d"), new Guid("261e165c-17d3-4887-b3d9-2c034dbcbdd2"), "Laptop i7 16GB", "Laptop Dell", 899.99m, 15 },
                    { new Guid("13c92f2e-d5ce-4871-9db2-a71fba189aa0"), new Guid("1782760c-11f5-4542-b979-12d94900180c"), "Protección integral", "Casco Moto", 89.99m, 25 },
                    { new Guid("888d4b24-fe7a-43af-a46e-9f5737639754"), new Guid("b7107411-e8ab-4070-8b18-6db6cdf772ac"), "128GB Negro", "iPhone 15", 999.99m, 8 }
                });
        }
    }
}
