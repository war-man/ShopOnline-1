using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopOnline.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Configuration
{
    public class PageConfiguration : IEntityTypeConfiguration<Page>
    {
        public void Configure(EntityTypeBuilder<Page> builder)
        {
            builder.ToTable("Pages");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Alias).IsRequired();
            builder.Property(x => x.Decripstion).IsRequired();
            builder.Property(x => x.SeoAlias);
            builder.Property(x => x.SeoDescription);
            builder.Property(x => x.SeoKeywords);
            builder.Property(x => x.SeoPageTitle);
        }
    }
}
