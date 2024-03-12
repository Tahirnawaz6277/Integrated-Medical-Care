using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace imc_web_api.Migrations
{
    /// <inheritdoc />
    public partial class Dbinit : Migration
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
                    ProviderName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProviderTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User_Qualifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    qualification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    experience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Qualifications", x => x.Id);
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
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceProvidertypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    User_QualificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_User_Qualifications_User_QualificationId",
                        column: x => x.User_QualificationId,
                        principalTable: "User_Qualifications",
                        principalColumn: "Id");
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
                    Promotion_Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Promotions_AspNetUsers_PromoteToId",
                        column: x => x.PromoteToId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    charges = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvailableQuantity = table.Column<int>(type: "int", nullable: false),
                    TotalQuantity = table.Column<int>(type: "int", nullable: false),
                    CreatedByProviderTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedByAdminId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_AspNetUsers_CreatedByAdminId",
                        column: x => x.CreatedByAdminId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Services_ServiceProviderTypes_CreatedByProviderTypeId",
                        column: x => x.CreatedByProviderTypeId,
                        principalTable: "ServiceProviderTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Services_ratedToId",
                        column: x => x.ratedToId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OrderQuantity = table.Column<int>(type: "int", nullable: false),
                    orderStatus = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    PaymentMode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    OrderByUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_OrderByUserId",
                        column: x => x.OrderByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "293d7f68-7acb-4352-b074-a84f7b51c3f9", "293d7f68-7acb-4352-b074-a84f7b51c3f9", "ServiceProvider", "SERVICEPROVIDER" },
                    { "2fe4e3c8-994e-45d7-9468-bc39600f7ecf", "2fe4e3c8-994e-45d7-9468-bc39600f7ecf", "Customer", "CUSTOMER" },
                    { "835995a4-6c27-4873-ac9f-7b4797d98b83", "835995a4-6c27-4873-ac9f-7b4797d98b83", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Discriminator", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "ServiceProvidertypeId", "TwoFactorEnabled", "UserName", "User_QualificationId" },
                values: new object[] { "5ba0a552-64cd-42fb-a400-518a83f0b4cc", 0, "1add2bff-4fcb-4ff7-81cf-5ceb62aba9f2", new DateTime(2024, 2, 29, 15, 48, 18, 350, DateTimeKind.Utc).AddTicks(531), "user", "Aamir@gmail.com", true, "Aamir", "Male", "nawaz", false, null, "Aamir@gmail.com", "Aamir@gmail.com", "AQAAAAIAAYagAAAAEEGetrmVux23L0QSMSY+3HltVCYRyigeC/94xvIGUtkxOyWdIPcwKPQQYTyOa5i9Og==", "03457689432", false, "Admin", "2dfd8504-4de8-4b47-855c-5d9065fc06fa", null, false, "Aamir@gmail.com", null });

            migrationBuilder.InsertData(
                table: "ServiceProviderTypes",
                columns: new[] { "Id", "CreatedAt", "ProviderName" },
                values: new object[,]
                {
                    { new Guid("ab406967-e418-497e-a96a-a1be73eb3bb6"), new DateTime(2024, 2, 29, 15, 48, 18, 449, DateTimeKind.Utc).AddTicks(1401), "Doctor" },
                    { new Guid("b1063572-699c-4199-b8d8-188aa58cb4b1"), new DateTime(2024, 2, 29, 15, 48, 18, 449, DateTimeKind.Utc).AddTicks(1427), "Ambulance" },
                    { new Guid("d40d2da1-1e97-4e91-876d-48414a261b91"), new DateTime(2024, 2, 29, 15, 48, 18, 449, DateTimeKind.Utc).AddTicks(1424), "Pharmacy" }
                });

            migrationBuilder.InsertData(
                table: "User_Qualifications",
                columns: new[] { "Id", "CreatedAt", "experience", "qualification" },
                values: new object[,]
                {
                    { new Guid("7a3f6d35-db2f-487f-8fb6-34780533fdcf"), new DateTime(2024, 2, 29, 15, 48, 18, 449, DateTimeKind.Utc).AddTicks(1534), "1 YEAR", "BDS" },
                    { new Guid("9478e57f-1be4-45e8-a59c-e9a74dbe3535"), new DateTime(2024, 2, 29, 15, 48, 18, 449, DateTimeKind.Utc).AddTicks(1512), "10 YEAR", "MBBS" },
                    { new Guid("d7a2220a-a856-45a3-8eaa-a779081e55ce"), new DateTime(2024, 2, 29, 15, 48, 18, 449, DateTimeKind.Utc).AddTicks(1532), "3 YEAR", "MD" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "835995a4-6c27-4873-ac9f-7b4797d98b83", "5ba0a552-64cd-42fb-a400-518a83f0b4cc" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Discriminator", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "ServiceProvidertypeId", "TwoFactorEnabled", "UserName", "User_QualificationId" },
                values: new object[,]
                {
                    { "17b1b583-6736-4aaf-93bf-5a3eb9e5309b", 0, "3f670981-c337-4233-9e7e-10025a091f0a", new DateTime(2024, 2, 29, 15, 48, 18, 449, DateTimeKind.Utc).AddTicks(1579), "user", "Waheed@gmail.com", true, "Waheed", "Male", "Quraishi", false, null, "Waheed@gmail.com", "Waheed@gmail.com", "AQAAAAIAAYagAAAAEOX6QQrOnVB2xVIgFnJjMgPAB+KB2jkEtqVf4ijBhs1QbCatbwLpAck0siW4Wah5xw==", "03457689432", false, "Provider", "1da8db25-0cae-4c1e-a3bf-de784c0257a7", new Guid("d40d2da1-1e97-4e91-876d-48414a261b91"), false, "Waheed@gmail.com", new Guid("d7a2220a-a856-45a3-8eaa-a779081e55ce") },
                    { "6316d5d4-6903-4e06-b33c-e21bed93aa99", 0, "78bd7c2a-bd1f-46d2-8c80-4e9529fc0e9c", new DateTime(2024, 2, 29, 15, 48, 18, 449, DateTimeKind.Utc).AddTicks(1540), "user", "Aqib@gmail.com", true, "Aqib", "Male", "nawaz", false, null, "Aqib@gmail.com", "Aqib@gmail.com", "AQAAAAIAAYagAAAAECQIV6lgNMGRsppHhixGARIkWV5KgzgYVJY5+7fKhStIivqFqUa5vzbKRU1zHBHApg==", "03457689432", false, "Provider", "7476d776-3991-4c64-b39d-ab444ecc63e2", new Guid("ab406967-e418-497e-a96a-a1be73eb3bb6"), false, "Aqib@gmail.com", new Guid("9478e57f-1be4-45e8-a59c-e9a74dbe3535") },
                    { "6332caaa-fec4-4d32-884b-cb99443f6bf4", 0, "5a81dbcd-1fc8-411a-bff7-992c053208d9", new DateTime(2024, 2, 29, 15, 48, 18, 449, DateTimeKind.Utc).AddTicks(1598), "user", "Hameed@gmail.com", true, "Hameed", "Male", "Khan", false, null, "Hameed@gmail.com", "Hameed@gmail.com", "AQAAAAIAAYagAAAAEEAcNEjODcfGlmITyxYp6yMpTuDKQV0Awcxk2wbWv1GuYzheLg6ZqOiJqdouQP4u0A==", "03457689432", false, "Provider", "59a2f009-65a7-4bd7-b015-19a668f030bc", new Guid("b1063572-699c-4199-b8d8-188aa58cb4b1"), false, "Hameed@gmail.com", new Guid("7a3f6d35-db2f-487f-8fb6-34780533fdcf") }
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
                name: "IX_AspNetUsers_User_QualificationId",
                table: "AspNetUsers",
                column: "User_QualificationId",
                unique: true,
                filter: "[User_QualificationId] IS NOT NULL");

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
                name: "IX_Orders_OrderByUserId",
                table: "Orders",
                column: "OrderByUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ServiceId",
                table: "Orders",
                column: "ServiceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_PromoteById",
                table: "Promotions",
                column: "PromoteById");

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_PromoteToId",
                table: "Promotions",
                column: "PromoteToId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_CreatedByAdminId",
                table: "Services",
                column: "CreatedByAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_CreatedByProviderTypeId",
                table: "Services",
                column: "CreatedByProviderTypeId");
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
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ServiceProviderTypes");

            migrationBuilder.DropTable(
                name: "User_Qualifications");
        }
    }
}
