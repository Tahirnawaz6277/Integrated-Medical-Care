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
                            Id = "deb6ca27-d789-41e5-9f7b-b3bb5eb58796",
                            ConcurrencyStamp = "deb6ca27-d789-41e5-9f7b-b3bb5eb58796",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "003f4000-090c-4058-a639-cf758b69e6f2",
                            ConcurrencyStamp = "003f4000-090c-4058-a639-cf758b69e6f2",
                            Name = "ServiceProvider",
                            NormalizedName = "SERVICEPROVIDER"
                        },
                        new
                        {
                            Id = "93039ec0-50ce-45bb-b719-0537b8b8ff3f",
                            ConcurrencyStamp = "93039ec0-50ce-45bb-b719-0537b8b8ff3f",
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
                            UserId = "89006694-c338-46ca-9ccc-9ba8df422a9a",
                            RoleId = "deb6ca27-d789-41e5-9f7b-b3bb5eb58796"
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
                        .HasColumnType("decimal(18,2)");

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
                            Id = new Guid("3e9906f5-49d3-467c-ab45-ee0834ac4862"),
                            CreatedAt = new DateTime(2024, 2, 9, 13, 19, 34, 961, DateTimeKind.Utc).AddTicks(3067),
                            ProviderName = "Doctor"
                        },
                        new
                        {
                            Id = new Guid("706fb3d3-073c-42de-8bc9-525000830777"),
                            CreatedAt = new DateTime(2024, 2, 9, 13, 19, 34, 961, DateTimeKind.Utc).AddTicks(3098),
                            ProviderName = "Pharmacy"
                        },
                        new
                        {
                            Id = new Guid("fda335de-0022-4b68-86f9-8755b3243d1a"),
                            CreatedAt = new DateTime(2024, 2, 9, 13, 19, 34, 961, DateTimeKind.Utc).AddTicks(3112),
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
                            Id = new Guid("657b4ab3-6beb-403c-9eb4-e3d037124623"),
                            CreatedAt = new DateTime(2024, 2, 9, 13, 19, 34, 961, DateTimeKind.Utc).AddTicks(3190),
                            experience = "10 YEAR",
                            qualification = "MBBS",
                            userId = "c48eee52-bde5-4f2f-9f2a-076a284441c7"
                        },
                        new
                        {
                            Id = new Guid("2a1bf438-64c1-4ed6-a6e6-43ada4bf3169"),
                            CreatedAt = new DateTime(2024, 2, 9, 13, 19, 34, 961, DateTimeKind.Utc).AddTicks(3195),
                            experience = "3 YEAR",
                            qualification = "MD",
                            userId = "55d11137-efd8-4800-943b-c8074d60b96d"
                        },
                        new
                        {
                            Id = new Guid("af563d13-49b5-4da8-9d88-15b84b0b0445"),
                            CreatedAt = new DateTime(2024, 2, 9, 13, 19, 34, 961, DateTimeKind.Utc).AddTicks(3198),
                            experience = "1 YEAR",
                            qualification = "BDS",
                            userId = "cc793db7-b5f3-4bd0-9080-7046640bd85f"
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
                            Id = "89006694-c338-46ca-9ccc-9ba8df422a9a",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7c308d00-5742-4571-9976-ae5cf9c50bbc",
                            Email = "Aamir@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "Aamir@gmail.com",
                            NormalizedUserName = "Aamir@gmail.com",
                            PasswordHash = "AQAAAAIAAYagAAAAELgB65XJL3SNxvL+l7gFQzdgG3DgwuI3wwzCMEZxIgXBID97RSL0mgaH+wpFgpydQQ==",
                            PhoneNumber = "03457689432",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "c069a312-9038-4865-a108-131334b4580c",
                            TwoFactorEnabled = false,
                            UserName = "Aamir@gmail.com",
                            CreatedAt = new DateTime(2024, 2, 9, 13, 19, 34, 797, DateTimeKind.Utc).AddTicks(1231),
                            FirstName = "Aamir",
                            Gender = "Male",
                            LastName = "nawaz",
                            Role = "Admin"
                        },
                        new
                        {
                            Id = "c48eee52-bde5-4f2f-9f2a-076a284441c7",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "0395b73d-b143-4e1d-a342-71cb9399c171",
                            Email = "Aqib@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "Aqib@gmail.com",
                            NormalizedUserName = "Aqib@gmail.com",
                            PasswordHash = "AQAAAAIAAYagAAAAEOS4hNrVxt3Y/+J7gZbjBbe7q6D/AWGrPeBaNYY2e/yfJMWCABiXuaHN8f3aOKeOyQ==",
                            PhoneNumber = "03457689432",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "61696fbe-2b91-4f97-a8ce-fa218c37ad40",
                            TwoFactorEnabled = false,
                            UserName = "Aqib@gmail.com",
                            CreatedAt = new DateTime(2024, 2, 9, 13, 19, 34, 961, DateTimeKind.Utc).AddTicks(3203),
                            FirstName = "Aqib",
                            Gender = "Male",
                            LastName = "nawaz",
                            Role = "Provider",
                            ServiceProvidertypeId = new Guid("3e9906f5-49d3-467c-ab45-ee0834ac4862"),
                            User_QualificationId = new Guid("657b4ab3-6beb-403c-9eb4-e3d037124623")
                        },
                        new
                        {
                            Id = "55d11137-efd8-4800-943b-c8074d60b96d",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "24b318da-e12c-4d08-8a72-4c8b7ccb595c",
                            Email = "Waheed@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "Waheed@gmail.com",
                            NormalizedUserName = "Waheed@gmail.com",
                            PasswordHash = "AQAAAAIAAYagAAAAEGd5Na4nFDkSSitVfkygvyr0HwJ5CSt89IXGdVUljiik0Y19TFJ8mTTdQJ0o7unTOg==",
                            PhoneNumber = "03457689432",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "31f783a6-9244-4a71-adea-b19e0fb523d0",
                            TwoFactorEnabled = false,
                            UserName = "Waheed@gmail.com",
                            CreatedAt = new DateTime(2024, 2, 9, 13, 19, 34, 961, DateTimeKind.Utc).AddTicks(3243),
                            FirstName = "Waheed",
                            Gender = "Male",
                            LastName = "Quraishi",
                            Role = "Provider",
                            ServiceProvidertypeId = new Guid("706fb3d3-073c-42de-8bc9-525000830777"),
                            User_QualificationId = new Guid("2a1bf438-64c1-4ed6-a6e6-43ada4bf3169")
                        },
                        new
                        {
                            Id = "cc793db7-b5f3-4bd0-9080-7046640bd85f",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7d650b49-9594-4df1-8343-83f1a4e97c60",
                            Email = "Hameed@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "Hameed@gmail.com",
                            NormalizedUserName = "Hameed@gmail.com",
                            PasswordHash = "AQAAAAIAAYagAAAAEMzBSAHRNDPItcEjki8rbv8txV3IAQpWAdMYHCBl2QcSrxO6+oshhHGA+1lp9PWBlA==",
                            PhoneNumber = "03457689432",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "53fce0a8-9453-430f-a80d-f4b0fd10b319",
                            TwoFactorEnabled = false,
                            UserName = "Hameed@gmail.com",
                            CreatedAt = new DateTime(2024, 2, 9, 13, 19, 34, 961, DateTimeKind.Utc).AddTicks(3259),
                            FirstName = "Hameed",
                            Gender = "Male",
                            LastName = "Khan",
                            Role = "Provider",
                            ServiceProvidertypeId = new Guid("fda335de-0022-4b68-86f9-8755b3243d1a"),
                            User_QualificationId = new Guid("af563d13-49b5-4da8-9d88-15b84b0b0445")
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
                    b.HasOne("imc_web_api.Models.user", "User")
                        .WithMany()
                        .HasForeignKey("CreatedByAdminId");

                    b.HasOne("imc_web_api.Models.serviceprovidertype", "ServiceProviderType")
                        .WithMany("givenServices")
                        .HasForeignKey("CreatedByProviderTypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ServiceProviderType");

                    b.Navigation("User");
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
                    b.Navigation("PromoteBy");

                    b.Navigation("PromoteTo");

                    b.Navigation("User_Feedbacks");

                    b.Navigation("User_Qualification");

                    b.Navigation("order")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
