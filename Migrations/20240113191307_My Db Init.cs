using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace imc_web_api.Migrations
{
    /// <inheritdoc />
    public partial class MyDbInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceProviderTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProviderName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProviderTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceProvidertypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    User_QualificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_ServiceProviderTypes_ServiceProvidertypeId",
                        column: x => x.ServiceProvidertypeId,
                        principalTable: "ServiceProviderTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    charges = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvailableQuantity = table.Column<int>(type: "int", nullable: false),
                    TotalQuantity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedByProviderTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_ServiceProviderTypes_CreatedByProviderTypeId",
                        column: x => x.CreatedByProviderTypeId,
                        principalTable: "ServiceProviderTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Promotion_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSent = table.Column<bool>(type: "bit", nullable: false),
                    PromoteToId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PromoteById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Promotions_AspNetUsers_PromoteById",
                        column: x => x.PromoteById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Promotions_AspNetUsers_PromoteToId",
                        column: x => x.PromoteToId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User_Qualifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    qualification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    experience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Qualifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Qualifications_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ratedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ratedToId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_AspNetUsers_ratedById",
                        column: x => x.ratedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Services_ratedToId",
                        column: x => x.ratedToId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4b196d21-2570-4f78-a3ca-437278080b20", "4b196d21-2570-4f78-a3ca-437278080b20", "Admin", "ADMIN" },
                    { "935cf5ee-6757-45f6-a735-2e0ecf92f6e5", "935cf5ee-6757-45f6-a735-2e0ecf92f6e5", "Customer", "CUSTOMER" },
                    { "b7c606ec-1085-4ca0-b9a4-3d963957c392", "b7c606ec-1085-4ca0-b9a4-3d963957c392", "ServiceProvider", "SERVICEPROVIDER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "ServiceProvidertypeId", "TwoFactorEnabled", "UserName", "User_QualificationId" },
                values: new object[] { "57980521-09c9-483a-bfcc-0aaeafe5f63a", 0, "95b84f6d-e59f-42ef-9d99-a8e7cc7439b6", "user", "Aamir@gmail.com", true, "Aamir", "Male", "nawaz", false, null, "Aamir@gmail.com", "Aamir@gmail.com", "AQAAAAIAAYagAAAAEKUi1/UU2mcBV0OSrka7T1HnZryaM4JX9J/fDUELRLLk4UFGGznFdgtfSjqi8JT9VQ==", "03457689432", false, "Admin", "e57fe692-7570-4791-852c-ee081a9c204a", null, false, "Aamir@gmail.com", null });

            migrationBuilder.InsertData(
                table: "ServiceProviderTypes",
                columns: new[] { "Id", "ProviderName" },
                values: new object[,]
                {
                    { new Guid("544575d6-01a8-47f8-9f2a-2dbbdac755b4"), "Doctor" },
                    { new Guid("5cb9ec27-cb26-4d27-88c5-e4a8493826d8"), "Pharmacy" },
                    { new Guid("b02151fd-3d89-40ef-816c-09318b60945c"), "Ambulance" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4b196d21-2570-4f78-a3ca-437278080b20", "57980521-09c9-483a-bfcc-0aaeafe5f63a" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "ServiceProvidertypeId", "TwoFactorEnabled", "UserName", "User_QualificationId" },
                values: new object[,]
                {
                    { "57b16338-5ff0-43f8-af6c-4d46a33933d6", 0, "a459d307-d78d-4b48-9b4b-9c39be96958b", "user", "Aqib@gmail.com", true, "Aqib", "Male", "nawaz", false, null, "Aqib@gmail.com", "Aqib@gmail.com", "AQAAAAIAAYagAAAAEJ6KisMtGlYGN51I1FrAwfFh6MEjxjCv+9mawMBi0akxDHITPfGcab49v8ra4yhbmg==", "03457689432", false, "Provider", "06428f35-f976-460d-889f-82720a8da165", new Guid("544575d6-01a8-47f8-9f2a-2dbbdac755b4"), false, "Aqib@gmail.com", new Guid("422a655e-087d-4a51-a34d-49b73d47de97") },
                    { "853d3181-f653-408a-a805-3f6b37746724", 0, "6ca71724-5112-49da-98e5-8f75556e1a24", "user", "Waheed@gmail.com", true, "Waheed", "Male", "Quraishi", false, null, "Waheed@gmail.com", "Waheed@gmail.com", "AQAAAAIAAYagAAAAEADklk/FCaVkHR4sp1Ig2Zbu0oW1fS+M/mDX2WlTZOn24Ha08SnBcHFAhY/JlNglHQ==", "03457689432", false, "Provider", "794aaa6f-e433-46ac-8c56-e8d2e4347529", new Guid("5cb9ec27-cb26-4d27-88c5-e4a8493826d8"), false, "Waheed@gmail.com", new Guid("c0936c63-424e-4c0f-b95a-e26044494508") },
                    { "bdfcf38f-2d8c-4918-a470-b2ef271711ed", 0, "bc2a160a-657e-427a-a83c-fcde105cde3f", "user", "Hameed@gmail.com", true, "Hameed", "Male", "Khan", false, null, "Hameed@gmail.com", "Hameed@gmail.com", "AQAAAAIAAYagAAAAEFeOAVDpSi1RqEI1bAoy+OyaRp4vZ3wfGHJZvcR02dyDfQ/tUDRCFAspH55xeiwhTA==", "03457689432", false, "Provider", "9a3fc5d1-7a6a-472a-8015-4e77e759493b", new Guid("b02151fd-3d89-40ef-816c-09318b60945c"), false, "Hameed@gmail.com", new Guid("b2222928-b916-42d5-957d-e59cd092a70f") }
                });

            migrationBuilder.InsertData(
                table: "User_Qualifications",
                columns: new[] { "Id", "experience", "qualification", "userId" },
                values: new object[,]
                {
                    { new Guid("422a655e-087d-4a51-a34d-49b73d47de97"), "10 YEAR", "MBBS", "57b16338-5ff0-43f8-af6c-4d46a33933d6" },
                    { new Guid("b2222928-b916-42d5-957d-e59cd092a70f"), "1 YEAR", "BDS", "bdfcf38f-2d8c-4918-a470-b2ef271711ed" },
                    { new Guid("c0936c63-424e-4c0f-b95a-e26044494508"), "3 YEAR", "MD", "853d3181-f653-408a-a805-3f6b37746724" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ServiceProvidertypeId",
                table: "AspNetUsers",
                column: "ServiceProvidertypeId",
                unique: true,
                filter: "[ServiceProvidertypeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_ratedById",
                table: "Feedbacks",
                column: "ratedById");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_ratedToId",
                table: "Feedbacks",
                column: "ratedToId");

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_PromoteById",
                table: "Promotions",
                column: "PromoteById");

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_PromoteToId",
                table: "Promotions",
                column: "PromoteToId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_CreatedByProviderTypeId",
                table: "Services",
                column: "CreatedByProviderTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Qualifications_userId",
                table: "User_Qualifications",
                column: "userId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "User_Qualifications");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ServiceProviderTypes");
        }
    }
}
