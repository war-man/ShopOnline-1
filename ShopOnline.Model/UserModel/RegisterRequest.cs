using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Model.UserModel
{
    public class RegisterRequest
    {
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string  Value { get; set; }
        public string Password { get; set; }
    }
}
