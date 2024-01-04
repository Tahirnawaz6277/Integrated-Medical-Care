using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMC_Integrated_Medical_Care_.Migrations
{
    /// <inheritdoc />
    public partial class SeedingForAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7da58f98-178a-4bb0-b8fe-f4518ad64d21", 0, "df00cfe7-73a6-4675-a3cf-42c804bd6bb9", "IdentityUser", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEAX+iyfiMgvLMavqdTsYUc/QdsHzTQr3oh1S1Wz/SEg9bmd+zSLZL25zdWJ9Nyxtcw==", null, false, "5a4dec39-5284-4da3-ad3c-f29719ffe664", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4e050638-06b1-4d94-9462-757e387f70a5", "7da58f98-178a-4bb0-b8fe-f4518ad64d21" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4e050638-06b1-4d94-9462-757e387f70a5", "7da58f98-178a-4bb0-b8fe-f4518ad64d21" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7da58f98-178a-4bb0-b8fe-f4518ad64d21");
        }
    }
}
