﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using rotating.Models;

namespace rotating.Migrations.User
{
    [DbContext(typeof(UserContext))]
    [Migration("20201220142743_UserMigrations")]
    partial class UserMigrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("rotating.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("nip")
                        .HasColumnType("int");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("users");

                    b.HasData(
                        new
                        {
                            id = 1,
                            created_at = new DateTime(2020, 12, 20, 0, 0, 0, 0, DateTimeKind.Local),
                            email = "yulianti@pertamina.com",
                            name = "Yulianti Eka Prista",
                            nip = 194020001,
                            password = "tyyyAbbeaMS4FBHCdvUaAC5a6THCA1zAf6rC/jghXtw=",
                            phone = "08821389745",
                            role = "engineer",
                            status = 1,
                            updated_at = new DateTime(2020, 12, 20, 0, 0, 0, 0, DateTimeKind.Local)
                        },
                        new
                        {
                            id = 2,
                            created_at = new DateTime(2020, 12, 20, 0, 0, 0, 0, DateTimeKind.Local),
                            email = "pratama@pertamina.com",
                            name = "Pratama Edi Saputra",
                            nip = 194020002,
                            password = "tyyyAbbeaMS4FBHCdvUaAC5a6THCA1zAf6rC/jghXtw=",
                            phone = "087985298445",
                            role = "engineer",
                            status = 1,
                            updated_at = new DateTime(2020, 12, 20, 0, 0, 0, 0, DateTimeKind.Local)
                        },
                        new
                        {
                            id = 3,
                            created_at = new DateTime(2020, 12, 20, 0, 0, 0, 0, DateTimeKind.Local),
                            email = "safril@pertamina.com",
                            name = "Safril Sidik",
                            nip = 194020003,
                            password = "tyyyAbbeaMS4FBHCdvUaAC5a6THCA1zAf6rC/jghXtw=",
                            phone = "088213669701",
                            role = "admin",
                            status = 1,
                            updated_at = new DateTime(2020, 12, 20, 0, 0, 0, 0, DateTimeKind.Local)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}