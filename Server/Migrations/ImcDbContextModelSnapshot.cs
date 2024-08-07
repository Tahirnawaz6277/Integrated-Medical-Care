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
                            Id = "a440a947-598f-4d1a-897f-62c7be03d74b",
                            ConcurrencyStamp = "a440a947-598f-4d1a-897f-62c7be03d74b",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "22420a22-43d8-4fd8-97c6-b9299e856e56",
                            ConcurrencyStamp = "22420a22-43d8-4fd8-97c6-b9299e856e56",
                            Name = "ServiceProvider",
                            NormalizedName = "SERVICEPROVIDER"
                        },
                        new
                        {
                            Id = "1266adfd-4216-4ff9-bd21-280fb174b1ee",
                            ConcurrencyStamp = "1266adfd-4216-4ff9-bd21-280fb174b1ee",
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
                            UserId = "e4e4a445-1638-43b1-8071-63b015a45366",
                            RoleId = "a440a947-598f-4d1a-897f-62c7be03d74b"
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

            modelBuilder.Entity("imc_web_api.Models.Expense", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("ExpenseCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayeeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PayeeId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("imc_web_api.Models.Inventory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AvailableQuantity")
                        .HasColumnType("int");

                    b.Property<string>("Service")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalQuantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("imc_web_api.Models.Revenue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("PayerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PayerId");

                    b.ToTable("Revenues");
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

                    b.Property<bool>("IsTransferPayment")
                        .HasColumnType("bit");

                    b.Property<string>("OrderByUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("OrderToUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Paid")
                        .HasColumnType("bit");

                    b.Property<string>("PaymentMode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("orderStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderByUserId");

                    b.HasIndex("OrderToUserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("imc_web_api.Models.orderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("ServiceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ServiceId");

                    b.ToTable("OrderItems");
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

                    b.Property<string>("CreatedById")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("QualityTermsAgreedWithAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("TotalQuantity")
                        .HasColumnType("int");

                    b.Property<decimal>("charges")
                        .HasColumnType("decimal(19, 4)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

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

                    b.HasIndex("ServiceProvidertypeId");

                    b.HasIndex("User_QualificationId")
                        .IsUnique()
                        .HasFilter("[User_QualificationId] IS NOT NULL");

                    b.HasDiscriminator().HasValue("user");

                    b.HasData(
                        new
                        {
                            Id = "e4e4a445-1638-43b1-8071-63b015a45366",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c4d6a153-7068-413b-bbc6-3230e8fec03e",
                            Email = "Aamir@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "Aamir@gmail.com",
                            NormalizedUserName = "Aamir@gmail.com",
                            PasswordHash = "AQAAAAIAAYagAAAAEAAzrdSDbKlK1FG/jT1EETdfI0QEVeyPVacTSXp50ENg79iBbM/pGQxqicgQOx3VgQ==",
                            PhoneNumber = "03457689432",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "0db785ba-31bc-4499-9ad7-9507b418a6e7",
                            TwoFactorEnabled = false,
                            UserName = "Aamir@gmail.com",
                            CreatedAt = new DateTime(2024, 6, 24, 5, 52, 57, 161, DateTimeKind.Utc).AddTicks(5223),
                            FirstName = "Aamir",
                            Gender = "Male",
                            LastName = "nawaz",
                            Role = "Admin"
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

            modelBuilder.Entity("imc_web_api.Models.Expense", b =>
                {
                    b.HasOne("imc_web_api.Models.user", "Payee")
                        .WithMany("expenses")
                        .HasForeignKey("PayeeId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Payee");
                });

            modelBuilder.Entity("imc_web_api.Models.Revenue", b =>
                {
                    b.HasOne("imc_web_api.Models.user", "Payer")
                        .WithMany("revenues")
                        .HasForeignKey("PayerId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Payer");
                });

            modelBuilder.Entity("imc_web_api.Models.feedback", b =>
                {
                    b.HasOne("imc_web_api.Models.user", "User")
                        .WithMany("User_Feedbacks")
                        .HasForeignKey("ratedById")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("imc_web_api.Models.service", "Service")
                        .WithMany("User_Feedbacks")
                        .HasForeignKey("ratedToId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Service");

                    b.Navigation("User");
                });

            modelBuilder.Entity("imc_web_api.Models.order", b =>
                {
                    b.HasOne("imc_web_api.Models.user", "OrderBy")
                        .WithMany("OrdersByUser")
                        .HasForeignKey("OrderByUserId")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.HasOne("imc_web_api.Models.user", "OrderTo")
                        .WithMany("OrderToUser")
                        .HasForeignKey("OrderToUserId")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.Navigation("OrderBy");

                    b.Navigation("OrderTo");
                });

            modelBuilder.Entity("imc_web_api.Models.orderItem", b =>
                {
                    b.HasOne("imc_web_api.Models.order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("imc_web_api.Models.service", "Service")
                        .WithMany("OrderItems")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("imc_web_api.Models.promotion", b =>
                {
                    b.HasOne("imc_web_api.Models.user", "PromoteByUser")
                        .WithMany("PromoteBy")
                        .HasForeignKey("PromoteById")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("imc_web_api.Models.user", "PromoteToUser")
                        .WithMany("PromoteTo")
                        .HasForeignKey("PromoteToId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("PromoteByUser");

                    b.Navigation("PromoteToUser");
                });

            modelBuilder.Entity("imc_web_api.Models.service", b =>
                {
                    b.HasOne("imc_web_api.Models.user", "User")
                        .WithMany("services")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.Navigation("User");
                });

            modelBuilder.Entity("imc_web_api.Models.user", b =>
                {
                    b.HasOne("imc_web_api.Models.serviceprovidertype", "ServiceProviderType")
                        .WithMany("Users")
                        .HasForeignKey("ServiceProvidertypeId")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.HasOne("imc_web_api.Models.user_qualification", "User_Qualification")
                        .WithOne("User")
                        .HasForeignKey("imc_web_api.Models.user", "User_QualificationId")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.Navigation("ServiceProviderType");

                    b.Navigation("User_Qualification");
                });

            modelBuilder.Entity("imc_web_api.Models.order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("imc_web_api.Models.service", b =>
                {
                    b.Navigation("OrderItems");

                    b.Navigation("User_Feedbacks");
                });

            modelBuilder.Entity("imc_web_api.Models.serviceprovidertype", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("imc_web_api.Models.user_qualification", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("imc_web_api.Models.user", b =>
                {
                    b.Navigation("OrderToUser");

                    b.Navigation("OrdersByUser");

                    b.Navigation("PromoteBy");

                    b.Navigation("PromoteTo");

                    b.Navigation("User_Feedbacks");

                    b.Navigation("expenses");

                    b.Navigation("revenues");

                    b.Navigation("services");
                });
#pragma warning restore 612, 618
        }
    }
}
