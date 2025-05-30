﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductManagement.Infrastructure.Data;

#nullable disable

namespace ProductManagement.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250116055013_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProductManagement.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("48d6bf86-0b06-4729-bf45-43023d86301f"),
                            Category = 1,
                            Name = "Sample Product 1",
                            Price = 199.99m
                        },
                        new
                        {
                            Id = new Guid("a0f1fffc-d909-406e-8623-4e3eb794c0c5"),
                            Category = 3,
                            Name = "Sample Product 2",
                            Price = 299.99m
                        });
                });

            modelBuilder.Entity("ProductManagement.Domain.Entities.Specification", b =>
                {
                    b.Property<Guid>("SpecificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SpecificationId");

                    b.HasIndex("ProductId");

                    b.ToTable("Specifications");

                    b.HasData(
                        new
                        {
                            SpecificationId = new Guid("2e0b9d6d-2c05-4422-8590-61a84ab12bfa"),
                            Key = "Color",
                            Value = "Red"
                        },
                        new
                        {
                            SpecificationId = new Guid("72f67a3b-a0cf-4cf6-944b-86ead27959c7"),
                            Key = "Size",
                            Value = "Medium"
                        });
                });

            modelBuilder.Entity("ProductManagement.Domain.Entities.Specification", b =>
                {
                    b.HasOne("ProductManagement.Domain.Entities.Product", null)
                        .WithMany("Specifications")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProductManagement.Domain.Entities.Product", b =>
                {
                    b.Navigation("Specifications");
                });
#pragma warning restore 612, 618
        }
    }
}
