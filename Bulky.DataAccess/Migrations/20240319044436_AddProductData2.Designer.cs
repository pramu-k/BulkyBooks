﻿// <auto-generated />
using System;
using Bulky.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bulky.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240319044436_AddProductData2")]
    partial class AddProductData2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bulky.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDateTime = new DateTime(2024, 3, 19, 10, 14, 36, 123, DateTimeKind.Local).AddTicks(313),
                            DisplayOrder = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDateTime = new DateTime(2024, 3, 19, 10, 14, 36, 123, DateTimeKind.Local).AddTicks(323),
                            DisplayOrder = 2,
                            Name = "SciFi"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDateTime = new DateTime(2024, 3, 19, 10, 14, 36, 123, DateTimeKind.Local).AddTicks(324),
                            DisplayOrder = 3,
                            Name = "History"
                        });
                });

            modelBuilder.Entity("Bulky.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ListPrice")
                        .HasColumnType("float");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("Price100")
                        .HasColumnType("float");

                    b.Property<double>("Price50")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "test author 1",
                            Description = "test description 1",
                            ISBN = "00001",
                            ListPrice = 500.0,
                            Price = 450.0,
                            Price100 = 400.0,
                            Price50 = 425.0,
                            Title = "Book 1"
                        },
                        new
                        {
                            Id = 2,
                            Author = "test author 2",
                            Description = "test description 2",
                            ISBN = "00001",
                            ListPrice = 600.0,
                            Price = 550.0,
                            Price100 = 500.0,
                            Price50 = 525.0,
                            Title = "Book 2"
                        },
                        new
                        {
                            Id = 3,
                            Author = "test author 3",
                            Description = "test description 3",
                            ISBN = "00001",
                            ListPrice = 700.0,
                            Price = 650.0,
                            Price100 = 600.0,
                            Price50 = 625.0,
                            Title = "Book 3"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
