using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Model.ProductImageModel
{
    public class ProductImageViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PathImage { get; set; }
        public int ProductId { get; set; }
    }
}
