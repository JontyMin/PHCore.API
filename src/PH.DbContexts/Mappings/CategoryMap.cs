using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PH.DbContexts.Mappings
{
    using Entities;
    public class CategoryMap: IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedNever();
            builder.HasIndex(c => c.CatName).IsUnique();
            builder.Property(c => c.CatName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.DisplayName).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Description).HasMaxLength(200);
            builder.Property(c => c.Creator).IsRequired();
            builder.Property(c => c.CreateTime).IsRequired();
            builder.Property(c => c.Modifier);
            builder.Property(c => c.ModifyTime);

        }
    }
}
