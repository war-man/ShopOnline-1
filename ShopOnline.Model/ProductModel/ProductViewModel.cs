using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Model.ProductModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal LastPrice { get; set; }
        public string PathImage { get; set; }
        public int ProductCategoryId { get; set; }
        public string Decripstion { get; set; }
        public string SeoPageTitle { set; get; }
        public string SeoAlias { set; get; }
        public string SeoKeywords { set; get; }
        public string SeoDescription { set; get; }
    }
}
