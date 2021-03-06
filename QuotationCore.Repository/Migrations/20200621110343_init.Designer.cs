﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuotationCore.Repository;

namespace QuotationCore.Repository.Migrations
{
    [DbContext(typeof(QuotationCoreContext))]
    [Migration("20200621110343_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5");

            modelBuilder.Entity("QuotationCore.Domain.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Detailing")
                        .HasColumnType("TEXT");

                    b.Property<int>("NCM")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PartNumber")
                        .HasColumnType("TEXT");

                    b.Property<int>("QuotationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UnitOfMeasure")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("quantity")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("QuotationId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("QuotationCore.Domain.Quotation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Quotations");
                });

            modelBuilder.Entity("QuotationCore.Domain.Validation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("QuotationId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ResponseTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("QuotationId");

                    b.ToTable("Validations");
                });

            modelBuilder.Entity("QuotationCore.Domain.Item", b =>
                {
                    b.HasOne("QuotationCore.Domain.Quotation", "Quotation")
                        .WithMany()
                        .HasForeignKey("QuotationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuotationCore.Domain.Validation", b =>
                {
                    b.HasOne("QuotationCore.Domain.Quotation", "Quotation")
                        .WithMany()
                        .HasForeignKey("QuotationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
