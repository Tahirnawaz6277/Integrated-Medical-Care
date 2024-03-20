using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace imc_web_api.Migrations
{
    /// <inheritdoc />
    public partial class dbinit : Migration
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
<<<<<<<< HEAD:Server/Migrations/20240319173628_dbinit.cs
                    { "08684c4a-009d-4b97-9345-b044f1421305", "08684c4a-009d-4b97-9345-b044f1421305", "Admin", "ADMIN" },
                    { "34f1b6fe-9205-4d3a-9fad-ef9e1f08c8f6", "34f1b6fe-9205-4d3a-9fad-ef9e1f08c8f6", "Customer", "CUSTOMER" },
                    { "443758c8-3cef-4549-ac43-a6c7ab75ea12", "443758c8-3cef-4549-ac43-a6c7ab75ea12", "ServiceProvider", "SERVICEPROVIDER" }
========
                    { "02134b3f-e163-4534-8075-2ce7b6d88e07", "02134b3f-e163-4534-8075-2ce7b6d88e07", "ServiceProvider", "SERVICEPROVIDER" },
                    { "06c5f26f-78ff-4c3b-ac56-1878548eb9dc", "06c5f26f-78ff-4c3b-ac56-1878548eb9dc", "Admin", "ADMIN" },
                    { "254626cd-ff08-4ca2-bfb2-0edcc2e6cd0d", "254626cd-ff08-4ca2-bfb2-0edcc2e6cd0d", "Customer", "CUSTOMER" }
>>>>>>>> 536d131c91c407d4b5858a1ce9d730e32fb26d31:Server/Migrations/20240319233404_dbinit.cs
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Discriminator", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "ServiceProvidertypeId", "TwoFactorEnabled", "UserName", "User_QualificationId" },
<<<<<<<< HEAD:Server/Migrations/20240319173628_dbinit.cs
                values: new object[] { "97c7a7f0-b938-4e8c-85d6-0dd537a7a928", 0, "642e85d4-4002-435b-ac79-64cf346091e3", new DateTime(2024, 3, 19, 17, 36, 28, 372, DateTimeKind.Utc).AddTicks(586), "user", "Aamir@gmail.com", true, "Aamir", "Male", "nawaz", false, null, "Aamir@gmail.com", "Aamir@gmail.com", "AQAAAAIAAYagAAAAEDzzvOOrnRDrtCuJhbDWWnbwB8sjo7b1FsLRONIGVfJmUnmKT2fsJ6R3zIoT9ybilg==", "03457689432", false, "Admin", "a165e530-1fa9-4267-8d4c-7dc5b6575449", null, false, "Aamir@gmail.com", null });
========
                values: new object[] { "3a8c9228-1a48-4697-a345-ac5ec888633f", 0, "daf69794-99c3-47a9-9fd9-5e01214a0760", new DateTime(2024, 3, 19, 23, 34, 3, 594, DateTimeKind.Utc).AddTicks(4122), "user", "Aamir@gmail.com", true, "Aamir", "Male", "nawaz", false, null, "Aamir@gmail.com", "Aamir@gmail.com", "AQAAAAIAAYagAAAAEITR1MfktNPFJGZ1j1JKDlo2NVYO6llElqmA1oPG5ed9HOVbdgRu9tWbZ4DVLGDx4g==", "03457689432", false, "Admin", "f9a56676-1171-4a55-b63b-b360b6bfcdef", null, false, "Aamir@gmail.com", null });
