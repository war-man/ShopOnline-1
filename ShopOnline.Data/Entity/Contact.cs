using ShopOnline.Data.EntityComponent;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Data.Entity
{
    public class Contact : Common
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Alias { get; set; }
        public string Decripstion { get; set; }
    }
}
