using ShopOnline.Data.EntityComponent;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Data.Entity
{
    public class Order : Common
    {
        public int Id { get; set; }
        public string CustomName { get; set; }
        public string CustoPhone { get; set; }
        public string CustomAdress { get; set; }
        public DateTime DateCreated { get; set; }
        public string UserName { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
