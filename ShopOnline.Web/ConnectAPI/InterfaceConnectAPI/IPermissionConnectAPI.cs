using ShopOnline.Model.PermissionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.ConnectAPI.InterfaceConnectAPI
{
    public interface IPermissionConnectAPI
    {
        Task<List<PermissionViewModel>> GetAllPermission();
        Task<List<PermissionViewModel>> GetListPermissionFromRole(string RoleName);
        Task<bool> CreatPermission(CreatPermissionViewModel request);
    }
}
