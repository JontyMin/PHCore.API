using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PH.DbContexts.Mappings
{
    using Entities;
    public class ArticleMap:IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Article");
            builder.HasKey(c => c.Id);
            builder.Property(c =>c.Id).ValueGeneratedNever();
            builder.Property(c => c.UserId).IsRequired();
            builder.Property(c => c.ArtTitle).IsRequired().HasMaxLength(4000);
            builder.Property(c => c.Content).IsRequired().HasMaxLength(int.MaxValue);
            builder.Property(c => c.Views).IsRequired().HasDefaultValue(0);
            builder.Property(c => c.ArtComCount).IsRequired().HasDefaultValue(0);
            builder.Property(c => c.ArtLikeCount).IsRequired().HasDefaultValue(0);
            builder.Property(c => c.Creator).IsRequired();
            builder.Property(c => c.CreateTime).IsRequired();
            builder.Property(c => c.Modifier);
            builder.Property(c => c.ModifyTime);
            builder.HasOne(c => c.User);
        }
    }
}
