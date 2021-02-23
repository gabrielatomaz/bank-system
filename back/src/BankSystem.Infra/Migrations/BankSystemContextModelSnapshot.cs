﻿// <auto-generated />
using System;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BankSystem.Infra.Migrations
{
    [DbContext(typeof(BankSystemContext))]
    partial class BankSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("BankSystem.Domain.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Agency")
                        .HasColumnType("int");

                    b.Property<double>("Balance")
                        .HasColumnType("double");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Agency = 1111,
                            Balance = 1500.0,
                            Number = 99999999,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("BankSystem.Domain.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.Property<double>("Value")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Transactions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountId = 1,
                            Date = new DateTime(2021, 2, 23, 15, 34, 14, 867, DateTimeKind.Local).AddTicks(4040),
                            Description = "Description Deposit",
                            TransactionType = 2,
                            Value = 1700.0
                        },
                        new
                        {
                            Id = 2,
                            AccountId = 1,
                            Date = new DateTime(2021, 2, 23, 15, 34, 14, 867, DateTimeKind.Local).AddTicks(5261),
                            Description = "Description Payment",
                            TransactionType = 0,
                            Value = 100.0
                        },
                        new
                        {
                            Id = 3,
                            AccountId = 1,
                            Date = new DateTime(2021, 2, 23, 15, 34, 14, 867, DateTimeKind.Local).AddTicks(5271),
                            Description = "Description Withdraw",
                            TransactionType = 1,
                            Value = 100.0
                        });
                });

            modelBuilder.Entity("BankSystem.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Gabriela"
                        });
                });

            modelBuilder.Entity("BankSystem.Domain.Account", b =>
                {
                    b.HasOne("BankSystem.Domain.User", "User")
                        .WithOne("Account")
                        .HasForeignKey("BankSystem.Domain.Account", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BankSystem.Domain.Transaction", b =>
                {
                    b.HasOne("BankSystem.Domain.Account", "Account")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("BankSystem.Domain.Account", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("BankSystem.Domain.User", b =>
                {
                    b.Navigation("Account");
                });
#pragma warning restore 612, 618
        }
    }
}
