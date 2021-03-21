using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Application.Page;
using ShopOnline.Model.UserModel;
using ShopOnline.Web.Authorization;
using ShopOnline.Web.ConnectAPI.InterfaceConnectAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserConnectAPI _userConnectAPI;
        public UserController(IUserConnectAPI  userConnectAPI, IHostingEnvironment hostingEnvironment, IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
            _hostingEnvironment = hostingEnvironment;
            _userConnectAPI = userConnectAPI;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _authorizationService.AuthorizeAsync(User, "PRODUCT", Operations.Read);
            if (result.Succeeded == false)
                return new RedirectResult("/Admin/Login/Login");
            return View();
        }
        public async Task<IActionResult> GetAllUserPaging(string keyword,int pageIndex,int pageSize)
        {
            var request = new PageRequest()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Keyword = keyword
            };
            var listuser = await _userConnectAPI.GetAllUserPaging(request);
            return new OkObjectResult(listuser);
        }
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var creat = await _userConnectAPI.Register(request);
            return Json(new
            {
                status = true,

            });
        }
        public async Task<IActionResult> GetListRoleOfUserByUserName(string UserName)
        {
            var user = await _userConnectAPI.FindUserByName(UserName);
            var listrole = await _userConnectAPI.GetListRoleOfUserByUserName(UserName);
            return Json(new
            {
                status = true,
                data = listrole,
                data1=user
            });
        }
        
        public async Task<IActionResult> DeleteUserByUserName(string UserName)
        {
           
            var username = await _userConnectAPI.DeleteUserByUserName(UserName);
            return Json(new
            {
                status = true
            });
        }
        public async Task<IActionResult> UpdateUser(UpdateUser request)
        {
            var update = await _userConnectAPI.UpdateUser(request);
            return Json(new
            {
                status = true
            });
        }
    }
}
