﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using rotating.Models;

namespace rotating.Migrations.Vibration
{
    [DbContext(typeof(VibrationContext))]
    [Migration("20201217052650_VibrationMigrations")]
    partial class VibrationMigrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("rotating.Models.Vibration", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("acc_status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("actual_vib")
                        .HasColumnType("real");

                    b.Property<int>("area_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<float>("dvn_a")
                        .HasColumnType("real");

                    b.Property<float>("dvn_ib")
                        .HasColumnType("real");

                    b.Property<float>("dvn_ibh")
                        .HasColumnType("real");

                    b.Property<float>("dvn_ibv")
                        .HasColumnType("real");

                    b.Property<float>("dvn_max")
                        .HasColumnType("real");

                    b.Property<float>("dvn_ob")
                        .HasColumnType("real");

                    b.Property<float>("dvn_obh")
                        .HasColumnType("real");

                    b.Property<float>("dvn_obv")
                        .HasColumnType("real");

                    b.Property<float>("dvr_a")
                        .HasColumnType("real");

                    b.Property<float>("dvr_ib")
                        .HasColumnType("real");

                    b.Property<float>("dvr_ibh")
                        .HasColumnType("real");

                    b.Property<float>("dvr_ibv")
                        .HasColumnType("real");

                    b.Property<float>("dvr_max")
                        .HasColumnType("real");

                    b.Property<float>("dvr_ob")
                        .HasColumnType("real");

                    b.Property<float>("dvr_obh")
                        .HasColumnType("real");

                    b.Property<float>("dvr_obv")
                        .HasColumnType("real");

                    b.Property<string>("indikasi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("last_date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("max_level")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("remark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("saran")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tag_no")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("upload_id")
                        .HasColumnType("int");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.Property<string>("vib_status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("vibrations");
                });
#pragma warning restore 612, 618
        }
    }
}
