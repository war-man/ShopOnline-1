using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Application.InterfaceAPI;
using ShopOnline.Application.Page;
using ShopOnline.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserSerVice _userSerVice;
        public UserController(IUserSerVice userSerVice)
        {
            _userSerVice = userSerVice;
        }
        [HttpPost("Authentication")]
        public async Task<IActionResult> Authentication([FromBody] AuthenticationRequest request)
        {
            var token = await _userSerVice.Authentication(request);
            return Ok(token);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var register = await _userSerVice.Register(request);
            return Ok(register);
        }
        [HttpPost("GetAllUserPaging")]
        public async Task<IActionResult> GetAllUserPaging([FromBody] PageRequest request)
        {
            var listUserPaging = await _userSerVice.GetAllUserPaging(request);
            return Ok(listUserPaging); 
        }
        [HttpPost("FindUserById")]
        public async Task<IActionResult> FindUserById([FromBody] string UserId)
        {
            var username = await _userSerVice.FindUserById(UserId);
            return Ok(username);
        }
        [HttpPost("FindUserByName")]
        public async Task<IActionResult> FindUserByName([FromBody] string UserName)
        {
            var username = await _userSerVice.FindUserByName(UserName);
            return Ok(username);
        }
        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAllUser()
        {
            var listUser = await _userSerVice.GetAllUser();
            return Ok(listUser);
        }
        [HttpPost("DeleteUser")]
        public async Task<IActionResult> DeleteUser([FromBody]string UserId)
        {
            var user = await _userSerVice.DeleteUser(UserId);
            return Ok(user);
        }
        [HttpPost("GetListRoleOfUserByUserName")]
        public async Task<IActionResult> GetListRoleOfUserByUserName([FromBody]string UserName)
        {
            var listrole = await _userSerVice.GetListRoleOfUserByUserName(UserName);
            return Ok(listrole);
        }
        [HttpPost("DeleteUserByUserName")]
        public async Task<IActionResult> DeleteUserByUserName([FromBody]string UserName)
        {
            var username = await _userSerVice.DeleteUserByUserName(UserName);
            return Ok();
        }
        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody]UpdateUser request)
        {
            var update = await _userSerVice.UpdateUser(request);
            return Ok();
        }
    } 
}
