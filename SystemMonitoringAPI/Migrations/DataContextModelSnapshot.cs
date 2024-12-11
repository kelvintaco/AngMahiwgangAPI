﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SystemMonitoringAPI.Context;

#nullable disable

namespace SystemMonitoringAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SystemMonitoringAPI.Models.Borrowers", b =>
                {
                    b.Property<string>("BrwCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BrwName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DprName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BrwCode");

                    b.ToTable("Borrowers");
                });

            modelBuilder.Entity("SystemMonitoringAPI.Models.DeletedTransactions", b =>
                {
                    b.Property<string>("DelTransID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateOnly?>("BorrowDate")
                        .HasColumnType("date");

                    b.Property<string>("BrwCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrwName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly?>("DateDeleted")
                        .HasColumnType("date");

                    b.Property<string>("DprName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemCode")
                        .HasColumnType("int");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DelTransID");

                    b.ToTable("DeletedTransactions");
                });

            modelBuilder.Entity("SystemMonitoringAPI.Models.Items", b =>
                {
                    b.Property<int>("ItemCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemCode"));

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ItemPrice")
                        .HasColumnType("float");

                    b.Property<string>("TransactionsTransID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("isnotonBorrow")
                        .HasColumnType("int");

                    b.Property<int>("onBorrow")
                        .HasColumnType("int");

                    b.HasKey("ItemCode");

                    b.HasIndex("TransactionsTransID");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("SystemMonitoringAPI.Models.Transactions", b =>
                {
                    b.Property<string>("TransID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateOnly?>("BorrowDate")
                        .HasColumnType("date");

                    b.Property<string>("BrwCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BrwName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("BrwName");

                    b.Property<string>("DprName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DprName");

                    b.Property<int>("ItemCode")
                        .HasColumnType("int");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ItemName");

                    b.HasKey("TransID");

                    b.HasIndex("BrwCode");

                    b.HasIndex("ItemCode");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("SystemMonitoringAPI.Models.Items", b =>
                {
                    b.HasOne("SystemMonitoringAPI.Models.Transactions", "Transactions")
                        .WithMany()
                        .HasForeignKey("TransactionsTransID");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("SystemMonitoringAPI.Models.Transactions", b =>
                {
                    b.HasOne("SystemMonitoringAPI.Models.Borrowers", "Borrowers")
                        .WithMany()
                        .HasForeignKey("BrwCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SystemMonitoringAPI.Models.Items", "Items")
                        .WithMany()
                        .HasForeignKey("ItemCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Borrowers");

                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
