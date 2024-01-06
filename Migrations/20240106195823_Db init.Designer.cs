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
    [Migration("20240106195823_Db init")]
    partial class Dbinit
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IdentityRole");

                    b.HasData(
                        new
                        {
                            Id = "4e050638-06b1-4d94-9462-757e387f70a5",
                            ConcurrencyStamp = "4e050638-06b1-4d94-9462-757e387f70a5",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "8fa1d802-1a62-44bb-9f8d-6803a4295c73",
                            ConcurrencyStamp = "8fa1d802-1a62-44bb-9f8d-6803a4295c73",
                            Name = "ServiceProvider",
                            NormalizedName = "SERVICEPROVIDER"
                        },
                        new
                        {
                            Id = "7aa03b52-a1b4-42de-a645-583f99b0eebb",
                            ConcurrencyStamp = "7aa03b52-a1b4-42de-a645-583f99b0eebb",
                            Name = "Customer",
                            NormalizedName = "CUSTOMER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("IdentityUserRole<string>");

                    b.HasData(
                        new
                        {
                            UserId = "7da58f98-178a-4bb0-b8fe-f4518ad64d21",
                            RoleId = "4e050638-06b1-4d94-9462-757e387f70a5"
                        });
                });

            modelBuilder.Entity("imc_web_api.Models.user", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = "7da58f98-178a-4bb0-b8fe-f4518ad64d21",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "388b51bc-6b4d-4b69-a0ea-ba3f0fda5a2f",
                            Email = "muhammadtalha@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "muhammadtalha@gmail.com",
                            NormalizedUserName = "muhammadtalha@gmail.com",
                            PasswordHash = "AQAAAAIAAYagAAAAEB3e79q9pw8NOz9/s3foF5Wf6L+kgOlVg4p6Dwp4md9+xVmheipUfLLWetFzAHY6nw==",
                            PhoneNumberConfirmed = false,
                            Role = "Admin",
                            SecurityStamp = "95f99d4b-ad70-4708-97a0-19ff8ab8452b",
                            TwoFactorEnabled = false,
                            UserName = "muhammadtalha@gmail.com",
                            contact = "03457689432",
                            firstName = "Muhammad",
                            gender = "Male",
                            lastName = "Talha"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
