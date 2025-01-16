using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("48d6bf86-0b06-4729-bf45-43023d86301f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a0f1fffc-d909-406e-8623-4e3eb794c0c5"));

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "SpecificationId",
                keyValue: new Guid("2e0b9d6d-2c05-4422-8590-61a84ab12bfa"));

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "SpecificationId",
                keyValue: new Guid("72f67a3b-a0cf-4cf6-944b-86ead27959c7"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("4e98b18b-c5a5-45df-9397-1f78570c681e"), 3, "Sample Product 2", 299.99m },
                    { new Guid("f3dce1c3-3ff4-49e4-a325-796636072f3f"), 1, "Sample Product 1", 199.99m }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "SpecificationId", "Key", "ProductId", "Value" },
                values: new object[,]
                {
                    { new Guid("7a533664-1ae3-4799-9722-9e184c9e3a7c"), "Color", null, "Red" },
                    { new Guid("b76cb809-033e-493d-bfab-b95520cfa9bb"), "Size", null, "Medium" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4e98b18b-c5a5-45df-9397-1f78570c681e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f3dce1c3-3ff4-49e4-a325-796636072f3f"));

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "SpecificationId",
                keyValue: new Guid("7a533664-1ae3-4799-9722-9e184c9e3a7c"));

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "SpecificationId",
                keyValue: new Guid("b76cb809-033e-493d-bfab-b95520cfa9bb"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("48d6bf86-0b06-4729-bf45-43023d86301f"), 1, "Sample Product 1", 199.99m },
                    { new Guid("a0f1fffc-d909-406e-8623-4e3eb794c0c5"), 3, "Sample Product 2", 299.99m }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "SpecificationId", "Key", "ProductId", "Value" },
                values: new object[,]
                {
                    { new Guid("2e0b9d6d-2c05-4422-8590-61a84ab12bfa"), "Color", null, "Red" },
                    { new Guid("72f67a3b-a0cf-4cf6-944b-86ead27959c7"), "Size", null, "Medium" }
                });
        }
    }
}
