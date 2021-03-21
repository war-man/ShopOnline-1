using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopOnline.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Configuration
{
    public class WholePriceConfiguration : IEntityTypeConfiguration<WholePrice>
    {
        public void Configure(EntityTypeBuilder<WholePrice> builder)
        {
            builder.ToTable("WholePrices");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FromQuantity);
            builder.Property(x => x.ToQuantity);
            builder.Property(x => x.Price);
        }
    }
}
