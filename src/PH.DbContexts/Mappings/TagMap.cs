using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PH.DbContexts.Mappings
{
    using Entities;
    public class TagMap: IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tag");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedNever();
            builder.HasIndex(c => c.TagName).IsUnique();
            builder.Property(c => c.DisplayName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Description).HasMaxLength(200);
            builder.Property(c => c.Creator).IsRequired();
            builder.Property(c => c.CreateTime).IsRequired();
            builder.Property(c => c.Modifier);
            builder.Property(c => c.ModifyTime);
        }
    }
}
