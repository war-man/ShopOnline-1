using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Model.ProductCategoryModel
{
    public class ProductCategoryUpdateParentId
    {
        public int SourceId { get; set; }
        public int TargetId { get; set; }
        public Dictionary<int, int> Items { get; set; }
    }
}
