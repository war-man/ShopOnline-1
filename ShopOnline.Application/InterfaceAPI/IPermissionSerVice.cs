using ShopOnline.Model.PermissionModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Application.InterfaceAPI
{
    public interface IPermissionSerVice
    {
        Task<List<PermissionViewModel>> GetAllPermission();
        Task<List<PermissionViewModel>> GetListPermissionFromRole(string RoleName);
        Task<int> CreatPermission(List<UpdatePerMission> ListCreat, string RoleName);
    }
}
