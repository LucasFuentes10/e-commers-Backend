using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUsersTableV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2af0244d-e651-4f27-acfb-6957e0d654bb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5324e013-d18e-4904-ad01-07ac74fde4ba"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fe2dca04-524d-48f5-9a84-89e17f7ecfcd"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("2af0244d-e651-4f27-acfb-6957e0d654bb"), new Guid("6a87409b-1a7b-4006-8fb8-64def972e0d8"), "Protección integral", "Casco Moto", 89.99m, 25 },
                    { new Guid("5324e013-d18e-4904-ad01-07ac74fde4ba"), new Guid("6b048cd1-dd90-45c4-beab-423bac52d355"), "Laptop i7 16GB", "Laptop Dell", 899.99m, 15 },
                    { new Guid("fe2dca04-524d-48f5-9a84-89e17f7ecfcd"), new Guid("63746d74-577e-4701-acea-c03bce298e48"), "128GB Negro", "iPhone 15", 999.99m, 8 }
                });
        }
    }
}
