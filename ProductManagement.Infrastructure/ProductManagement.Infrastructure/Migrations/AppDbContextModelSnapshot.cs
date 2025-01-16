﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductManagement.Infrastructure.Data;

#nullable disable

namespace ProductManagement.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            Id = new Guid("f3dce1c3-3ff4-49e4-a325-796636072f3f"),
                            Category = 1,
                            Name = "Sample Product 1",
                            Price = 199.99m
                        },
                        new
                        {
                            Id = new Guid("4e98b18b-c5a5-45df-9397-1f78570c681e"),
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
                            SpecificationId = new Guid("7a533664-1ae3-4799-9722-9e184c9e3a7c"),
                            Key = "Color",
                            Value = "Red"
                        },
                        new
                        {
                            SpecificationId = new Guid("b76cb809-033e-493d-bfab-b95520cfa9bb"),
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
