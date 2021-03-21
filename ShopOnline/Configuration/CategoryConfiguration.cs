using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopOnline.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.URL).IsRequired();
            builder.Property(x => x.Decripstion).IsRequired();
            builder.Property(x => x.SeoAlias);
            builder.Property(x => x.SeoDescription);
            builder.Property(x => x.SeoKeywords);
            builder.Property(x => x.SeoPageTitle);
        }
    }
}
