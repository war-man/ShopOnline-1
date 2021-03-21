using ShopOnline.Data.EntityComponent;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Data.Entity
{
    public class ProductImage : Common
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PathImage { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
