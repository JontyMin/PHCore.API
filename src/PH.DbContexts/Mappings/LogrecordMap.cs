﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PH.DbContexts.Mappings
{
    using Entities;
    public class LogrecordMap:IEntityTypeConfiguration<Logrecord>
    {
        public void Configure(EntityTypeBuilder<Logrecord> builder)
        {
            builder.ToTable("Logrecord");
            builder.HasKey(c => c.Id);//自增主键
            builder.Property(c => c.LogDate).IsRequired();
            builder.Property(u => u.LogLevel).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Logger).IsRequired().HasMaxLength(256);
            builder.Property(u => u.Message);
            builder.Property(u => u.Exception);
            builder.Property(u => u.MachineName).HasMaxLength(50);
            builder.Property(u => u.MachineIp).HasMaxLength(50);
            builder.Property(u => u.NetRequestMethod).HasMaxLength(10);
            builder.Property(u => u.NetRequestUrl).HasMaxLength(500);
            builder.Property(u => u.NetUserIdentity).HasMaxLength(50);
        }
    }
}
