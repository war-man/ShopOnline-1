using ShopOnline.Data.EntityComponent;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Data.Entity
{
    public class Sort : Common
    {
        public int Id { get; set; }
        public int Page { get; set; }
        public string Name { get; set; }
    }
}
