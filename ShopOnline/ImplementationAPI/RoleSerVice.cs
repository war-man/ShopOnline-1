using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ShopOnline.Application.InterfaceAPI;
using ShopOnline.Application.Page;
using ShopOnline.Data;
using ShopOnline.Model.RoleModel;
using ShopOnline.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.ImplementationAPI
{
    public class RoleSerVice : IRoleSerVice
    {
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;
        public RoleSerVice(RoleManager<IdentityRole> roleManager, IMapper mapper, ApplicationDbContext context)
        {
            _context = context;
            _mapper = mapper;
            _roleManager = roleManager;
        }
        public async Task<bool> CheckPermission(string functionId, string action, IList<string> roles)
        {
            
            var functionTest = await _context.Functions.FindAsync(functionId);
            var functions = await _context.Functions.ToListAsync();
            var permissions = await _context.Permissions.ToListAsync();
            var listroles = await _context.Roles.ToListAsync();
            var query = from f in functions
                        join p in permissions on f.Id equals p.FunctionId
                        join r in listroles on p.RoleId equals r.Name
                        where roles.Contains(r.Name) && f.Id == functionId
                        && ((p.CanCreate && action == "Create")
                        || (p.CanUpdate && action == "Update")
                        || (p.CanDelete && action == "Delete")
                        || (p.CanRead && action == "Read"))
                        select p;
            var test = query.Any();
            return query.Any();
        }

        public async Task<bool> CreatRole(UpdateRole request)
        {
            if (request.RoleId != null)
            {
                var roleupdate = await _roleManager.FindByNameAsync(request.RoleId);
                roleupdate.Name = request.RoleName;
                await _roleManager.UpdateAsync(roleupdate);
                var listpermission = await _context.Permissions.Where(x => x.RoleId == request.RoleId).ToListAsync();
                foreach(var role in listpermission)
                {
                    
                    role.RoleId = request.RoleName;
                    _context.Permissions.Update(role);
                }
                await _context.SaveChangesAsync();
            }
            else
            {
                var role = new IdentityRole()
                {
                    Name = request.RoleName
                };
                var creat = await _roleManager.CreateAsync(role);
                if (creat.Succeeded)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
           
        }

        public async Task<bool> DeleteRole(string RoleId)
        {
            var role = await _roleManager.FindByIdAsync(RoleId);
            var delete = await _roleManager.DeleteAsync(role);
            if(delete.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<RoleViewModel> FindRoleById(string Id)
        {
            var role = await _roleManager.FindByIdAsync(Id);
            var roleVm = _mapper.Map<IdentityRole, RoleViewModel>(role);
            return roleVm;
        }

        public async Task<RoleViewModel> FindRoleByName(string RoleName)
        {
            var role = await _roleManager.FindByNameAsync(RoleName);
            var roleVm = _mapper.Map<IdentityRole, RoleViewModel>(role);
            return roleVm;
        }
        public async Task<List<RoleViewModel>> GetAllRole()
        {
            var listRole = await _roleManager.Roles.ToListAsync();
            var listRoleVM = _mapper.Map<List<IdentityRole>, List<RoleViewModel>>(listRole);
            return listRoleVM;
        }

        public async Task<PagedResult<RoleViewModel>> GetAllRolePaging(PageRequest request)
        {
            var listUser = await _roleManager.Roles.ToListAsync();


            var product = from p in listUser
                          select new { p };
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                product = product.Where(x => x.p.Name.Contains(request.Keyword));
            }
            var total = product.Count();
            var vt = product.Skip((request.PageIndex - 1) * (request.PageSize)).Take(request.PageSize)
                .Select(x => new RoleViewModel()
                {
                    RoleId = x.p.Id,
                    Name=x.p.Name
                }).ToList();
            var page = new PagedResult<RoleViewModel>()
            {
                Items = vt,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalRecords = total
            };
            return page;
        }
    }
}
