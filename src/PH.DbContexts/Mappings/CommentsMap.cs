using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PH.DbContexts.Mappings
{
    using Entities;
    public class CommentsMap: IEntityTypeConfiguration<Comments>
    {
        public void Configure(EntityTypeBuilder<Comments> builder)
        {
            builder.ToTable("Comments");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedNever();
            builder.Property(c => c.Id).ValueGeneratedNever();
            builder.Property(c => c.UserId).IsRequired();
            builder.Property(c => c.ArticleId).IsRequired();
            builder.Property(c => c.ComText).HasMaxLength(4000);
            builder.Property(c => c.ParentComId);
            builder.Property(c => c.Creator).IsRequired();
            builder.Property(c => c.CreateTime).IsRequired();
            builder.Property(c => c.Modifier);
            builder.Property(c => c.ModifyTime);

        }
    }
}