>>>>>>>> 536d131c91c407d4b5858a1ce9d730e32fb26d31:Server/Migrations/20240319233404_dbinit.cs

            migrationBuilder.InsertData(
                table: "ServiceProviderTypes",
                columns: new[] { "Id", "CreatedAt", "ProviderName" },
                values: new object[,]
                {
<<<<<<<< HEAD:Server/Migrations/20240319173628_dbinit.cs
                    { new Guid("2189bafa-44bf-4ca7-9145-c6826cfb8e61"), new DateTime(2024, 3, 19, 17, 36, 28, 467, DateTimeKind.Utc).AddTicks(9807), "Doctor" },
                    { new Guid("4141c59e-55e4-4cfb-b1b3-87b7d999ea8a"), new DateTime(2024, 3, 19, 17, 36, 28, 467, DateTimeKind.Utc).AddTicks(9834), "Ambulance" },
                    { new Guid("96ae3f57-acb7-481d-a50b-00b9a3bfc826"), new DateTime(2024, 3, 19, 17, 36, 28, 467, DateTimeKind.Utc).AddTicks(9831), "Pharmacy" }
========
                    { new Guid("5d3875f8-4aee-4d31-aee1-a204404e9fdc"), new DateTime(2024, 3, 19, 23, 34, 3, 796, DateTimeKind.Utc).AddTicks(4377), "Pharmacy" },
                    { new Guid("b326000a-dbe9-472f-9652-539b7a88a2bf"), new DateTime(2024, 3, 19, 23, 34, 3, 796, DateTimeKind.Utc).AddTicks(4381), "Ambulance" },
                    { new Guid("cee2768d-2694-4679-ad04-e9efae3fb19f"), new DateTime(2024, 3, 19, 23, 34, 3, 796, DateTimeKind.Utc).AddTicks(4336), "Doctor" }
>>>>>>>> 536d131c91c407d4b5858a1ce9d730e32fb26d31:Server/Migrations/20240319233404_dbinit.cs
                });

            migrationBuilder.InsertData(
                table: "User_Qualifications",
                columns: new[] { "Id", "CreatedAt", "experience", "qualification" },
                values: new object[,]
                {
<<<<<<<< HEAD:Server/Migrations/20240319173628_dbinit.cs
                    { new Guid("c7b464a6-9f44-41e2-bb8b-45aeffc234fe"), new DateTime(2024, 3, 19, 17, 36, 28, 467, DateTimeKind.Utc).AddTicks(9926), "3 YEAR", "MD" },
                    { new Guid("eb196c68-ecba-4271-812e-5d1529a75870"), new DateTime(2024, 3, 19, 17, 36, 28, 467, DateTimeKind.Utc).AddTicks(9929), "1 YEAR", "BDS" },
                    { new Guid("efea2067-1f63-44f5-8055-dd58e72d0235"), new DateTime(2024, 3, 19, 17, 36, 28, 467, DateTimeKind.Utc).AddTicks(9921), "10 YEAR", "MBBS" }
========
                    { new Guid("62b98ac8-b9e1-415b-98be-2a782f5e65ab"), new DateTime(2024, 3, 19, 23, 34, 3, 796, DateTimeKind.Utc).AddTicks(4488), "10 YEAR", "MBBS" },
                    { new Guid("7ba6cbab-f16f-4898-84b8-488760ebf9b6"), new DateTime(2024, 3, 19, 23, 34, 3, 796, DateTimeKind.Utc).AddTicks(4497), "1 YEAR", "BDS" },
                    { new Guid("e0248199-dda6-4af3-9661-fa3d329aff00"), new DateTime(2024, 3, 19, 23, 34, 3, 796, DateTimeKind.Utc).AddTicks(4494), "3 YEAR", "MD" }
>>>>>>>> 536d131c91c407d4b5858a1ce9d730e32fb26d31:Server/Migrations/20240319233404_dbinit.cs
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
<<<<<<<< HEAD:Server/Migrations/20240319173628_dbinit.cs
                values: new object[] { "08684c4a-009d-4b97-9345-b044f1421305", "97c7a7f0-b938-4e8c-85d6-0dd537a7a928" });
========
                values: new object[] { "06c5f26f-78ff-4c3b-ac56-1878548eb9dc", "3a8c9228-1a48-4697-a345-ac5ec888633f" });
