using ShopOnline.Application.Page;
using ShopOnline.Model.RoleModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Application.InterfaceAPI
{
    public interface IRoleSerVice
    {
        Task<PagedResult<RoleViewModel>> GetAllRolePaging(PageRequest request);
        Task<List<RoleViewModel>> GetAllRole();
        Task<RoleViewModel> FindRoleById(string Id);
        Task<RoleViewModel> FindRoleByName(string RoleName);
        Task<bool> DeleteRole(string Id);
        Task<bool> CreatRole(UpdateRole request);
        Task<bool> CheckPermission(string functionId, string action, IList<string> roles);

    }
}
