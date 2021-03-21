using ShopOnline.Data.EntityComponent;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Data.Entity
{
    public class Slide : Common
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Decripstion { get; set; }
        public string Caption { get; set; }
        public int? ParentId { get; set; }
        public string PathImage { get; set; }
    }
}
