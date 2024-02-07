﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using imc_web_api;

#nullable disable

namespace imc_web_api.Migrations
{
    [DbContext(typeof(ImcDbContext))]
    [Migration("20240205100103_DbContext Updated")]
    partial class DbContextUpdated
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "45b62499-a86f-49d5-833f-1b6162add9c5",
                            ConcurrencyStamp = "45b62499-a86f-49d5-833f-1b6162add9c5",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "3162cc10-d8a4-4cfd-818b-812db103c2bc",
                            ConcurrencyStamp = "3162cc10-d8a4-4cfd-818b-812db103c2bc",
                            Name = "ServiceProvider",
                            NormalizedName = "SERVICEPROVIDER"
                        },
                        new
                        {
                            Id = "8dfdbe62-0bf0-4e0c-addd-231719170e18",
                            ConcurrencyStamp = "8dfdbe62-0bf0-4e0c-addd-231719170e18",
                            Name = "Customer",
                            NormalizedName = "CUSTOMER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "2bba3594-1cff-4921-bb17-4d93a99cf3b0",
                            RoleId = "45b62499-a86f-49d5-833f-1b6162add9c5"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("imc_web_api.Models.agreement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AdminId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAgreed")
                        .HasColumnType("bit");

                    b.Property<string>("ServiceProviderId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AdminId")
                        .IsUnique();

                    b.HasIndex("ServiceProviderId")
                        .IsUnique();

                    b.ToTable("Agreements");
                });

            modelBuilder.Entity("imc_web_api.Models.feedback", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<decimal>("Rating")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ratedById")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("ratedToId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ratedById");

                    b.HasIndex("ratedToId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("imc_web_api.Models.order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("OrderQuantity")
                        .HasColumnType("int");

                    b.Property<string>("PaymentMode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ServiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("orderStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.HasIndex("ServiceId")
                        .IsUnique();

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("imc_web_api.Models.promotion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsSent")
                        .HasColumnType("bit");

                    b.Property<string>("PromoteById")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PromoteToId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Promotion_Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("PromoteById");

                    b.HasIndex("PromoteToId");

                    b.ToTable("Promotions");
                });

            modelBuilder.Entity("imc_web_api.Models.service", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AvailableQuantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedByProviderTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TotalQuantity")
                        .HasColumnType("int");

                    b.Property<decimal>("charges")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedByProviderTypeId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("imc_web_api.Models.serviceprovidertype", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProviderName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ServiceProviderTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("87cae432-0c12-4289-85c9-293cada15ef5"),
                            CreatedAt = new DateTime(2024, 2, 5, 10, 1, 2, 703, DateTimeKind.Utc).AddTicks(4630),
                            ProviderName = "Doctor"
                        },
                        new
                        {
                            Id = new Guid("4f892b69-9cba-44e1-890c-103bdb0fa312"),
                            CreatedAt = new DateTime(2024, 2, 5, 10, 1, 2, 703, DateTimeKind.Utc).AddTicks(4662),
                            ProviderName = "Pharmacy"
                        },
                        new
                        {
                            Id = new Guid("1e348ffc-054e-4762-ba21-3759e9563ce0"),
                            CreatedAt = new DateTime(2024, 2, 5, 10, 1, 2, 703, DateTimeKind.Utc).AddTicks(4665),
                            ProviderName = "Ambulance"
                        });
                });

            modelBuilder.Entity("imc_web_api.Models.user_qualification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("experience")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("qualification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("userId")
                        .IsUnique();

                    b.ToTable("User_Qualifications");

                    b.HasData(
                        new
                        {
                            Id = new Guid("55469cc6-a481-412e-ac91-cde2728d26a5"),
                            CreatedAt = new DateTime(2024, 2, 5, 10, 1, 2, 703, DateTimeKind.Utc).AddTicks(4726),
                            experience = "10 YEAR",
                            qualification = "MBBS",
                            userId = "2b62502a-886d-4a94-abf3-bdca1043e1f9"
                        },
                        new
                        {
                            Id = new Guid("2887c668-4628-44b3-b0e0-72904333a0b7"),
                            CreatedAt = new DateTime(2024, 2, 5, 10, 1, 2, 703, DateTimeKind.Utc).AddTicks(4749),
                            experience = "3 YEAR",
                            qualification = "MD",
                            userId = "3684bd4d-613e-447f-89ac-e92d0582a428"
                        },
                        new
                        {
                            Id = new Guid("e8e0fd87-b813-44c3-a468-21438418b580"),
                            CreatedAt = new DateTime(2024, 2, 5, 10, 1, 2, 703, DateTimeKind.Utc).AddTicks(4752),
                            experience = "1 YEAR",
                            qualification = "BDS",
                            userId = "65278e46-68d1-4e0f-9631-2a8cbfd1bbae"
                        });
                });

            modelBuilder.Entity("imc_web_api.Models.user", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ServiceProvidertypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("User_QualificationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("ServiceProvidertypeId")
                        .IsUnique()
                        .HasFilter("[ServiceProvidertypeId] IS NOT NULL");

                    b.HasDiscriminator().HasValue("user");

                    b.HasData(
                        new
                        {
                            Id = "2bba3594-1cff-4921-bb17-4d93a99cf3b0",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "58ab816f-8bfb-4e6a-b841-cdac31c9fa54",
                            Email = "Aamir@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "Aamir@gmail.com",
                            NormalizedUserName = "Aamir@gmail.com",
                            PasswordHash = "AQAAAAIAAYagAAAAEHOM7268Cxnd7LWxJ4XSGWxXC/U4h77lMDs6jdLAvFgCIZvRT5piZeDkVARObnrtjA==",
                            PhoneNumber = "03457689432",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "004b1069-3aeb-476f-8675-c952be8e65b6",
                            TwoFactorEnabled = false,
                            UserName = "Aamir@gmail.com",
                            CreatedAt = new DateTime(2024, 2, 5, 10, 1, 2, 597, DateTimeKind.Utc).AddTicks(7756),
                            FirstName = "Aamir",
                            Gender = "Male",
                            LastName = "nawaz",
                            Role = "Admin"
                        },
                        new
                        {
                            Id = "2b62502a-886d-4a94-abf3-bdca1043e1f9",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "3b76e2e0-e7b9-4ed4-bab2-5b889ea4bb3b",
                            Email = "Aqib@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "Aqib@gmail.com",
                            NormalizedUserName = "Aqib@gmail.com",
                            PasswordHash = "AQAAAAIAAYagAAAAEPVns+3n6t9CS+uF9V/AsKla+O48Y5f/yDug1uRDuLKKNkBW7UR1WvJ3RmKw30m/Ig==",
                            PhoneNumber = "03457689432",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "9cfc71b3-2cdc-4238-ab75-9946ca19e9a7",
                            TwoFactorEnabled = false,
                            UserName = "Aqib@gmail.com",
                            CreatedAt = new DateTime(2024, 2, 5, 10, 1, 2, 703, DateTimeKind.Utc).AddTicks(4865),
                            FirstName = "Aqib",
                            Gender = "Male",
                            LastName = "nawaz",
                            Role = "Provider",
                            ServiceProvidertypeId = new Guid("87cae432-0c12-4289-85c9-293cada15ef5"),
                            User_QualificationId = new Guid("55469cc6-a481-412e-ac91-cde2728d26a5")
                        },
                        new
                        {
                            Id = "3684bd4d-613e-447f-89ac-e92d0582a428",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "8b90b668-a621-42d3-b11a-c81051c245b6",
                            Email = "Waheed@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "Waheed@gmail.com",
                            NormalizedUserName = "Waheed@gmail.com",
                            PasswordHash = "AQAAAAIAAYagAAAAEKCoONOcQCZc/vucAj9+LcUjy0PG2P3d7duLqGtW2DKDfcCIEiR2/9L+Oc4LEeQyRg==",
                            PhoneNumber = "03457689432",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "45666fc6-a5ca-4428-b0ea-62971be36008",
                            TwoFactorEnabled = false,
                            UserName = "Waheed@gmail.com",
                            CreatedAt = new DateTime(2024, 2, 5, 10, 1, 2, 703, DateTimeKind.Utc).AddTicks(4910),
                            FirstName = "Waheed",
                            Gender = "Male",
                            LastName = "Quraishi",
                            Role = "Provider",
                            ServiceProvidertypeId = new Guid("4f892b69-9cba-44e1-890c-103bdb0fa312"),
                            User_QualificationId = new Guid("2887c668-4628-44b3-b0e0-72904333a0b7")
                        },
                        new
                        {
                            Id = "65278e46-68d1-4e0f-9631-2a8cbfd1bbae",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "2f827d2c-27f4-482a-98ef-6c255196bf5a",
                            Email = "Hameed@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "Hameed@gmail.com",
                            NormalizedUserName = "Hameed@gmail.com",
                            PasswordHash = "AQAAAAIAAYagAAAAEEkH/ftuV+HpZ4L09ZzDU4sHlSU7etRPQi36XkUngVG220Eumg4CTiNxi+hPUBI08Q==",
                            PhoneNumber = "03457689432",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "9d0aaf44-0d28-40c6-9030-bd2de3776f1a",
                            TwoFactorEnabled = false,
                            UserName = "Hameed@gmail.com",
                            CreatedAt = new DateTime(2024, 2, 5, 10, 1, 2, 703, DateTimeKind.Utc).AddTicks(4931),
                            FirstName = "Hameed",
                            Gender = "Male",
                            LastName = "Khan",
                            Role = "Provider",
                            ServiceProvidertypeId = new Guid("1e348ffc-054e-4762-ba21-3759e9563ce0"),
                            User_QualificationId = new Guid("e8e0fd87-b813-44c3-a468-21438418b580")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("imc_web_api.Models.agreement", b =>
                {
                    b.HasOne("imc_web_api.Models.user", "Admin")
                        .WithOne("AdminAgreement")
                        .HasForeignKey("imc_web_api.Models.agreement", "AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("imc_web_api.Models.user", "ServiceProvider")
                        .WithOne("ServiceProvidedAgreement")
                        .HasForeignKey("imc_web_api.Models.agreement", "ServiceProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("ServiceProvider");
                });

            modelBuilder.Entity("imc_web_api.Models.feedback", b =>
                {
                    b.HasOne("imc_web_api.Models.user", "User")
                        .WithMany("User_Feedbacks")
                        .HasForeignKey("ratedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("imc_web_api.Models.service", "Service")
                        .WithMany("User_Feedbacks")
                        .HasForeignKey("ratedToId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");

                    b.Navigation("User");
                });

            modelBuilder.Entity("imc_web_api.Models.order", b =>
                {
                    b.HasOne("imc_web_api.Models.user", "User")
                        .WithOne("order")
                        .HasForeignKey("imc_web_api.Models.order", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("imc_web_api.Models.service", "Service")
                        .WithOne("order")
                        .HasForeignKey("imc_web_api.Models.order", "ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");

                    b.Navigation("User");
                });

            modelBuilder.Entity("imc_web_api.Models.promotion", b =>
                {
                    b.HasOne("imc_web_api.Models.user", "PromoteByUser")
                        .WithMany("PromoteBy")
                        .HasForeignKey("PromoteById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("imc_web_api.Models.user", "PromoteToUser")
                        .WithMany("PromoteTo")
                        .HasForeignKey("PromoteToId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PromoteByUser");

                    b.Navigation("PromoteToUser");
                });

            modelBuilder.Entity("imc_web_api.Models.service", b =>
                {
                    b.HasOne("imc_web_api.Models.serviceprovidertype", "ServiceProviderType")
                        .WithMany("givenServices")
                        .HasForeignKey("CreatedByProviderTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ServiceProviderType");
                });

            modelBuilder.Entity("imc_web_api.Models.user_qualification", b =>
                {
                    b.HasOne("imc_web_api.Models.user", "User")
                        .WithOne("User_Qualification")
                        .HasForeignKey("imc_web_api.Models.user_qualification", "userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("imc_web_api.Models.user", b =>
                {
                    b.HasOne("imc_web_api.Models.serviceprovidertype", "ServiceProviderType")
                        .WithOne("User")
                        .HasForeignKey("imc_web_api.Models.user", "ServiceProvidertypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("ServiceProviderType");
                });

            modelBuilder.Entity("imc_web_api.Models.service", b =>
                {
                    b.Navigation("User_Feedbacks");

                    b.Navigation("order")
                        .IsRequired();
                });

            modelBuilder.Entity("imc_web_api.Models.serviceprovidertype", b =>
                {
                    b.Navigation("User")
                        .IsRequired();

                    b.Navigation("givenServices");
                });

            modelBuilder.Entity("imc_web_api.Models.user", b =>
                {
                    b.Navigation("AdminAgreement")
                        .IsRequired();

                    b.Navigation("PromoteBy");

                    b.Navigation("PromoteTo");

                    b.Navigation("ServiceProvidedAgreement")
                        .IsRequired();

                    b.Navigation("User_Feedbacks");

                    b.Navigation("User_Qualification");

                    b.Navigation("order")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}