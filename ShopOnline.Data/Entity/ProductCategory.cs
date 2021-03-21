using ShopOnline.Data.EntityComponent;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Data.Entity
{
    public class ProductCategory : Common
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Decripstion { get; set; }
        public string PathImage { get; set; }
        public int? ParentId { get; set; }
        public int SortOrder { set; get; }

        public List<Product> Products { get; set; }
    }
}
