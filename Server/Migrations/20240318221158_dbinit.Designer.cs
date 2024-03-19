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
    [Migration("20240318221158_dbinit")]
    partial class dbinit
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
                            Id = "f38f82a7-41da-4158-9d99-97cc35f32cdf",
                            ConcurrencyStamp = "f38f82a7-41da-4158-9d99-97cc35f32cdf",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "46c87de0-2440-4b71-916d-6b93b813639f",
                            ConcurrencyStamp = "46c87de0-2440-4b71-916d-6b93b813639f",
                            Name = "ServiceProvider",
                            NormalizedName = "SERVICEPROVIDER"
                        },
                        new
                        {
                            Id = "52f98e9e-a617-463d-9b0a-8328e73038c3",
                            ConcurrencyStamp = "52f98e9e-a617-463d-9b0a-8328e73038c3",
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
                            UserId = "516ab668-63dc-4a30-bdb2-3917969dabe4",
                            RoleId = "f38f82a7-41da-4158-9d99-97cc35f32cdf"
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
                        .HasColumnType("decimal(19, 4)");

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

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("OrderByUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

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

                    b.HasIndex("OrderByUserId")
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

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("CreatedByAdminId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("CreatedByProviderTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TotalQuantity")
                        .HasColumnType("int");

                    b.Property<decimal>("charges")
                        .HasColumnType("decimal(19, 4)");

                    b.Property<string>("image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedByAdminId");

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
                            Id = new Guid("9429343d-2828-48af-a89c-6496312f28af"),
                            CreatedAt = new DateTime(2024, 3, 18, 22, 11, 58, 131, DateTimeKind.Utc).AddTicks(1882),
                            ProviderName = "Doctor"
                        },
                        new
                        {
                            Id = new Guid("8378506f-4072-46c1-9478-cf8c23c694ad"),
                            CreatedAt = new DateTime(2024, 3, 18, 22, 11, 58, 131, DateTimeKind.Utc).AddTicks(1915),
                            ProviderName = "Pharmacy"
                        },
                        new
                        {
                            Id = new Guid("1a69e835-6b23-4abd-83b6-6a2d9c55e0d8"),
                            CreatedAt = new DateTime(2024, 3, 18, 22, 11, 58, 131, DateTimeKind.Utc).AddTicks(1920),
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

                    b.HasKey("Id");

                    b.ToTable("User_Qualifications");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0fb1deb0-1aac-41f8-8abf-ce05a5ced622"),
                            CreatedAt = new DateTime(2024, 3, 18, 22, 11, 58, 131, DateTimeKind.Utc).AddTicks(2098),
                            experience = "10 YEAR",
                            qualification = "MBBS"
                        },
                        new
                        {
                            Id = new Guid("b104596a-9fd7-493e-bb61-75371e06dc87"),
                            CreatedAt = new DateTime(2024, 3, 18, 22, 11, 58, 131, DateTimeKind.Utc).AddTicks(2128),
                            experience = "3 YEAR",
                            qualification = "MD"
                        },
                        new
                        {
                            Id = new Guid("d0feef7e-7a45-4a73-892e-100f04a79f40"),
                            CreatedAt = new DateTime(2024, 3, 18, 22, 11, 58, 131, DateTimeKind.Utc).AddTicks(2132),
                            experience = "1 YEAR",
                            qualification = "BDS"
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

                    b.HasIndex("User_QualificationId")
                        .IsUnique()
                        .HasFilter("[User_QualificationId] IS NOT NULL");

                    b.HasDiscriminator().HasValue("user");

                    b.HasData(
                        new
                        {
                            Id = "516ab668-63dc-4a30-bdb2-3917969dabe4",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7c71517f-2122-4183-83e1-5c12759d66d5",
                            Email = "Aamir@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "Aamir@gmail.com",
                            NormalizedUserName = "Aamir@gmail.com",
                            PasswordHash = "AQAAAAIAAYagAAAAEGVBzRHLTxUbXiUT/O1fxLLK08WRXhqj0lKxHOO2xLNxwRQOZBt+PLKs5dqGUE5oOQ==",
                            PhoneNumber = "03457689432",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5fc4969e-d81e-4bd6-b68a-82802c976604",
                            TwoFactorEnabled = false,
                            UserName = "Aamir@gmail.com",
                            CreatedAt = new DateTime(2024, 3, 18, 22, 11, 58, 13, DateTimeKind.Utc).AddTicks(4914),
                            FirstName = "Aamir",
                            Gender = "Male",
                            LastName = "nawaz",
                            Role = "Admin"
                        },
                        new
                        {
                            Id = "45f0d688-1458-4e11-a74a-65451c5a03ff",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "05d8f76b-0e18-4de4-aff6-60f31b7d35e5",
                            Email = "Aqib@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "Aqib@gmail.com",
                            NormalizedUserName = "Aqib@gmail.com",
                            PasswordHash = "AQAAAAIAAYagAAAAEEA9Bv1Xqlgnv5V8dThvBZgYpKPy5MBdKBTZfh94eBeWWZD90r4sYd7861Jf2Sfwow==",
                            PhoneNumber = "03457689432",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "791d9620-8517-47b3-8c2f-78c0041f13b4",
                            TwoFactorEnabled = false,
                            UserName = "Aqib@gmail.com",
                            CreatedAt = new DateTime(2024, 3, 18, 22, 11, 58, 131, DateTimeKind.Utc).AddTicks(2305),
                            FirstName = "Aqib",
                            Gender = "Male",
                            LastName = "nawaz",
                            Role = "Provider",
                            ServiceProvidertypeId = new Guid("9429343d-2828-48af-a89c-6496312f28af"),
                            User_QualificationId = new Guid("0fb1deb0-1aac-41f8-8abf-ce05a5ced622")
                        },
                        new
                        {
                            Id = "154afba7-6bf4-4db5-8b3b-a6266c000147",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ce18e372-32b6-4a70-8654-7cd21a933462",
                            Email = "Waheed@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "Waheed@gmail.com",
                            NormalizedUserName = "Waheed@gmail.com",
                            PasswordHash = "AQAAAAIAAYagAAAAELKZf12fnclxWLDL2Hh5x6pn5wNN6yAPUK3vOFyVhWAN/YsgJTS/vvyKCSudMka3Ig==",
                            PhoneNumber = "03457689432",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "233f26c4-4c55-4614-972f-ec9169c356da",
                            TwoFactorEnabled = false,
                            UserName = "Waheed@gmail.com",
                            CreatedAt = new DateTime(2024, 3, 18, 22, 11, 58, 131, DateTimeKind.Utc).AddTicks(2388),
                            FirstName = "Waheed",
                            Gender = "Male",
                            LastName = "Quraishi",
                            Role = "Provider",
                            ServiceProvidertypeId = new Guid("8378506f-4072-46c1-9478-cf8c23c694ad"),
                            User_QualificationId = new Guid("b104596a-9fd7-493e-bb61-75371e06dc87")
                        },
                        new
                        {
                            Id = "f149252a-adbf-48bb-909a-739f428ed7d8",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "4132789a-5757-40f3-84c5-8f7068fbb4b8",
                            Email = "Hameed@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "Hameed@gmail.com",
                            NormalizedUserName = "Hameed@gmail.com",
                            PasswordHash = "AQAAAAIAAYagAAAAELRbb28nqbUe/EIaZa60WbEBcnCA+ZVOs5XbkmiDlOyUa1btPron3nJvc5fhrh425Q==",
                            PhoneNumber = "03457689432",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "79c6cbe4-d5bd-49ea-8dfe-a2e7bf2e8a1c",
                            TwoFactorEnabled = false,
                            UserName = "Hameed@gmail.com",
                            CreatedAt = new DateTime(2024, 3, 18, 22, 11, 58, 131, DateTimeKind.Utc).AddTicks(3581),
                            FirstName = "Hameed",
                            Gender = "Male",
                            LastName = "Khan",
                            Role = "Provider",
                            ServiceProvidertypeId = new Guid("1a69e835-6b23-4abd-83b6-6a2d9c55e0d8"),
                            User_QualificationId = new Guid("d0feef7e-7a45-4a73-892e-100f04a79f40")
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
                    b.HasOne("imc_web_api.Models.user", "OrderBy")
                        .WithOne("order")
                        .HasForeignKey("imc_web_api.Models.order", "OrderByUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("imc_web_api.Models.service", "Service")
                        .WithOne("order")
                        .HasForeignKey("imc_web_api.Models.order", "ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderBy");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("imc_web_api.Models.promotion", b =>
                {
                    b.HasOne("imc_web_api.Models.user", "PromoteByUser")
                        .WithMany("PromoteBy")
                        .HasForeignKey("PromoteById")
                        .IsRequired();

                    b.HasOne("imc_web_api.Models.user", "PromoteToUser")
                        .WithMany("PromoteTo")
                        .HasForeignKey("PromoteToId")
                        .IsRequired();

                    b.Navigation("PromoteByUser");

                    b.Navigation("PromoteToUser");
                });

            modelBuilder.Entity("imc_web_api.Models.service", b =>
                {
                    b.HasOne("imc_web_api.Models.user", "User")
                        .WithMany()
                        .HasForeignKey("CreatedByAdminId");

                    b.HasOne("imc_web_api.Models.serviceprovidertype", "ServiceProviderType")
                        .WithMany("givenServices")
                        .HasForeignKey("CreatedByProviderTypeId");

                    b.Navigation("ServiceProviderType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("imc_web_api.Models.user", b =>
                {
                    b.HasOne("imc_web_api.Models.serviceprovidertype", "ServiceProviderType")
                        .WithOne("User")
                        .HasForeignKey("imc_web_api.Models.user", "ServiceProvidertypeId");

                    b.HasOne("imc_web_api.Models.user_qualification", "User_Qualification")
                        .WithOne("User")
                        .HasForeignKey("imc_web_api.Models.user", "User_QualificationId");

                    b.Navigation("ServiceProviderType");

                    b.Navigation("User_Qualification");
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

            modelBuilder.Entity("imc_web_api.Models.user_qualification", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("imc_web_api.Models.user", b =>
                {
                    b.Navigation("PromoteBy");

                    b.Navigation("PromoteTo");

                    b.Navigation("User_Feedbacks");

                    b.Navigation("order")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}