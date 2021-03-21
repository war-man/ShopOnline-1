using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Model.FunctionModel
{
    public class FunctionViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string URL { set; get; }
        public string ParentId { set; get; }
        public int SortOrder { set; get; }
        public string IconCss { get; set; }
    }
}
