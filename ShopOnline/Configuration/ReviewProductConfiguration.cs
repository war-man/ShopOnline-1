using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopOnline.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Configuration
{
    public class ReviewProductConfiguration : IEntityTypeConfiguration<ReviewProduct>
    {
        public void Configure(EntityTypeBuilder<ReviewProduct> builder)
        {
            builder.ToTable("ReviewProducts");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DateCreated);
            builder.Property(x => x.UserName);
            builder.Property(x => x.EmailUser);
            builder.Property(x => x.PhoneNumberUser);
            builder.Property(x => x.Review);
            builder.Property(x => x.Quantity);
            builder.Property(x => x.ProductId);
        }
    }
}
