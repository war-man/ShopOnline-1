using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Data.Entity
{
    public class Message
    {
        public int Id { get; set; }
        public  string UserName { get; set; }
        public string UserId { get; set; }
        public string Text { get; set; }
        public DateTime When { get; set; }
    }
}
