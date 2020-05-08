using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PH.DbContexts.Mappings
{
    using Entities;
    public class ArticleCategoryMap : IEntityTypeConfiguration<ArticleCategory>
    {
        public void Configure(EntityTypeBuilder<ArticleCategory> builder)
        {
            builder.ToTable("ArticleCategory");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.ArticleId).IsRequired();
            builder.Property(c => c.CategoryId).IsRequired();
            builder.HasOne(c => c.Article);
            builder.HasOne(c => c.Category);

        }
    }
}
