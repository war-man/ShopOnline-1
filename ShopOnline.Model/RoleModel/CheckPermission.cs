using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Model.RoleModel
{
    public class CheckPermission
    {
        public string FunctionId { get; set; }
        public string Action { get; set; }
        public IList<string> Roles { get; set; }
    }
}
