using ShopOnline.Data.EntityComponent;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Data.Entity
{
    public class Function : Common
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string URL { set; get; }
        public string ParentId { set; get; }
        public int SortOrder { set; get; }
        public string IconCss { get; set; }
    }
}
