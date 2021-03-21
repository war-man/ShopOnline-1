using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Model.ProductModel
{
    public class CreatWholePrice
    {
        public int ProductId { get; set; }

        public int FromQuantity { get; set; }

        public int ToQuantity { get; set; }

        public decimal Price { get; set; }
    }
}
