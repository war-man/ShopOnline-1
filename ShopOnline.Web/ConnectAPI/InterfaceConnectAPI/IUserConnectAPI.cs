using ShopOnline.Application.Page;
using ShopOnline.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.ConnectAPI.InterfaceConnectAPI
{
    public interface IUserConnectAPI
    {
        Task<PagedResult<UserViewModel>> GetAllUserPaging(PageRequest request);
        Task<List<UserViewModel>> GetAllUser();
        Task<UserViewModel> FindUserById(string UserId);
        Task<UserViewModel> FindUserByName(string UserName);
        Task<bool> Register(RegisterRequest request);
        Task<string> Authentication(AuthenticationRequest request);
        Task<bool> DeleteUser(string UserId);
        Task<IList<string>> GetListRoleOfUserByUserName(string UserName);
        Task<bool> DeleteUserByUserName(string UserName);
        Task<bool> UpdateUser(UpdateUser request);
    }
}
