﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Model.UserModel
{
    
     public class AuthenticationRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
