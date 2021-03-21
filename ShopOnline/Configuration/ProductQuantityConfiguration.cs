using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopOnline.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Configuration
{
    public class ProductQuantityConfiguration : IEntityTypeConfiguration<ProductQuantity>
    {
        public void Configure(EntityTypeBuilder<ProductQuantity> builder)
        {
            builder.ToTable("ProductQuantities");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ProductColorId);
            builder.Property(x => x.ProductSizeId);
            builder.Property(x => x.ProductId);
            builder.Property(x => x.Quantity);
        }
    }
}
