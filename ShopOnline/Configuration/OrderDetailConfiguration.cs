using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopOnline.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Configuration
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetails");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ProductName).IsRequired();
            builder.Property(x => x.ProductPrice).IsRequired();
            builder.Property(x => x.ProductLastPrice).IsRequired();
            builder.Property(x => x.ProductQuantity).IsRequired();
            builder.Property(x => x.ProductId);
            builder.Property(x => x.ColorId);
            builder.Property(x => x.SizeId);
            builder.Property(x => x.OrderId);
            builder.Property(x => x.SeoAlias);
            builder.Property(x => x.SeoDescription);
            builder.Property(x => x.SeoKeywords);
            builder.Property(x => x.SeoPageTitle);
            builder.HasOne(x => x.Order).WithMany(x => x.OrderDetails).HasForeignKey(x => x.OrderId);
        }
    }
}
