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
<<<<<<<< HEAD:Migrations/20240113191253_dbinit.cs
                    { "5ceeb257-67d9-4d9f-ac9d-97f52b18fe52", "5ceeb257-67d9-4d9f-ac9d-97f52b18fe52", "ServiceProvider", "SERVICEPROVIDER" },
                    { "ae3d5aa0-0456-4c9c-898d-7380c6df21de", "ae3d5aa0-0456-4c9c-898d-7380c6df21de", "Customer", "CUSTOMER" },
                    { "de85ff03-b9de-49a0-90b1-d07cc668b52a", "de85ff03-b9de-49a0-90b1-d07cc668b52a", "Admin", "ADMIN" }
========
                    { "57e71f9d-3c20-43e4-9b66-e1a3e00dac73", "57e71f9d-3c20-43e4-9b66-e1a3e00dac73", "ServiceProvider", "SERVICEPROVIDER" },
                    { "7c53b965-75f5-46d0-9c81-df29129bbfd6", "7c53b965-75f5-46d0-9c81-df29129bbfd6", "Customer", "CUSTOMER" },
                    { "bafdc162-79c6-44f9-b1bc-5c4068567ac7", "bafdc162-79c6-44f9-b1bc-5c4068567ac7", "Admin", "ADMIN" }
>>>>>>>> 0704a88 (Manage Promotion Done):Migrations/20240113155633_Db Init.cs
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "ServiceProvidertypeId", "TwoFactorEnabled", "UserName", "User_QualificationId" },
<<<<<<<< HEAD:Migrations/20240113191253_dbinit.cs
                values: new object[] { "52211f3b-7d1b-44b7-ae65-a144d8929993", 0, "b8dd0c7e-982f-4947-af25-5cf9fb7d3f68", "user", "Aamir@gmail.com", true, "Aamir", "Male", "nawaz", false, null, "Aamir@gmail.com", "Aamir@gmail.com", "AQAAAAIAAYagAAAAELSmgq04USmCMK8+/4B1lEyqMX8fR1vhw2b4Wvs11dFkvSUJQyVYoxl/P10Wdw7Iow==", "03457689432", false, "Admin", "aa00396e-27b6-46dc-bea6-0eeb88753c56", null, false, "Aamir@gmail.com", null });
========
                values: new object[] { "31687fb2-25bc-4690-9a0d-bcfc2163b1a0", 0, "9571ab67-d132-4a06-a302-8162fbb36756", "user", "Aamir@gmail.com", true, "Aamir", "Male", "nawaz", false, null, "Aamir@gmail.com", "Aamir@gmail.com", "AQAAAAIAAYagAAAAEOUBXGK2iqJo5/zuaa/ziKUV0xOAqE/NuZ1oTpgbagIpTq0t89El0JV6ovwcEfvnXw==", "03457689432", false, "Admin", "daed9816-0687-4337-a3c3-69babca4c0ae", null, false, "Aamir@gmail.com", null });
>>>>>>>> 0704a88 (Manage Promotion Done):Migrations/20240113155633_Db Init.cs

            migrationBuilder.InsertData(
                table: "ServiceProviderTypes",
                columns: new[] { "Id", "ProviderName" },
                values: new object[,]
                {
<<<<<<<< HEAD:Migrations/20240113191253_dbinit.cs
                    { new Guid("57edea49-e54a-4992-a430-1755b8f0cd7e"), "Doctor" },
                    { new Guid("70544167-5c53-47f5-a145-b568d6186348"), "Pharmacy" },
                    { new Guid("8b8f2d35-e974-497d-b41b-0c8df734699a"), "Ambulance" }
========
                    { new Guid("38355c12-32a7-45a0-9328-554bba00ff66"), "Doctor" },
                    { new Guid("b04a6541-6c00-42c0-8198-0ae4b520fadb"), "Ambulance" },
                    { new Guid("e579e41b-dbd2-4b91-80d5-dff92780a3b1"), "Pharmacy" }
>>>>>>>> 0704a88 (Manage Promotion Done):Migrations/20240113155633_Db Init.cs
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
<<<<<<<< HEAD:Migrations/20240113191253_dbinit.cs
                values: new object[] { "de85ff03-b9de-49a0-90b1-d07cc668b52a", "52211f3b-7d1b-44b7-ae65-a144d8929993" });
========
                values: new object[] { "bafdc162-79c6-44f9-b1bc-5c4068567ac7", "31687fb2-25bc-4690-9a0d-bcfc2163b1a0" });
