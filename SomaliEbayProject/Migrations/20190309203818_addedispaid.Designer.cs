﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SomaliEbayProject.Models;

namespace SomaliEbayProject.Migrations
{
    [DbContext(typeof(SomaliDbConext))]
    [Migration("20190309203818_addedispaid")]
    partial class addedispaid
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SomaliEbayProject.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Discount");

                    b.Property<bool>("IsPaid");

                    b.Property<int?>("ProductId");

                    b.Property<int>("Qty");

                    b.Property<decimal>("TotalCost");

                    b.Property<decimal>("TotalPaid");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SomaliEbayProject.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Discount");

                    b.Property<byte[]>("Image");

                    b.Property<decimal>("Price");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<int>("Qty");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SomaliEbayProject.Models.Order", b =>
                {
                    b.HasOne("SomaliEbayProject.Models.Product", "Product")
                        .WithMany("Orders")
                        .HasForeignKey("ProductId");
                });
#pragma warning restore 612, 618
        }
    }
}
