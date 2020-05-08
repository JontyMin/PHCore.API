using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PH.DbContexts.Mappings
{
    using Entities.Core;
    using Entities;
    public class UserMap:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedNever();//不自动生成
            builder.HasIndex(c => c.Account).IsUnique();//指定索引
            builder.Property(c => c.Account).IsRequired().HasMaxLength(16);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Email).HasMaxLength(100);
            builder.Property(c => c.Phone).HasMaxLength(25);
            builder.Property(c => c.Email).HasMaxLength(100);
            builder.Property(c => c.Phone).HasMaxLength(25);
            builder.Property(c => c.Path).HasMaxLength(100);
            builder.Property(c => c.Motto).HasMaxLength(100);
            builder.Property(c => c.StatusCode).IsRequired().HasDefaultValue(StatusCode.Enable);
            builder.Property(c => c.Creator).IsRequired();
            builder.Property(c => c.CreateTime).IsRequired();
            builder.Property(c => c.Modifier);
            builder.Property(c => c.ModifyTime);
        }
    }
}
