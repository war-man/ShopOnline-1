using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Model.ProductCategoryModel
{
    public class CreatProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Decripstion { get; set; }
        public string PathImage { get; set; }
        public int? ParentId { get; set; }
        public int SortOrder { set; get; }
        public string SeoPageTitle { set; get; }
        public string SeoAlias { set; get; }
        public string SeoKeywords { set; get; }
        public string SeoDescription { set; get; }
    }
}
