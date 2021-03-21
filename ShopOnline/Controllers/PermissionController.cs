using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Application.InterfaceAPI;
using ShopOnline.Model.PermissionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionSerVice _permissionSerVice;
        public PermissionController(IPermissionSerVice permissionSerVice)
        {
            _permissionSerVice = permissionSerVice;
        }    
        [HttpGet("GetAllPermission")]
        public async Task<IActionResult> GetAllPermission()
        {
            var listpermission = await _permissionSerVice.GetAllPermission();
            return Ok(listpermission);
        }
        [HttpPost("GetPermissionFromRole")]
        public async Task<IActionResult> GetPermissionFromRole([FromBody]string RoleName)
        {
            var list = await _permissionSerVice.GetListPermissionFromRole(RoleName);
            return Ok(list);
        }
        [HttpPost("CreatPermission")]
        public async Task<IActionResult> CreatPermission([FromBody]CreatPermissionViewModel request)
        {
            var creat = await _permissionSerVice.CreatPermission(request.ListCreat,request.RoleName);
            return Ok();
        }
    }
}
