﻿// <auto-generated />
using System;
using DigitalRetailers.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DigitalRetailers.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20211007124855_LaptopQuantityAdded")]
    partial class LaptopQuantityAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DigitalRetailers.Models.Laptop", b =>
                {
                    b.Property<int>("laptopId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("laptopImageLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("laptopName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("laptopPrice")
                        .HasColumnType("real");

                    b.Property<int>("laptopQuantity")
                        .HasColumnType("int");

                    b.Property<string>("laptopSpecification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("laptopId");

                    b.ToTable("Laptops");
                });

            modelBuilder.Entity("DigitalRetailers.Models.User", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("userAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userId");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
