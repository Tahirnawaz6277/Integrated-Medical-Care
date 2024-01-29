﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using imc_web_api;

#nullable disable

namespace imc_web_api.Migrations
{
    [DbContext(typeof(ImcDbContext))]
    partial class ImcDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            Id = "d4cca61b-a1ab-49e8-bf55-f19be009697f",
                            ConcurrencyStamp = "d4cca61b-a1ab-49e8-bf55-f19be009697f",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "4e54eb14-fe80-40ae-9c85-806035beabe6",
                            ConcurrencyStamp = "4e54eb14-fe80-40ae-9c85-806035beabe6",
                            Name = "ServiceProvider",
                            NormalizedName = "SERVICEPROVIDER"
                        },
                        new
                        {
                            Id = "ce6d2666-d634-48c8-ab84-a7ab88313213",
                            ConcurrencyStamp = "ce6d2666-d634-48c8-ab84-a7ab88313213",
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
                            UserId = "21f75896-153d-44db-897e-7942742d0e8e",
                            RoleId = "d4cca61b-a1ab-49e8-bf55-f19be009697f"
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
                            Id = new Guid("01683d6f-db82-443c-87d9-171d90aa1d03"),
                            CreatedAt = new DateTime(2024, 1, 27, 14, 11, 1, 956, DateTimeKind.Utc).AddTicks(9863),
                            ProviderName = "Doctor"
                        },
                        new
                        {
                            Id = new Guid("4586e3e7-7b16-4a9d-8e59-71639b28c2ca"),
                            CreatedAt = new DateTime(2024, 1, 27, 14, 11, 1, 956, DateTimeKind.Utc).AddTicks(9887),
                            ProviderName = "Pharmacy"
                        },
                        new
                        {
                            Id = new Guid("755049c3-a854-4768-98ba-cd5cf704ad51"),
                            CreatedAt = new DateTime(2024, 1, 27, 14, 11, 1, 956, DateTimeKind.Utc).AddTicks(9889),
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
                            Id = new Guid("960b17a1-a040-425b-ab5d-f6c4d52a043b"),
                            CreatedAt = new DateTime(2024, 1, 27, 14, 11, 1, 957, DateTimeKind.Utc).AddTicks(13),
                            experience = "10 YEAR",
                            qualification = "MBBS",
                            userId = "0f33548a-eaeb-4ccb-b69a-2d89a9bb74b0"
                        },
                        new
                        {
                            Id = new Guid("46914eca-ef85-4d4a-91b6-3ad70ae5a0ae"),
                            CreatedAt = new DateTime(2024, 1, 27, 14, 11, 1, 957, DateTimeKind.Utc).AddTicks(19),
                            experience = "3 YEAR",
                            qualification = "MD",
                            userId = "8a027457-9c2b-403e-973e-1bad582b0911"
                        },
                        new
                        {
                            Id = new Guid("b9735fbb-2ce5-47a4-8a44-8e40346c02ad"),
                            CreatedAt = new DateTime(2024, 1, 27, 14, 11, 1, 957, DateTimeKind.Utc).AddTicks(21),
                            experience = "1 YEAR",
                            qualification = "BDS",
                            userId = "0f599847-3f94-4cf7-81df-3ce2f2948974"
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
                            Id = "21f75896-153d-44db-897e-7942742d0e8e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "3c674ae9-51ed-4659-a843-09281fd80a2f",
                            Email = "Aamir@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "Aamir@gmail.com",
                            NormalizedUserName = "Aamir@gmail.com",
                            PasswordHash = "AQAAAAIAAYagAAAAEKgw0qs6iVLTcr5mHfuUD9/Ly2DZfp2i82yyY9y7j3kTHhfX+kjOi25lMDaL4KTNWA==",
                            PhoneNumber = "03457689432",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "8639b364-369f-4535-8bbc-fb0ba4b7bfa4",
                            TwoFactorEnabled = false,
                            UserName = "Aamir@gmail.com",
                            CreatedAt = new DateTime(2024, 1, 27, 14, 11, 1, 836, DateTimeKind.Utc).AddTicks(1471),
                            FirstName = "Aamir",
                            Gender = "Male",
                            LastName = "nawaz",
                            Role = "Admin"
                        },
                        new
                        {
                            Id = "0f33548a-eaeb-4ccb-b69a-2d89a9bb74b0",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "62eaf432-ecee-4955-9063-c22305213e36",
                            Email = "Aqib@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "Aqib@gmail.com",
                            NormalizedUserName = "Aqib@gmail.com",
                            PasswordHash = "AQAAAAIAAYagAAAAELUvHx5QWP0F7huQU1VzXXkD3WukH9VoEclMZXyt3Zxp+g1/duY0at1gmvN1TX45gA==",
                            PhoneNumber = "03457689432",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "8f66d638-826d-47d6-a855-b7ccb993c960",
                            TwoFactorEnabled = false,
                            UserName = "Aqib@gmail.com",
                            CreatedAt = new DateTime(2024, 1, 27, 14, 11, 1, 957, DateTimeKind.Utc).AddTicks(28),
                            FirstName = "Aqib",
                            Gender = "Male",
                            LastName = "nawaz",
                            Role = "Provider",
                            ServiceProvidertypeId = new Guid("01683d6f-db82-443c-87d9-171d90aa1d03"),
                            User_QualificationId = new Guid("960b17a1-a040-425b-ab5d-f6c4d52a043b")
                        },
                        new
                        {
                            Id = "8a027457-9c2b-403e-973e-1bad582b0911",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6dccd462-1e92-4ea5-8a35-d3cb178909c8",
                            Email = "Waheed@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "Waheed@gmail.com",
                            NormalizedUserName = "Waheed@gmail.com",
                            PasswordHash = "AQAAAAIAAYagAAAAEGyBOijerW6SUn+lYHRA5TMED232oWvzhr+zXZyhyMX7VbWB4l+MNQI6On9HRJjN4w==",
                            PhoneNumber = "03457689432",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7f4f96e8-9f45-43ec-9bb0-23826c76c233",
                            TwoFactorEnabled = false,
                            UserName = "Waheed@gmail.com",
                            CreatedAt = new DateTime(2024, 1, 27, 14, 11, 1, 957, DateTimeKind.Utc).AddTicks(79),
                            FirstName = "Waheed",
                            Gender = "Male",
                            LastName = "Quraishi",
                            Role = "Provider",
                            ServiceProvidertypeId = new Guid("4586e3e7-7b16-4a9d-8e59-71639b28c2ca"),
                            User_QualificationId = new Guid("46914eca-ef85-4d4a-91b6-3ad70ae5a0ae")
                        },
                        new
                        {
                            Id = "0f599847-3f94-4cf7-81df-3ce2f2948974",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "06bbd020-ddce-4ab0-952e-b96dea46287a",
                            Email = "Hameed@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "Hameed@gmail.com",
                            NormalizedUserName = "Hameed@gmail.com",
                            PasswordHash = "AQAAAAIAAYagAAAAEOIInCqy8zQV/QU0S+0HPjY7XFvafx/LzJS1y0yHzE4K94+lmaW2MJvxxlMkypKzJw==",
                            PhoneNumber = "03457689432",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "a1ed9489-09e6-4585-86c8-bb6b2ecf84dc",
                            TwoFactorEnabled = false,
                            UserName = "Hameed@gmail.com",
                            CreatedAt = new DateTime(2024, 1, 27, 14, 11, 1, 957, DateTimeKind.Utc).AddTicks(94),
                            FirstName = "Hameed",
                            Gender = "Male",
                            LastName = "Khan",
                            Role = "Provider",
                            ServiceProvidertypeId = new Guid("755049c3-a854-4768-98ba-cd5cf704ad51"),
                            User_QualificationId = new Guid("b9735fbb-2ce5-47a4-8a44-8e40346c02ad")
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
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("imc_web_api.Models.user", "ServiceProvider")
                        .WithOne("ServiceProvidedAgreement")
                        .HasForeignKey("imc_web_api.Models.agreement", "ServiceProviderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("ServiceProvider");
                });

            modelBuilder.Entity("imc_web_api.Models.feedback", b =>
                {
                    b.HasOne("imc_web_api.Models.user", "User")
                        .WithMany("User_Feedbacks")
                        .HasForeignKey("ratedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("imc_web_api.Models.service", "Service")
                        .WithMany("User_Feedbacks")
                        .HasForeignKey("ratedToId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Service");

                    b.Navigation("User");
                });

            modelBuilder.Entity("imc_web_api.Models.order", b =>
                {
                    b.HasOne("imc_web_api.Models.user", "User")
                        .WithOne("order")
                        .HasForeignKey("imc_web_api.Models.order", "CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("imc_web_api.Models.service", "Service")
                        .WithOne("order")
                        .HasForeignKey("imc_web_api.Models.order", "ServiceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Service");

                    b.Navigation("User");
                });

            modelBuilder.Entity("imc_web_api.Models.promotion", b =>
                {
                    b.HasOne("imc_web_api.Models.user", "PromoteByUser")
                        .WithMany("PromoteBy")
                        .HasForeignKey("PromoteById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("imc_web_api.Models.user", "PromoteToUser")
                        .WithMany("PromoteTo")
                        .HasForeignKey("PromoteToId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("PromoteByUser");

                    b.Navigation("PromoteToUser");
                });

            modelBuilder.Entity("imc_web_api.Models.service", b =>
                {
                    b.HasOne("imc_web_api.Models.serviceprovidertype", "ServiceProviderType")
                        .WithMany("givenServices")
                        .HasForeignKey("CreatedByProviderTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ServiceProviderType");
                });

            modelBuilder.Entity("imc_web_api.Models.user_qualification", b =>
                {
                    b.HasOne("imc_web_api.Models.user", "User")
                        .WithOne("User_Qualification")
                        .HasForeignKey("imc_web_api.Models.user_qualification", "userId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("imc_web_api.Models.user", b =>
                {
                    b.HasOne("imc_web_api.Models.serviceprovidertype", "ServiceProviderType")
                        .WithOne("User")
                        .HasForeignKey("imc_web_api.Models.user", "ServiceProvidertypeId")
                        .OnDelete(DeleteBehavior.Restrict);

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
