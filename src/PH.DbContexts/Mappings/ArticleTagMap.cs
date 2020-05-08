using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PH.DbContexts.Mappings
{
    using Entities;
    public class ArticleTagMap: IEntityTypeConfiguration<ArticleTag>
    {
        public void Configure(EntityTypeBuilder<ArticleTag> builder)
        {
            builder.ToTable("ArticleTag");
            builder.HasKey(c => c.ArticleId);
            builder.Property(c => c.ArticleId).IsRequired();
            builder.Property(c => c.TagId).IsRequired();
            builder.HasOne(c => c.Article);
            builder.HasOne(c => c.Tag);

        }
    }
}
