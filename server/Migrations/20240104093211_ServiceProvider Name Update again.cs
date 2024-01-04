using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMC_Integrated_Medical_Care_.Migrations
{
    /// <inheritdoc />
    public partial class ServiceProviderNameUpdateagain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8fa1d802-1a62-44bb-9f8d-6803a4295c73",
                column: "Name",
                value: "ServiceProvider");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8fa1d802-1a62-44bb-9f8d-6803a4295c73",
                column: "Name",
                value: "Service_Provider");
        }
    }
}
