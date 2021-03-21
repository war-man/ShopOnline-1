using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Model.PermissionModel
{
    public class UpdatePerMission
    {
        public string FunctionId { get; set; }
        public string RoleId { get; set; }
        public bool CanRead { get; set; }
        public bool CanDelete { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanAdd { get; set; }
    }
}
