﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockTradingSimulator.Models;

namespace StockTradingSimulator.Migrations.StockCandlesticks
{
    [DbContext(typeof(StockCandlesticksContext))]
    [Migration("20210225060815_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StockTradingSimulator.Models.Company", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName");

                    b.Property<DateTime>("StartDataDate");

                    b.Property<string>("TickerSymbol");

                    b.HasKey("ID");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("StockTradingSimulator.Models.StockCandlestick", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Close");

                    b.Property<int>("CompanyId");

                    b.Property<decimal>("High");

                    b.Property<decimal>("Low");

                    b.Property<decimal>("Open");

                    b.Property<DateTime>("Timestamp");

                    b.Property<int>("Volume");

                    b.HasKey("ID");

                    b.HasIndex("CompanyId");

                    b.ToTable("StockCandlestick");
                });

            modelBuilder.Entity("StockTradingSimulator.Models.StockCandlestick", b =>
                {
                    b.HasOne("StockTradingSimulator.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
