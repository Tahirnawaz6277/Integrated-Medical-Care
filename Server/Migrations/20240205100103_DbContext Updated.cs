using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace imc_web_api.Migrations
{
    /// <inheritdoc />
    public partial class DbContextUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agreements_AspNetUsers_AdminId",
                table: "Agreements");

            migrationBuilder.DropForeignKey(
                name: "FK_Agreements_AspNetUsers_ServiceProviderId",
                table: "Agreements");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ServiceProviderTypes_ServiceProvidertypeId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_AspNetUsers_ratedById",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Services_ratedToId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_CustomerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Services_ServiceId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_AspNetUsers_PromoteById",
                table: "Promotions");

            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_AspNetUsers_PromoteToId",
                table: "Promotions");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServiceProviderTypes_CreatedByProviderTypeId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Qualifications_AspNetUsers_userId",
                table: "User_Qualifications");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e54eb14-fe80-40ae-9c85-806035beabe6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce6d2666-d634-48c8-ab84-a7ab88313213");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d4cca61b-a1ab-49e8-bf55-f19be009697f", "21f75896-153d-44db-897e-7942742d0e8e" });

            migrationBuilder.DeleteData(
                table: "User_Qualifications",
                keyColumn: "Id",
                keyValue: new Guid("46914eca-ef85-4d4a-91b6-3ad70ae5a0ae"));

            migrationBuilder.DeleteData(
                table: "User_Qualifications",
                keyColumn: "Id",
                keyValue: new Guid("960b17a1-a040-425b-ab5d-f6c4d52a043b"));

            migrationBuilder.DeleteData(
                table: "User_Qualifications",
                keyColumn: "Id",
                keyValue: new Guid("b9735fbb-2ce5-47a4-8a44-8e40346c02ad"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4cca61b-a1ab-49e8-bf55-f19be009697f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0f33548a-eaeb-4ccb-b69a-2d89a9bb74b0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0f599847-3f94-4cf7-81df-3ce2f2948974");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21f75896-153d-44db-897e-7942742d0e8e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a027457-9c2b-403e-973e-1bad582b0911");

            migrationBuilder.DeleteData(
                table: "ServiceProviderTypes",
                keyColumn: "Id",
                keyValue: new Guid("01683d6f-db82-443c-87d9-171d90aa1d03"));

            migrationBuilder.DeleteData(
                table: "ServiceProviderTypes",
                keyColumn: "Id",
                keyValue: new Guid("4586e3e7-7b16-4a9d-8e59-71639b28c2ca"));

            migrationBuilder.DeleteData(
                table: "ServiceProviderTypes",
                keyColumn: "Id",
                keyValue: new Guid("755049c3-a854-4768-98ba-cd5cf704ad51"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3162cc10-d8a4-4cfd-818b-812db103c2bc", "3162cc10-d8a4-4cfd-818b-812db103c2bc", "ServiceProvider", "SERVICEPROVIDER" },
                    { "45b62499-a86f-49d5-833f-1b6162add9c5", "45b62499-a86f-49d5-833f-1b6162add9c5", "Admin", "ADMIN" },
                    { "8dfdbe62-0bf0-4e0c-addd-231719170e18", "8dfdbe62-0bf0-4e0c-addd-231719170e18", "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Discriminator", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "ServiceProvidertypeId", "TwoFactorEnabled", "UserName", "User_QualificationId" },
                values: new object[] { "2bba3594-1cff-4921-bb17-4d93a99cf3b0", 0, "58ab816f-8bfb-4e6a-b841-cdac31c9fa54", new DateTime(2024, 2, 5, 10, 1, 2, 597, DateTimeKind.Utc).AddTicks(7756), "user", "Aamir@gmail.com", true, "Aamir", "Male", "nawaz", false, null, "Aamir@gmail.com", "Aamir@gmail.com", "AQAAAAIAAYagAAAAEHOM7268Cxnd7LWxJ4XSGWxXC/U4h77lMDs6jdLAvFgCIZvRT5piZeDkVARObnrtjA==", "03457689432", false, "Admin", "004b1069-3aeb-476f-8675-c952be8e65b6", null, false, "Aamir@gmail.com", null });

            migrationBuilder.InsertData(
                table: "ServiceProviderTypes",
                columns: new[] { "Id", "CreatedAt", "ProviderName" },
                values: new object[,]
                {
                    { new Guid("1e348ffc-054e-4762-ba21-3759e9563ce0"), new DateTime(2024, 2, 5, 10, 1, 2, 703, DateTimeKind.Utc).AddTicks(4665), "Ambulance" },
                    { new Guid("4f892b69-9cba-44e1-890c-103bdb0fa312"), new DateTime(2024, 2, 5, 10, 1, 2, 703, DateTimeKind.Utc).AddTicks(4662), "Pharmacy" },
                    { new Guid("87cae432-0c12-4289-85c9-293cada15ef5"), new DateTime(2024, 2, 5, 10, 1, 2, 703, DateTimeKind.Utc).AddTicks(4630), "Doctor" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "45b62499-a86f-49d5-833f-1b6162add9c5", "2bba3594-1cff-4921-bb17-4d93a99cf3b0" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Discriminator", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "ServiceProvidertypeId", "TwoFactorEnabled", "UserName", "User_QualificationId" },
                values: new object[,]
                {
                    { "2b62502a-886d-4a94-abf3-bdca1043e1f9", 0, "3b76e2e0-e7b9-4ed4-bab2-5b889ea4bb3b", new DateTime(2024, 2, 5, 10, 1, 2, 703, DateTimeKind.Utc).AddTicks(4865), "user", "Aqib@gmail.com", true, "Aqib", "Male", "nawaz", false, null, "Aqib@gmail.com", "Aqib@gmail.com", "AQAAAAIAAYagAAAAEPVns+3n6t9CS+uF9V/AsKla+O48Y5f/yDug1uRDuLKKNkBW7UR1WvJ3RmKw30m/Ig==", "03457689432", false, "Provider", "9cfc71b3-2cdc-4238-ab75-9946ca19e9a7", new Guid("87cae432-0c12-4289-85c9-293cada15ef5"), false, "Aqib@gmail.com", new Guid("55469cc6-a481-412e-ac91-cde2728d26a5") },
                    { "3684bd4d-613e-447f-89ac-e92d0582a428", 0, "8b90b668-a621-42d3-b11a-c81051c245b6", new DateTime(2024, 2, 5, 10, 1, 2, 703, DateTimeKind.Utc).AddTicks(4910), "user", "Waheed@gmail.com", true, "Waheed", "Male", "Quraishi", false, null, "Waheed@gmail.com", "Waheed@gmail.com", "AQAAAAIAAYagAAAAEKCoONOcQCZc/vucAj9+LcUjy0PG2P3d7duLqGtW2DKDfcCIEiR2/9L+Oc4LEeQyRg==", "03457689432", false, "Provider", "45666fc6-a5ca-4428-b0ea-62971be36008", new Guid("4f892b69-9cba-44e1-890c-103bdb0fa312"), false, "Waheed@gmail.com", new Guid("2887c668-4628-44b3-b0e0-72904333a0b7") },
                    { "65278e46-68d1-4e0f-9631-2a8cbfd1bbae", 0, "2f827d2c-27f4-482a-98ef-6c255196bf5a", new DateTime(2024, 2, 5, 10, 1, 2, 703, DateTimeKind.Utc).AddTicks(4931), "user", "Hameed@gmail.com", true, "Hameed", "Male", "Khan", false, null, "Hameed@gmail.com", "Hameed@gmail.com", "AQAAAAIAAYagAAAAEEkH/ftuV+HpZ4L09ZzDU4sHlSU7etRPQi36XkUngVG220Eumg4CTiNxi+hPUBI08Q==", "03457689432", false, "Provider", "9d0aaf44-0d28-40c6-9030-bd2de3776f1a", new Guid("1e348ffc-054e-4762-ba21-3759e9563ce0"), false, "Hameed@gmail.com", new Guid("e8e0fd87-b813-44c3-a468-21438418b580") }
                });

            migrationBuilder.InsertData(
                table: "User_Qualifications",
                columns: new[] { "Id", "CreatedAt", "experience", "qualification", "userId" },
                values: new object[,]
                {
                    { new Guid("2887c668-4628-44b3-b0e0-72904333a0b7"), new DateTime(2024, 2, 5, 10, 1, 2, 703, DateTimeKind.Utc).AddTicks(4749), "3 YEAR", "MD", "3684bd4d-613e-447f-89ac-e92d0582a428" },
                    { new Guid("55469cc6-a481-412e-ac91-cde2728d26a5"), new DateTime(2024, 2, 5, 10, 1, 2, 703, DateTimeKind.Utc).AddTicks(4726), "10 YEAR", "MBBS", "2b62502a-886d-4a94-abf3-bdca1043e1f9" },
                    { new Guid("e8e0fd87-b813-44c3-a468-21438418b580"), new DateTime(2024, 2, 5, 10, 1, 2, 703, DateTimeKind.Utc).AddTicks(4752), "1 YEAR", "BDS", "65278e46-68d1-4e0f-9631-2a8cbfd1bbae" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Agreements_AspNetUsers_AdminId",
                table: "Agreements",
                column: "AdminId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Agreements_AspNetUsers_ServiceProviderId",
                table: "Agreements",
                column: "ServiceProviderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ServiceProviderTypes_ServiceProvidertypeId",
                table: "AspNetUsers",
                column: "ServiceProvidertypeId",
                principalTable: "ServiceProviderTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_AspNetUsers_ratedById",
                table: "Feedbacks",
                column: "ratedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Services_ratedToId",
                table: "Feedbacks",
                column: "ratedToId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Services_ServiceId",
                table: "Orders",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_AspNetUsers_PromoteById",
                table: "Promotions",
                column: "PromoteById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_AspNetUsers_PromoteToId",
                table: "Promotions",
                column: "PromoteToId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ServiceProviderTypes_CreatedByProviderTypeId",
                table: "Services",
                column: "CreatedByProviderTypeId",
                principalTable: "ServiceProviderTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Qualifications_AspNetUsers_userId",
                table: "User_Qualifications",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agreements_AspNetUsers_AdminId",
                table: "Agreements");

            migrationBuilder.DropForeignKey(
                name: "FK_Agreements_AspNetUsers_ServiceProviderId",
                table: "Agreements");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ServiceProviderTypes_ServiceProvidertypeId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_AspNetUsers_ratedById",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Services_ratedToId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_CustomerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Services_ServiceId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_AspNetUsers_PromoteById",
                table: "Promotions");

            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_AspNetUsers_PromoteToId",
                table: "Promotions");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServiceProviderTypes_CreatedByProviderTypeId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Qualifications_AspNetUsers_userId",
                table: "User_Qualifications");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3162cc10-d8a4-4cfd-818b-812db103c2bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8dfdbe62-0bf0-4e0c-addd-231719170e18");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "45b62499-a86f-49d5-833f-1b6162add9c5", "2bba3594-1cff-4921-bb17-4d93a99cf3b0" });

            migrationBuilder.DeleteData(
                table: "User_Qualifications",
                keyColumn: "Id",
                keyValue: new Guid("2887c668-4628-44b3-b0e0-72904333a0b7"));

            migrationBuilder.DeleteData(
                table: "User_Qualifications",
                keyColumn: "Id",
                keyValue: new Guid("55469cc6-a481-412e-ac91-cde2728d26a5"));

            migrationBuilder.DeleteData(
                table: "User_Qualifications",
                keyColumn: "Id",
                keyValue: new Guid("e8e0fd87-b813-44c3-a468-21438418b580"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45b62499-a86f-49d5-833f-1b6162add9c5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b62502a-886d-4a94-abf3-bdca1043e1f9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2bba3594-1cff-4921-bb17-4d93a99cf3b0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3684bd4d-613e-447f-89ac-e92d0582a428");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "65278e46-68d1-4e0f-9631-2a8cbfd1bbae");

            migrationBuilder.DeleteData(
                table: "ServiceProviderTypes",
                keyColumn: "Id",
                keyValue: new Guid("1e348ffc-054e-4762-ba21-3759e9563ce0"));

            migrationBuilder.DeleteData(
                table: "ServiceProviderTypes",
                keyColumn: "Id",
                keyValue: new Guid("4f892b69-9cba-44e1-890c-103bdb0fa312"));

            migrationBuilder.DeleteData(
                table: "ServiceProviderTypes",
                keyColumn: "Id",
                keyValue: new Guid("87cae432-0c12-4289-85c9-293cada15ef5"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4e54eb14-fe80-40ae-9c85-806035beabe6", "4e54eb14-fe80-40ae-9c85-806035beabe6", "ServiceProvider", "SERVICEPROVIDER" },
                    { "ce6d2666-d634-48c8-ab84-a7ab88313213", "ce6d2666-d634-48c8-ab84-a7ab88313213", "Customer", "CUSTOMER" },
                    { "d4cca61b-a1ab-49e8-bf55-f19be009697f", "d4cca61b-a1ab-49e8-bf55-f19be009697f", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Discriminator", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "ServiceProvidertypeId", "TwoFactorEnabled", "UserName", "User_QualificationId" },
                values: new object[] { "21f75896-153d-44db-897e-7942742d0e8e", 0, "3c674ae9-51ed-4659-a843-09281fd80a2f", new DateTime(2024, 1, 27, 14, 11, 1, 836, DateTimeKind.Utc).AddTicks(1471), "user", "Aamir@gmail.com", true, "Aamir", "Male", "nawaz", false, null, "Aamir@gmail.com", "Aamir@gmail.com", "AQAAAAIAAYagAAAAEKgw0qs6iVLTcr5mHfuUD9/Ly2DZfp2i82yyY9y7j3kTHhfX+kjOi25lMDaL4KTNWA==", "03457689432", false, "Admin", "8639b364-369f-4535-8bbc-fb0ba4b7bfa4", null, false, "Aamir@gmail.com", null });

            migrationBuilder.InsertData(
                table: "ServiceProviderTypes",
                columns: new[] { "Id", "CreatedAt", "ProviderName" },
                values: new object[,]
                {
                    { new Guid("01683d6f-db82-443c-87d9-171d90aa1d03"), new DateTime(2024, 1, 27, 14, 11, 1, 956, DateTimeKind.Utc).AddTicks(9863), "Doctor" },
                    { new Guid("4586e3e7-7b16-4a9d-8e59-71639b28c2ca"), new DateTime(2024, 1, 27, 14, 11, 1, 956, DateTimeKind.Utc).AddTicks(9887), "Pharmacy" },
                    { new Guid("755049c3-a854-4768-98ba-cd5cf704ad51"), new DateTime(2024, 1, 27, 14, 11, 1, 956, DateTimeKind.Utc).AddTicks(9889), "Ambulance" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d4cca61b-a1ab-49e8-bf55-f19be009697f", "21f75896-153d-44db-897e-7942742d0e8e" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Discriminator", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "ServiceProvidertypeId", "TwoFactorEnabled", "UserName", "User_QualificationId" },
                values: new object[,]
                {
                    { "0f33548a-eaeb-4ccb-b69a-2d89a9bb74b0", 0, "62eaf432-ecee-4955-9063-c22305213e36", new DateTime(2024, 1, 27, 14, 11, 1, 957, DateTimeKind.Utc).AddTicks(28), "user", "Aqib@gmail.com", true, "Aqib", "Male", "nawaz", false, null, "Aqib@gmail.com", "Aqib@gmail.com", "AQAAAAIAAYagAAAAELUvHx5QWP0F7huQU1VzXXkD3WukH9VoEclMZXyt3Zxp+g1/duY0at1gmvN1TX45gA==", "03457689432", false, "Provider", "8f66d638-826d-47d6-a855-b7ccb993c960", new Guid("01683d6f-db82-443c-87d9-171d90aa1d03"), false, "Aqib@gmail.com", new Guid("960b17a1-a040-425b-ab5d-f6c4d52a043b") },
                    { "0f599847-3f94-4cf7-81df-3ce2f2948974", 0, "06bbd020-ddce-4ab0-952e-b96dea46287a", new DateTime(2024, 1, 27, 14, 11, 1, 957, DateTimeKind.Utc).AddTicks(94), "user", "Hameed@gmail.com", true, "Hameed", "Male", "Khan", false, null, "Hameed@gmail.com", "Hameed@gmail.com", "AQAAAAIAAYagAAAAEOIInCqy8zQV/QU0S+0HPjY7XFvafx/LzJS1y0yHzE4K94+lmaW2MJvxxlMkypKzJw==", "03457689432", false, "Provider", "a1ed9489-09e6-4585-86c8-bb6b2ecf84dc", new Guid("755049c3-a854-4768-98ba-cd5cf704ad51"), false, "Hameed@gmail.com", new Guid("b9735fbb-2ce5-47a4-8a44-8e40346c02ad") },
                    { "8a027457-9c2b-403e-973e-1bad582b0911", 0, "6dccd462-1e92-4ea5-8a35-d3cb178909c8", new DateTime(2024, 1, 27, 14, 11, 1, 957, DateTimeKind.Utc).AddTicks(79), "user", "Waheed@gmail.com", true, "Waheed", "Male", "Quraishi", false, null, "Waheed@gmail.com", "Waheed@gmail.com", "AQAAAAIAAYagAAAAEGyBOijerW6SUn+lYHRA5TMED232oWvzhr+zXZyhyMX7VbWB4l+MNQI6On9HRJjN4w==", "03457689432", false, "Provider", "7f4f96e8-9f45-43ec-9bb0-23826c76c233", new Guid("4586e3e7-7b16-4a9d-8e59-71639b28c2ca"), false, "Waheed@gmail.com", new Guid("46914eca-ef85-4d4a-91b6-3ad70ae5a0ae") }
                });

            migrationBuilder.InsertData(
                table: "User_Qualifications",
                columns: new[] { "Id", "CreatedAt", "experience", "qualification", "userId" },
                values: new object[,]
                {
                    { new Guid("46914eca-ef85-4d4a-91b6-3ad70ae5a0ae"), new DateTime(2024, 1, 27, 14, 11, 1, 957, DateTimeKind.Utc).AddTicks(19), "3 YEAR", "MD", "8a027457-9c2b-403e-973e-1bad582b0911" },
                    { new Guid("960b17a1-a040-425b-ab5d-f6c4d52a043b"), new DateTime(2024, 1, 27, 14, 11, 1, 957, DateTimeKind.Utc).AddTicks(13), "10 YEAR", "MBBS", "0f33548a-eaeb-4ccb-b69a-2d89a9bb74b0" },
                    { new Guid("b9735fbb-2ce5-47a4-8a44-8e40346c02ad"), new DateTime(2024, 1, 27, 14, 11, 1, 957, DateTimeKind.Utc).AddTicks(21), "1 YEAR", "BDS", "0f599847-3f94-4cf7-81df-3ce2f2948974" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Agreements_AspNetUsers_AdminId",
                table: "Agreements",
                column: "AdminId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Agreements_AspNetUsers_ServiceProviderId",
                table: "Agreements",
                column: "ServiceProviderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ServiceProviderTypes_ServiceProvidertypeId",
                table: "AspNetUsers",
                column: "ServiceProvidertypeId",
                principalTable: "ServiceProviderTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_AspNetUsers_ratedById",
                table: "Feedbacks",
                column: "ratedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Services_ratedToId",
                table: "Feedbacks",
                column: "ratedToId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Services_ServiceId",
                table: "Orders",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_AspNetUsers_PromoteById",
                table: "Promotions",
                column: "PromoteById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_AspNetUsers_PromoteToId",
                table: "Promotions",
                column: "PromoteToId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ServiceProviderTypes_CreatedByProviderTypeId",
                table: "Services",
                column: "CreatedByProviderTypeId",
                principalTable: "ServiceProviderTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Qualifications_AspNetUsers_userId",
                table: "User_Qualifications",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
