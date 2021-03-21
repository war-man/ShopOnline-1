using ShopOnline.Data.EntityComponent;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Data.Entity
{
    public class Product : Common
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal LastPrice { get; set; }
        public string PathImage { get; set; }
        public int ProductCategoryId { get; set; }
        public string Decripstion { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public List<ProductImage> ProductImages { get; set; }
    }
}
