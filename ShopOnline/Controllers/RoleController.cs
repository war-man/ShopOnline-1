using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Application.InterfaceAPI;
using ShopOnline.Application.Page;
using ShopOnline.Model.RoleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleSerVice _roleSerVice;
        public RoleController(IRoleSerVice roleSerVice)
        {
            _roleSerVice = roleSerVice;
        }
        [HttpPost("GetAllRolePaging")]
        public async Task<IActionResult> GetAllRolePaging([FromBody]PageRequest request)
        {
            var listRole = await _roleSerVice.GetAllRolePaging(request);
            return Ok(listRole);
        }
        [HttpGet("GetAllRole")]
        public async Task<IActionResult> GetAllRole()
        {
            var listrole = await _roleSerVice.GetAllRole();
            return Ok(listrole);
        }
        [HttpPost("FindRoleById")]
        public async Task<IActionResult> FindRoleById([FromBody] string RoleId)
        {
            var role = await _roleSerVice.FindRoleById(RoleId);
            return Ok(role);
        }
        [HttpPost("FindRoleByName")]
        public async Task<IActionResult> FindRoleByName([FromBody] string RoleName)
        {
            var role = await _roleSerVice.FindRoleByName(RoleName);
            return Ok(role);
        }
        [HttpPost("DeleteRole")]
        public async Task<IActionResult> DeleteRole([FromBody] string RoleId)
        {
            var delete = await _roleSerVice.DeleteRole(RoleId);
            return Ok(delete);
        }
        [HttpPost("CreatRole")]
        public async Task<IActionResult> CreatRole(UpdateRole request)
        {
            var creat = await _roleSerVice.CreatRole(request);
            return Ok();
        }
        [HttpPost("CheckPermission")]
        public async Task<IActionResult> CheckPermission([FromBody]CheckPermission request)
        {
            var check = await _roleSerVice.CheckPermission(request.FunctionId,request.Action,request.Roles);
            return Ok(check);
        }
    }
}
