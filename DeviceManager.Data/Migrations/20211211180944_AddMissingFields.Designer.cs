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
    [Migration("20211211180944_AddMissingFields")]
    partial class AddMissingFields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("DeviceGroup", b =>
                {
                    b.Property<int>("DevicesId")
                        .HasColumnType("integer")
                        .HasColumnName("devices_id");

                    b.Property<int>("GroupsId")
                        .HasColumnType("integer")
                        .HasColumnName("groups_id");

                    b.HasKey("DevicesId", "GroupsId")
                        .HasName("pk_device_group");

                    b.HasIndex("GroupsId")
                        .HasDatabaseName("ix_device_group_groups_id");

                    b.ToTable("device_group");
                });

            modelBuilder.Entity("DeviceManager.Core.Models.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Created")
                        .HasPrecision(0)
                        .HasColumnType("timestamp(0) without time zone")
                        .HasColumnName("created");

                    b.Property<string>("DisplayName")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("display_name");

                    b.Property<DateTime?>("LastModified")
                        .HasPrecision(0)
                        .HasColumnType("timestamp(0) without time zone")
                        .HasColumnName("last_modified");

                    b.Property<DateTime?>("LastSeen")
                        .HasPrecision(0)
                        .HasColumnType("timestamp(0) without time zone")
                        .HasColumnName("last_seen");

                    b.Property<int?>("LocationId")
                        .HasColumnType("integer")
                        .HasColumnName("location_id");

                    b.Property<string>("MacAddress")
                        .HasMaxLength(17)
                        .HasColumnType("character varying(17)")
                        .HasColumnName("mac_address");

                    b.Property<string>("Manufacturer")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("manufacturer");

                    b.Property<string>("Model")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("model");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<bool>("Online")
                        .HasColumnType("boolean")
                        .HasColumnName("online");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_devices");

                    b.HasAlternateKey("Name", "UserId")
                        .HasName("ak_devices_name_user_id");

                    b.HasIndex("LocationId")
                        .HasDatabaseName("ix_devices_location_id");

                    b.HasIndex("MacAddress")
                        .IsUnique()
                        .HasDatabaseName("ix_devices_mac_address");

                    b.ToTable("devices");
                });

            modelBuilder.Entity("DeviceManager.Core.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Created")
                        .HasPrecision(0)
                        .HasColumnType("timestamp(0) without time zone")
                        .HasColumnName("created");

                    b.Property<string>("DisplayName")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("display_name");

                    b.Property<DateTime?>("LastModified")
                        .HasPrecision(0)
                        .HasColumnType("timestamp(0) without time zone")
                        .HasColumnName("last_modified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_groups");

                    b.HasAlternateKey("Name", "UserId")
                        .HasName("ak_groups_name_user_id");

                    b.ToTable("groups");
                });

            modelBuilder.Entity("DeviceManager.Core.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Created")
                        .HasPrecision(0)
                        .HasColumnType("timestamp(0) without time zone")
                        .HasColumnName("created");

                    b.Property<string>("DisplayName")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("display_name");

                    b.Property<DateTime?>("LastModified")
                        .HasPrecision(0)
                        .HasColumnType("timestamp(0) without time zone")
                        .HasColumnName("last_modified");

                    b.Property<float?>("Latitude")
                        .HasColumnType("real")
                        .HasColumnName("latitude");

                    b.Property<float?>("Longitude")
                        .HasColumnType("real")
                        .HasColumnName("longitude");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)")
                        .HasColumnName("name");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_locations");

                    b.HasAlternateKey("Name", "UserId")
                        .HasName("ak_locations_name_user_id");

                    b.ToTable("locations");

                    b.HasCheckConstraint("ch_latitude_longitude_both_defined_or_undefined", "(latitude IS NULL AND longitude IS NULL) OR (latitude IS NOT NULL AND longitude IS NOT NULL)");
                });

            modelBuilder.Entity("DeviceManager.Core.Models.Sensor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Created")
                        .HasPrecision(0)
                        .HasColumnType("timestamp(0) without time zone")
                        .HasColumnName("created");

                    b.Property<int>("DeviceId")
                        .HasColumnType("integer")
                        .HasColumnName("device_id");

                    b.Property<string>("DisplayName")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("display_name");

                    b.Property<DateTime?>("LastModified")
                        .HasPrecision(0)
                        .HasColumnType("timestamp(0) without time zone")
                        .HasColumnName("last_modified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<int>("TypeId")
                        .HasColumnType("integer")
                        .HasColumnName("type_id");

                    b.HasKey("Id")
                        .HasName("pk_sensors");

                    b.HasAlternateKey("Name", "DeviceId")
                        .HasName("ak_sensors_name_device_id");

                    b.HasIndex("DeviceId")
                        .HasDatabaseName("ix_sensors_device_id");

                    b.HasIndex("TypeId")
                        .HasDatabaseName("ix_sensors_type_id");

                    b.HasIndex("Name", "DeviceId")
                        .IsUnique()
                        .HasDatabaseName("ix_sensors_name_device_id");

                    b.ToTable("sensors");
                });

            modelBuilder.Entity("DeviceManager.Core.Models.SensorType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Created")
                        .HasPrecision(0)
                        .HasColumnType("timestamp(0) without time zone")
                        .HasColumnName("created");

                    b.Property<string>("DisplayName")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("display_name");

                    b.Property<bool>("IsDiscrete")
                        .HasColumnType("boolean")
                        .HasColumnName("is_discrete");

                    b.Property<bool>("IsSummable")
                        .HasColumnType("boolean")
                        .HasColumnName("is_summable");

                    b.Property<DateTime?>("LastModified")
                        .HasPrecision(0)
                        .HasColumnType("timestamp(0) without time zone")
                        .HasColumnName("last_modified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)")
                        .HasColumnName("name");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)")
                        .HasColumnName("unit");

                    b.Property<string>("UnitShort")
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)")
                        .HasColumnName("unit_short");

                    b.Property<string>("UnitSymbol")
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)")
                        .HasColumnName("unit_symbol");

                    b.HasKey("Id")
                        .HasName("pk_sensor_types");

                    b.HasAlternateKey("Name")
                        .HasName("ak_sensor_types_name");

                    b.ToTable("sensor_types");
                });

            modelBuilder.Entity("DeviceGroup", b =>
                {
                    b.HasOne("DeviceManager.Core.Models.Device", null)
                        .WithMany()
                        .HasForeignKey("DevicesId")
                        .HasConstraintName("fk_device_group_devices_devices_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DeviceManager.Core.Models.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupsId")
                        .HasConstraintName("fk_device_group_groups_groups_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DeviceManager.Core.Models.Device", b =>
                {
                    b.HasOne("DeviceManager.Core.Models.Location", "Location")
                        .WithMany("Devices")
                        .HasForeignKey("LocationId")
                        .HasConstraintName("fk_devices_locations_location_id")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Location");
                });

            modelBuilder.Entity("DeviceManager.Core.Models.Sensor", b =>
                {
                    b.HasOne("DeviceManager.Core.Models.Device", "Device")
                        .WithMany("Sensors")
                        .HasForeignKey("DeviceId")
                        .HasConstraintName("fk_sensors_devices_device_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DeviceManager.Core.Models.SensorType", "Type")
                        .WithMany("Sensors")
                        .HasForeignKey("TypeId")
                        .HasConstraintName("fk_sensors_sensor_types_type_id")
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
