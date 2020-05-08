using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PH.DbContexts.Mappings
{
    using Entities;
    public class UserLoginMap: IEntityTypeConfiguration<UserLogin>
    {
        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {
            builder.ToTable("UserLogin");
            builder.HasKey(c => c.Account);
            builder.Property(c => c.Account).IsRequired().HasMaxLength(20);
            builder.Property(c => c.HashedPassword).IsRequired().HasMaxLength(256);
            builder.Property(c => c.LastLoginTime);
            builder.Property(c => c.AccessFailedCount).IsRequired().HasDefaultValue(0);
            builder.Property(c => c.IsLocked).IsRequired();
            builder.Property(c => c.LockedTime);
            builder.HasOne(c => c.User);
        }
    }
}
