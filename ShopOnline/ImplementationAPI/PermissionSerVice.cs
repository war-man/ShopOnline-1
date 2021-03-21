using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Application.InterfaceAPI;
using ShopOnline.Data;
using ShopOnline.Data.Entity;
using ShopOnline.Model.PermissionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.ImplementationAPI
{
    public class PermissionSerVice : IPermissionSerVice
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public PermissionSerVice(ApplicationDbContext context, IMapper mapper,RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _mapper = mapper;
            _context = context;
        }

        public async Task<int> CreatPermission(List<UpdatePerMission> ListCreat, string RoleName)
        {
            var listpermissionRemove = await _context.Permissions.Where(x => x.RoleId == RoleName).ToListAsync();
            foreach(var remove in listpermissionRemove)
            {
                _context.Permissions.Remove(remove);

            }    
            foreach(var add in ListCreat)
            {
                var creat = new Permission()
                {
                    FunctionId = add.FunctionId,
                    RoleId = RoleName,
                    CanCreate = add.CanAdd,
                    CanDelete = add.CanDelete,
                    CanRead = add.CanRead,
                    CanUpdate = add.CanUpdate,
                };
                _context.Permissions.Add(creat);
                
            }
            return await _context.SaveChangesAsync();

        }

        public async Task<List<PermissionViewModel>> GetAllPermission()
        {
            var listpermission = await _context.Permissions.ToListAsync();
            var listpermissionVm = _mapper.Map<List<Permission>, List<PermissionViewModel>>(listpermission);
            return listpermissionVm;
        }

        public async Task<List<PermissionViewModel>> GetListPermissionFromRole(string RoleName)
        {
            var listperrmission = await _context.Permissions.Where(x => x.RoleId == RoleName).ToListAsync();
            var list = _mapper.Map<List<Permission>, List<PermissionViewModel>>(listperrmission);
            return list;
        }
    }
}