>>>>>>>> 536d131c91c407d4b5858a1ce9d730e32fb26d31:Server/Migrations/20240319233404_dbinit.cs

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Discriminator", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "ServiceProvidertypeId", "TwoFactorEnabled", "UserName", "User_QualificationId" },
                values: new object[,]
                {
<<<<<<<< HEAD:Server/Migrations/20240319173628_dbinit.cs
                    { "1a6fb4bd-d00d-483e-84f2-b8fdd0437c1b", 0, "d85f2a05-f03e-43f2-826a-2638cfa0ff59", new DateTime(2024, 3, 19, 17, 36, 28, 467, DateTimeKind.Utc).AddTicks(9947), "user", "Aqib@gmail.com", true, "Aqib", "Male", "nawaz", false, null, "Aqib@gmail.com", "Aqib@gmail.com", "AQAAAAIAAYagAAAAEIxng9BVc1adrOAlo8UCSmnQ7NDlmq7ANofQqSlwhoFSvEbNphjwHpTLRMqsW4IPHA==", "03457689432", false, "Provider", "80f5a156-1fa6-4a53-a329-17d2653d16f9", new Guid("2189bafa-44bf-4ca7-9145-c6826cfb8e61"), false, "Aqib@gmail.com", new Guid("efea2067-1f63-44f5-8055-dd58e72d0235") },
                    { "6159715b-fa81-46f2-a688-e41129f45593", 0, "c4f2b0cd-60b5-4a07-8897-b71b1964aa3d", new DateTime(2024, 3, 19, 17, 36, 28, 468, DateTimeKind.Utc).AddTicks(67), "user", "Hameed@gmail.com", true, "Hameed", "Male", "Khan", false, null, "Hameed@gmail.com", "Hameed@gmail.com", "AQAAAAIAAYagAAAAEP7dQrOCrNKPc3qd9wkxZfQOek2Do6HLlLyNqScd9SQnaiM/7khxHFAx5GZ0qdGmXQ==", "03457689432", false, "Provider", "e2559fa0-d921-4384-92b9-dd68bc79d09b", new Guid("4141c59e-55e4-4cfb-b1b3-87b7d999ea8a"), false, "Hameed@gmail.com", new Guid("eb196c68-ecba-4271-812e-5d1529a75870") },
                    { "8cd8118b-e26a-477b-a9a5-e0a2b39d834f", 0, "79d7d59c-c03d-42b0-95b5-4c92db58ec98", new DateTime(2024, 3, 19, 17, 36, 28, 468, DateTimeKind.Utc).AddTicks(48), "user", "Waheed@gmail.com", true, "Waheed", "Male", "Quraishi", false, null, "Waheed@gmail.com", "Waheed@gmail.com", "AQAAAAIAAYagAAAAEASMkLmGe9qNtjK2l3twsSgi6eTO9ahokUKu0CggBWNaJtO9Quhtbgsup6FGhNiDvQ==", "03457689432", false, "Provider", "21deca23-40f5-4227-a69a-21b492fdb623", new Guid("96ae3f57-acb7-481d-a50b-00b9a3bfc826"), false, "Waheed@gmail.com", new Guid("c7b464a6-9f44-41e2-bb8b-45aeffc234fe") }
========
                    { "67e349f0-2088-4ae1-9daf-47f801ed46e4", 0, "1f5bfcb1-6182-4632-8aa2-d90fdc82e5a1", new DateTime(2024, 3, 19, 23, 34, 3, 796, DateTimeKind.Utc).AddTicks(4621), "user", "Hameed@gmail.com", true, "Hameed", "Male", "Khan", false, null, "Hameed@gmail.com", "Hameed@gmail.com", "AQAAAAIAAYagAAAAEON8rV+GqG2Dhdjly4gzt7In/qI5QJSrBpJTq8LIthzD5FMNAcfhWD7wy1j5GCTxVw==", "03457689432", false, "Provider", "48f1bf14-930a-4198-85f5-ccf77d8bbd82", new Guid("b326000a-dbe9-472f-9652-539b7a88a2bf"), false, "Hameed@gmail.com", new Guid("7ba6cbab-f16f-4898-84b8-488760ebf9b6") },
                    { "98d2f007-8437-40e3-800a-4c11c712d21f", 0, "a5dac7ac-d54f-4f70-aece-70e1f17acca6", new DateTime(2024, 3, 19, 23, 34, 3, 796, DateTimeKind.Utc).AddTicks(4575), "user", "Waheed@gmail.com", true, "Waheed", "Male", "Quraishi", false, null, "Waheed@gmail.com", "Waheed@gmail.com", "AQAAAAIAAYagAAAAENNolL3sbpU+oobKkl8A3tHcmg4F/9/8tWj0e/9Bhd0EHZsco0lpQUmlXODszEz53g==", "03457689432", false, "Provider", "296a7db9-9b66-4136-99ed-5b67c5e80471", new Guid("5d3875f8-4aee-4d31-aee1-a204404e9fdc"), false, "Waheed@gmail.com", new Guid("e0248199-dda6-4af3-9661-fa3d329aff00") },
                    { "99d0ba18-8ad2-4ea7-91e2-2808f8b872cd", 0, "677d62c9-c00f-420c-ad87-f544ddab3788", new DateTime(2024, 3, 19, 23, 34, 3, 796, DateTimeKind.Utc).AddTicks(4503), "user", "Aqib@gmail.com", true, "Aqib", "Male", "nawaz", false, null, "Aqib@gmail.com", "Aqib@gmail.com", "AQAAAAIAAYagAAAAEMGU3bmGnWYmmhbQTBdrTjMv7KIi8K2aw24uky81h/5ExnU+UhL5lSmiLd8+vxPSVQ==", "03457689432", false, "Provider", "27084b23-858d-4622-a712-abba04465335", new Guid("cee2768d-2694-4679-ad04-e9efae3fb19f"), false, "Aqib@gmail.com", new Guid("62b98ac8-b9e1-415b-98be-2a782f5e65ab") }
>>>>>>>> 536d131c91c407d4b5858a1ce9d730e32fb26d31:Server/Migrations/20240319233404_dbinit.cs
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
