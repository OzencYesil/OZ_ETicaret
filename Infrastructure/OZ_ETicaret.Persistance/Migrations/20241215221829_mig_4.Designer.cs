﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OZ_ETicaret.Persistance.Contexts;

#nullable disable

namespace OZ_ETicaret.Persistance.Migrations
{
    [DbContext(typeof(OzETicaretDbContext))]
    [Migration("20241215221829_mig_4")]
    partial class mig_4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("OZ_ETicaret.Domain.Entities.Common.FileEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("character varying(21)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Files");

                    b.HasDiscriminator().HasValue("FileEntity");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("OZ_ETicaret.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Category")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("Stock")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("OZ_ETicaret.Domain.Entities.InvoiceFile", b =>
                {
                    b.HasBaseType("OZ_ETicaret.Domain.Entities.Common.FileEntity");

                    b.Property<string>("InvoiceCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("InvoiceFile");
                });

            modelBuilder.Entity("OZ_ETicaret.Domain.Entities.ProductImageFile", b =>
                {
                    b.HasBaseType("OZ_ETicaret.Domain.Entities.Common.FileEntity");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uuid");

                    b.HasIndex("ProductId");

                    b.HasDiscriminator().HasValue("ProductImageFile");
                });

            modelBuilder.Entity("OZ_ETicaret.Domain.Entities.ProductImageFile", b =>
                {
                    b.HasOne("OZ_ETicaret.Domain.Entities.Product", null)
                        .WithMany("ProductImageFiles")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("OZ_ETicaret.Domain.Entities.Product", b =>
                {
                    b.Navigation("ProductImageFiles");
                });
#pragma warning restore 612, 618
        }
    }
}