>>>>>>>> 0704a88 (Manage Promotion Done):Migrations/20240113155633_Db Init.cs

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "ServiceProvidertypeId", "TwoFactorEnabled", "UserName", "User_QualificationId" },
                values: new object[,]
                {
<<<<<<<< HEAD:Migrations/20240113191253_dbinit.cs
                    { "05c560a2-4641-4c35-aed2-47d4c7a74710", 0, "6bae9a74-dbcf-47b2-96e2-b2379da98e92", "user", "Aqib@gmail.com", true, "Aqib", "Male", "nawaz", false, null, "Aqib@gmail.com", "Aqib@gmail.com", "AQAAAAIAAYagAAAAEOyOkB1I2KyNCyBOm2Z852Kj0pfR34cXJc/WCbGJSbC+xzlO2+i6t62S129wDElfJg==", "03457689432", false, "Provider", "c2ec74cc-db16-4cd5-b9f3-16bdaef5e6c5", new Guid("57edea49-e54a-4992-a430-1755b8f0cd7e"), false, "Aqib@gmail.com", new Guid("09b0e1d3-7e93-47a2-beec-88f99f275ebe") },
                    { "31de9f4a-9930-4ffd-b490-ebac6ed2854d", 0, "5a13c69a-3564-49d3-be92-9cf86ad5026d", "user", "Hameed@gmail.com", true, "Hameed", "Male", "Khan", false, null, "Hameed@gmail.com", "Hameed@gmail.com", "AQAAAAIAAYagAAAAEDEnWq2SDVD92kaZreppIjigqP9klLRY8oRWfnSU2CkyrPSMYwpQ14oa/30TCewICQ==", "03457689432", false, "Provider", "fe3bd282-ca1f-4138-909e-3b9b4ddbe860", new Guid("8b8f2d35-e974-497d-b41b-0c8df734699a"), false, "Hameed@gmail.com", new Guid("031b5aca-35e0-4ff4-a06e-4ed814961e14") },
                    { "baff2361-0c19-4d07-acf9-c4c867451fae", 0, "73f165d4-5160-46f3-8c88-d640db057d87", "user", "Waheed@gmail.com", true, "Waheed", "Male", "Quraishi", false, null, "Waheed@gmail.com", "Waheed@gmail.com", "AQAAAAIAAYagAAAAEHAGnPhLXO3PXPYA/d8yqhtuA3t6ChEdsXopoPjGiVy5XpQ9+gFOcJtGImPrBcRCIg==", "03457689432", false, "Provider", "4adb128b-aa42-48d9-bc38-bf82de72edb0", new Guid("70544167-5c53-47f5-a145-b568d6186348"), false, "Waheed@gmail.com", new Guid("3f7fc9ea-20ed-43d8-bfe2-4115dc39777b") }
========
                    { "78d0c0bf-0141-4310-b5d7-f1eeb5969ba8", 0, "cd161902-a449-4155-909f-331fc4f9683b", "user", "Hameed@gmail.com", true, "Hameed", "Male", "Khan", false, null, "Hameed@gmail.com", "Hameed@gmail.com", "AQAAAAIAAYagAAAAEMHgTrPYW+0dkg23VQIJnD3TLwfdg2JFohRZlgXnvtOeqTQHEdP7N22OEA5XG9aDQQ==", "03457689432", false, "Provider", "1803991c-29c0-4f9a-b0df-debff11f1a4f", new Guid("b04a6541-6c00-42c0-8198-0ae4b520fadb"), false, "Hameed@gmail.com", new Guid("65cca636-ffa9-422a-b4f3-0e37d80b74e1") },
                    { "b7b6252c-9c64-4731-9403-dd3efd40f43a", 0, "f76368f6-3d8f-4e28-b077-8422a539bf59", "user", "Waheed@gmail.com", true, "Waheed", "Male", "Quraishi", false, null, "Waheed@gmail.com", "Waheed@gmail.com", "AQAAAAIAAYagAAAAEHcMjymW+xE9xrxWvschWaz/1YqVHBrCZ3/xKXSJbrFKAzsBonfLqNqnxwDEkIIRmA==", "03457689432", false, "Provider", "07abd710-daff-4989-bb55-8779600430ad", new Guid("e579e41b-dbd2-4b91-80d5-dff92780a3b1"), false, "Waheed@gmail.com", new Guid("c117fd1f-85f6-4702-9ce9-4d78d2d86f57") },
                    { "f3f48732-2ea0-484e-8bc7-11237cd296a1", 0, "6fbc312c-784c-4dfc-9441-3b341a989793", "user", "Aqib@gmail.com", true, "Aqib", "Male", "nawaz", false, null, "Aqib@gmail.com", "Aqib@gmail.com", "AQAAAAIAAYagAAAAEEBUTbi6fyjSwo7s99dGZ+qOAUNQW6SQ8t2hf4t8bdm4Cw5S+xqqjjpDr0J24tTnpQ==", "03457689432", false, "Provider", "f6235728-deba-4bf3-98c9-be02319edc10", new Guid("38355c12-32a7-45a0-9328-554bba00ff66"), false, "Aqib@gmail.com", new Guid("22bd394a-1d5a-40be-a0b3-547f3a350a43") }
>>>>>>>> 0704a88 (Manage Promotion Done):Migrations/20240113155633_Db Init.cs
                });

            migrationBuilder.InsertData(
                table: "User_Qualifications",
                columns: new[] { "Id", "experience", "qualification", "userId" },
                values: new object[,]
                {
<<<<<<<< HEAD:Migrations/20240113191253_dbinit.cs
                    { new Guid("031b5aca-35e0-4ff4-a06e-4ed814961e14"), "1 YEAR", "BDS", "31de9f4a-9930-4ffd-b490-ebac6ed2854d" },
                    { new Guid("09b0e1d3-7e93-47a2-beec-88f99f275ebe"), "10 YEAR", "MBBS", "05c560a2-4641-4c35-aed2-47d4c7a74710" },
                    { new Guid("3f7fc9ea-20ed-43d8-bfe2-4115dc39777b"), "3 YEAR", "MD", "baff2361-0c19-4d07-acf9-c4c867451fae" }
========
                    { new Guid("22bd394a-1d5a-40be-a0b3-547f3a350a43"), "10 YEAR", "MBBS", "f3f48732-2ea0-484e-8bc7-11237cd296a1" },
                    { new Guid("65cca636-ffa9-422a-b4f3-0e37d80b74e1"), "1 YEAR", "BDS", "78d0c0bf-0141-4310-b5d7-f1eeb5969ba8" },
                    { new Guid("c117fd1f-85f6-4702-9ce9-4d78d2d86f57"), "3 YEAR", "MD", "b7b6252c-9c64-4731-9403-dd3efd40f43a" }
>>>>>>>> 0704a88 (Manage Promotion Done):Migrations/20240113155633_Db Init.cs
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