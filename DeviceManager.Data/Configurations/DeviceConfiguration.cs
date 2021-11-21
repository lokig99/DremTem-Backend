﻿using DeviceManager.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeviceManager.Data.Configurations
{
    public class DeviceConfiguration : IEntityTypeConfiguration<Device>
    {
        public const int NameMaxLength = 100;
        public const int DisplayNameMaxLenght = 150;
        public const int ApiKeyMaxLength = 64;
        public const int DateTimePrecision = 0;

        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder
                .HasKey(d => new { d.UserId, d.Name });

            builder
                .HasIndex(d => d.LocationName);

            builder
                .Property(d => d.Name)
                .HasMaxLength(NameMaxLength);

            builder
                .Property(d => d.DisplayName)
                .HasMaxLength(DisplayNameMaxLenght);

            builder
                .Property(d => d.ApiKey)
                .IsRequired()
                .HasMaxLength(ApiKeyMaxLength);

            builder
                .Property(d => d.Online)
                .IsRequired();

            builder
                .Property(d => d.LastSeen)
                .HasPrecision(DateTimePrecision);

            builder
                .Property(d => d.LastModified)
                .HasPrecision(DateTimePrecision);

            builder
                .Property(d => d.Created)
                .IsRequired()
                .HasPrecision(DateTimePrecision);

            builder
                .Property(d => d.LocationName)
                .HasMaxLength(LocationConfiguration.NameMaxLength);

            builder
                .HasOne(d => d.Location)
                .WithMany(l => l.Devices)
                .HasForeignKey(d => new { d.UserId, d.LocationName });
        }
    }
}