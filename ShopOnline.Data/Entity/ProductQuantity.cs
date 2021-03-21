using ShopOnline.Data.EntityComponent;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Data.Entity
{
    public class ProductQuantity : Common
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ProductColorId { get; set; }
        public int ProductSizeId { get; set; }
        public int Quantity { get; set; }
    }
}
