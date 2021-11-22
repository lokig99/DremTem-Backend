﻿// <auto-generated />
using System;
using DeviceManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DeviceManager.Data.Migrations
{
    [DbContext(typeof(DeviceManagerContext))]
    [Migration("20211122011654_InitialModel")]
    partial class InitialModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("DeviceManager.Core.Models.Device", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Created")
                        .HasPrecision(0)
                        .HasColumnType("timestamp(0) without time zone");

                    b.Property<string>("DisplayName")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<DateTime?>("LastModified")
                        .HasPrecision(0)
                        .HasColumnType("timestamp(0) without time zone");

                    b.Property<DateTime?>("LastSeen")
                        .HasPrecision(0)
                        .HasColumnType("timestamp(0) without time zone");

                    b.Property<string>("LocationName")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<bool>("Online")
                        .HasColumnType("boolean");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("LocationName");

                    b.HasIndex("UserId", "LocationName");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("DeviceManager.Core.Models.Location", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<DateTime>("Created")
                        .HasPrecision(0)
                        .HasColumnType("timestamp(0) without time zone");

                    b.Property<string>("DisplayName")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<DateTime?>("LastModified")
                        .HasPrecision(0)
                        .HasColumnType("timestamp(0) without time zone");

                    b.Property<float?>("Latitude")
                        .HasColumnType("real");

                    b.Property<float?>("Longitude")
                        .HasColumnType("real");

                    b.HasKey("UserId", "Name");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("DeviceManager.Core.Models.Sensor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Created")
                        .HasPrecision(0)
                        .HasColumnType("timestamp(0) without time zone");

                    b.Property<long>("DeviceId")
                        .HasColumnType("bigint");

                    b.Property<string>("DisplayName")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<DateTime?>("LastModified")
                        .HasPrecision(0)
                        .HasColumnType("timestamp(0) without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.HasIndex("TypeName");

                    b.ToTable("Sensors");
                });

            modelBuilder.Entity("DeviceManager.Core.Models.SensorType", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<DateTime>("Created")
                        .HasPrecision(0)
                        .HasColumnType("timestamp(0) without time zone");

                    b.Property<string>("DataType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<bool>("IsDiscrete")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsSummable")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastModified")
                        .HasPrecision(0)
                        .HasColumnType("timestamp(0) without time zone");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("UnitShort")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.Property<string>("UnitSymbol")
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)");

                    b.HasKey("Name");

                    b.ToTable("SensorTypes");
                });

            modelBuilder.Entity("DeviceManager.Core.Models.Device", b =>
                {
                    b.HasOne("DeviceManager.Core.Models.Location", "Location")
                        .WithMany("Devices")
                        .HasForeignKey("UserId", "LocationName")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Location");
                });

            modelBuilder.Entity("DeviceManager.Core.Models.Sensor", b =>
                {
                    b.HasOne("DeviceManager.Core.Models.Device", "Device")
                        .WithMany("Sensors")
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DeviceManager.Core.Models.SensorType", "Type")
                        .WithMany("Sensors")
                        .HasForeignKey("TypeName")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Device");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("DeviceManager.Core.Models.Device", b =>
                {
                    b.Navigation("Sensors");
                });

            modelBuilder.Entity("DeviceManager.Core.Models.Location", b =>
                {
                    b.Navigation("Devices");
                });

            modelBuilder.Entity("DeviceManager.Core.Models.SensorType", b =>
                {
                    b.Navigation("Sensors");
                });
#pragma warning restore 612, 618
        }
    }
}
