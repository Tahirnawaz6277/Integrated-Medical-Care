using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMC_Integrated_Medical_Care_.Migrations
{
    /// <inheritdoc />
    public partial class SeedingForAdminagai : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7da58f98-178a-4bb0-b8fe-f4518ad64d21");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName", "contact", "firstName", "gender", "lastName" },
                values: new object[] { "7da58f98-178a-4bb0-b8fe-f4518ad64d21", 0, "57ff4499-fa9b-4488-a41d-37febfbbc32d", "User", "Muhammadtalha@gmail.com", true, false, null, "MUHAMMADTALHA@GMAIL.COM", "MUHAMMADTALHA@GMAIL.COM", "AQAAAAIAAYagAAAAEAYTCXU4JnRx0PD9bpDxMmubfGepg9+35BppXS9vAXKazJAhVBEd76bbSx5V0hc8hQ==", null, false, "Admin", "2babcf4c-b315-43b4-aed3-dc937be4017e", false, "Muhammadtalha@gmail.com", "03457689432", "Muhammad", "Male", "Talha" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7da58f98-178a-4bb0-b8fe-f4518ad64d21");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7da58f98-178a-4bb0-b8fe-f4518ad64d21", 0, "df00cfe7-73a6-4675-a3cf-42c804bd6bb9", "IdentityUser", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEAX+iyfiMgvLMavqdTsYUc/QdsHzTQr3oh1S1Wz/SEg9bmd+zSLZL25zdWJ9Nyxtcw==", null, false, "5a4dec39-5284-4da3-ad3c-f29719ffe664", false, "admin@gmail.com" });
        }
    }
}
