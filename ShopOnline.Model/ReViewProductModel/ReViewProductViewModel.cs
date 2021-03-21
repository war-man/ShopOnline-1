using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Model.ReViewProductModel
{
    public class ReViewProductViewModel
    {
        public int Id { get; set; }
        public string Review { get; set; }
        public DateTime DateCreated { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public string UserName { get; set; }
        public string EmailUser { get; set; }
        public string PhoneNumberUser { get; set; }
    }
}
