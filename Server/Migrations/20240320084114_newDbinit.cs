using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace imc_web_api.Migrations
{
    /// <inheritdoc />
    public partial class newDbinit : Migration
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
                        onDelete: ReferentialAction.Restrict);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Services_ServiceProviderTypes_CreatedByProviderTypeId",
                        column: x => x.CreatedByProviderTypeId,
                        principalTable: "ServiceProviderTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Services_ratedToId",
                        column: x => x.ratedToId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "496fb663-fe9a-4d30-8313-e069cde01d45", "496fb663-fe9a-4d30-8313-e069cde01d45", "Customer", "CUSTOMER" },
                    { "7840fe37-c2ab-4cf1-8bb0-7b5e74b9544d", "7840fe37-c2ab-4cf1-8bb0-7b5e74b9544d", "ServiceProvider", "SERVICEPROVIDER" },
                    { "b3d19da3-df98-4cbd-b6f1-ecc6bf2f919a", "b3d19da3-df98-4cbd-b6f1-ecc6bf2f919a", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Discriminator", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "ServiceProvidertypeId", "TwoFactorEnabled", "UserName", "User_QualificationId" },
                values: new object[] { "e4c41a9f-fafd-4e30-b5fe-0e89c260e1fa", 0, "e0d0b828-dfc4-4c44-906c-7d2a66c7eeba", new DateTime(2024, 3, 20, 8, 41, 14, 75, DateTimeKind.Utc).AddTicks(4393), "user", "Aamir@gmail.com", true, "Aamir", "Male", "nawaz", false, null, "Aamir@gmail.com", "Aamir@gmail.com", "AQAAAAIAAYagAAAAEBn2KCwgjfiruSvFXNWLNOg44tOs5JFCLF62NxVBvwQbzcTg+DkjmMeNCGOxmGuUwg==", "03457689432", false, "Admin", "9cd0bc72-46c3-46b3-8f50-cb51ee7f25f0", null, false, "Aamir@gmail.com", null });

            migrationBuilder.InsertData(
                table: "ServiceProviderTypes",
                columns: new[] { "Id", "CreatedAt", "ProviderName" },
                values: new object[,]
                {
                    { new Guid("5ad72a06-12a0-40ab-bfa2-1deeb471299b"), new DateTime(2024, 3, 20, 8, 41, 14, 170, DateTimeKind.Utc).AddTicks(8581), "Doctor" },
                    { new Guid("892a8494-5658-40cf-9f5a-58646422e9d0"), new DateTime(2024, 3, 20, 8, 41, 14, 170, DateTimeKind.Utc).AddTicks(8611), "Pharmacy" },
                    { new Guid("c9217135-8f37-4bd8-894d-d4c29d234662"), new DateTime(2024, 3, 20, 8, 41, 14, 170, DateTimeKind.Utc).AddTicks(8613), "Ambulance" }
                });

            migrationBuilder.InsertData(
                table: "User_Qualifications",
                columns: new[] { "Id", "CreatedAt", "experience", "qualification" },
                values: new object[,]
                {
                    { new Guid("22345fd1-b814-4103-8819-0c0790b986ff"), new DateTime(2024, 3, 20, 8, 41, 14, 170, DateTimeKind.Utc).AddTicks(8706), "1 YEAR", "BDS" },
                    { new Guid("e7e0763c-9c9e-477d-853c-a582287474cf"), new DateTime(2024, 3, 20, 8, 41, 14, 170, DateTimeKind.Utc).AddTicks(8700), "10 YEAR", "MBBS" },
                    { new Guid("f18d1096-1c80-4580-a8ab-391d03b431f8"), new DateTime(2024, 3, 20, 8, 41, 14, 170, DateTimeKind.Utc).AddTicks(8704), "3 YEAR", "MD" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b3d19da3-df98-4cbd-b6f1-ecc6bf2f919a", "e4c41a9f-fafd-4e30-b5fe-0e89c260e1fa" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Discriminator", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "ServiceProvidertypeId", "TwoFactorEnabled", "UserName", "User_QualificationId" },
                values: new object[,]
                {
                    { "3ffabea9-cc89-483d-9a45-fcc2fc13caf3", 0, "cd21ef9c-ab39-4739-99c3-23b1875f3c94", new DateTime(2024, 3, 20, 8, 41, 14, 170, DateTimeKind.Utc).AddTicks(8711), "user", "Aqib@gmail.com", true, "Aqib", "Male", "nawaz", false, null, "Aqib@gmail.com", "Aqib@gmail.com", "AQAAAAIAAYagAAAAEC0ECrKBa0ueKB5FQn3w7oies+yk2PWb+ibr9enCQvqoADb6K7BnuqI9DdUoIylreA==", "03457689432", false, "Provider", "cbea073a-55ce-4bfb-874e-beab34b9c704", new Guid("5ad72a06-12a0-40ab-bfa2-1deeb471299b"), false, "Aqib@gmail.com", new Guid("e7e0763c-9c9e-477d-853c-a582287474cf") },
                    { "512a85bd-fb8f-4055-bae6-e7064c6d61bd", 0, "b6ba54cb-c68c-422f-babf-cbd4fa582d16", new DateTime(2024, 3, 20, 8, 41, 14, 170, DateTimeKind.Utc).AddTicks(8775), "user", "Hameed@gmail.com", true, "Hameed", "Male", "Khan", false, null, "Hameed@gmail.com", "Hameed@gmail.com", "AQAAAAIAAYagAAAAEPZLBCU65X38/fvRe/Ma3TN/KYqnYsTE5cyv4itcRIyZpCP7KN+9XbV0xYZLgDLzfA==", "03457689432", false, "Provider", "7189ad24-7d88-42d4-b71f-8e6734bb7bfb", new Guid("c9217135-8f37-4bd8-894d-d4c29d234662"), false, "Hameed@gmail.com", new Guid("22345fd1-b814-4103-8819-0c0790b986ff") },
                    { "de56caed-38ff-4336-ad0b-79a3c87246ad", 0, "bf8565ec-8617-41a0-9e98-be02e3df5e43", new DateTime(2024, 3, 20, 8, 41, 14, 170, DateTimeKind.Utc).AddTicks(8761), "user", "Waheed@gmail.com", true, "Waheed", "Male", "Quraishi", false, null, "Waheed@gmail.com", "Waheed@gmail.com", "AQAAAAIAAYagAAAAEJ7DYnSw0pWFDSazanefGbAf20seVCzcjBm2H7516tZh2criQAXpV2ow40eqjiY9WA==", "03457689432", false, "Provider", "66c8fd40-76ec-4991-a558-dacd3abf1cb4", new Guid("892a8494-5658-40cf-9f5a-58646422e9d0"), false, "Waheed@gmail.com", new Guid("f18d1096-1c80-4580-a8ab-391d03b431f8") }
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
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ServiceId",
                table: "OrderItems",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderByUserId",
                table: "Orders",
                column: "OrderByUserId");

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
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

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
