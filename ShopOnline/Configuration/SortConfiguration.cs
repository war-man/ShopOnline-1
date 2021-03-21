using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopOnline.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Configuration
{
    public class SortConfiguration : IEntityTypeConfiguration<Sort>
    {
        public void Configure(EntityTypeBuilder<Sort> builder)
        {
            builder.ToTable("Sorts");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Page);
            builder.Property(x => x.Name);
        }
    }
}
