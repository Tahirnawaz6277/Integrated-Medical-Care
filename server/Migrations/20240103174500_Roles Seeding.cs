using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IMC_Integrated_Medical_Care_.Migrations
{
    /// <inheritdoc />
    public partial class RolesSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4e050638-06b1-4d94-9462-757e387f70a5", "4e050638-06b1-4d94-9462-757e387f70a5", "Admin", "ADMIN" },
                    { "7aa03b52-a1b4-42de-a645-583f99b0eebb", "7aa03b52-a1b4-42de-a645-583f99b0eebb", "Customer", "CUSTOMER" },
                    { "8fa1d802-1a62-44bb-9f8d-6803a4295c73", "8fa1d802-1a62-44bb-9f8d-6803a4295c73", "Service_Provider", "WRITER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e050638-06b1-4d94-9462-757e387f70a5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7aa03b52-a1b4-42de-a645-583f99b0eebb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8fa1d802-1a62-44bb-9f8d-6803a4295c73");
        }
    }
}
