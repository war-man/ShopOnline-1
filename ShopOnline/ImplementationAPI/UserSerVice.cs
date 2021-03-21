
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using ShopOnline.Application.InterfaceAPI;
using ShopOnline.Application.Page;
using ShopOnline.Data;
using ShopOnline.Model.RoleModel;
using ShopOnline.Model.UserModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.ImplementationAPI
{
    public class UserSerVice : IUserSerVice
    {
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _config;
        private readonly ApplicationDbContext _context;
        public UserSerVice(ApplicationDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, IConfiguration config,IMapper mapper)
        {
            _mapper = mapper;
            _config = config;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
        }
        public async Task<string> Authentication(AuthenticationRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
            if (!result.Succeeded)
            {
                throw new Exception("Tk không tồn tại");
            }
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email,user.Email),

                new Claim(ClaimTypes.Role, string.Join(";",roles)),
                new Claim(ClaimTypes.Name, request.UserName)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> DeleteUser(string UserId)
        {
            var user = await _userManager.FindByIdAsync(UserId);
            var delete = await _userManager.DeleteAsync(user);
            if(delete.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteUserByUserName(string UserName)
        {
            var username = await _userManager.FindByNameAsync(UserName);
            var delete= await _userManager.DeleteAsync(username);
            if (delete.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<UserViewModel> FindUserById(string UserId)
        {
            var user = await _userManager.FindByIdAsync(UserId);
            var userVM = _mapper.Map<IdentityUser, UserViewModel>(user);
            return userVM;
        }

        public async Task<UserViewModel> FindUserByName(string UserName)
        {
            var user = await _userManager.FindByNameAsync(UserName);
            var userVM = _mapper.Map<IdentityUser, UserViewModel>(user);
            return userVM;
        }

        public async Task<List<UserViewModel>> GetAllUser()
        {
            var listUser = await _userManager.Users.ToListAsync();
            var listUserVM = _mapper.Map<List<IdentityUser>, List<UserViewModel>>(listUser);
            return listUserVM;
        }

        public async Task<PagedResult<UserViewModel>> GetAllUserPaging(PageRequest request)
        {
            var listUser = await _userManager.Users.ToListAsync();

            
            var product = from p in listUser
                          select new { p };
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                product = product.Where(x => x.p.UserName.Contains(request.Keyword));
            }
            var total = product.Count();
            var vt = product.Skip((request.PageIndex - 1) * (request.PageSize)).Take(request.PageSize)
                .Select(x => new UserViewModel()
                {
                    Id=x.p.Id,
                    UserId = x.p.Id,
                    UserName = x.p.UserName,
                    PhoneNumber = x.p.PhoneNumber,
                    Email = x.p.Email
                }).ToList();
            var page = new PagedResult<UserViewModel>()
            {
                Items = vt,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalRecords = total
            };
            return page;
        }

        public async Task<IList<string>> GetListRoleOfUserByUserName(string UserName)
        {
            var username = await _userManager.FindByNameAsync(UserName);
            var listrole = await _userManager.GetRolesAsync(username);
            return listrole;
        }

        public async Task<bool> Register(RegisterRequest request)
        {
            var listrole = JsonConvert.DeserializeObject<List<IdentityRole>>(request.Value).Select(x => x.Name).ToList();
            var user = new IdentityUser()
            {
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber,
                Email=request.Email
            };
            var create= await  _userManager.CreateAsync(user, request.Password);
            if(create.Succeeded==true)
            {
                var userM = await _userManager.FindByNameAsync(request.UserName);
                await _userManager.AddToRolesAsync(userM, listrole);
                return true;
            }
            else
            {
                return false;
            }
        }

        public  async Task<bool> UpdateUser(UpdateUser request)
        {
            var usernameUpdate = await _userManager.FindByNameAsync(request.UserLast);
            usernameUpdate.UserName = request.UserNow;
            usernameUpdate.PhoneNumber = request.PhoneNumber;
            usernameUpdate.Email = request.Email;
            await _userManager.UpdateAsync(usernameUpdate);
            var listrole = await _roleManager.Roles.Select(x => x.Name).ToListAsync();
            var username = await _userManager.FindByNameAsync(request.UserNow);
            await _userManager.RemoveFromRolesAsync(username, listrole);
            var listRoleadd = JsonConvert.DeserializeObject<List<IdentityRole>>(request.Value).Select(x => x.Name).ToList();
            await _userManager.AddToRolesAsync(username, listRoleadd);
            return true;
        }
    }
}
