using ShopOnline.Data.Entity;
using ShopOnline.Model.ProductModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Model.CartModel
{
    public class CartItem
    {
        public ProductViewModel ProductViewModel { get; set; }
        public int Quantity { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }

    }
}
