using ShopOnline.Data.EntityComponent;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Data.Entity
{
    public class Payment : Common
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Decripstion { get; set; }
    }
}
