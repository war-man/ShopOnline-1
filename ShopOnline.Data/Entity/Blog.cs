using ShopOnline.Data.EntityComponent;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Data.Entity
{
    public class Blog:Common
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Decripstion { get; set; }
        public DateTime DateTime { get; set; }
    }
}
