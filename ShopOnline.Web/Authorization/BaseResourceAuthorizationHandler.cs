using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using ShopOnline.Model.RoleModel;
using ShopOnline.Web.ConnectAPI.InterfaceConnectAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.Authorization
{
    public class BaseResourceAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, string>
    {
        private readonly IUserConnectAPI _userConnectAPI;
        private readonly IRoleConnectAPI _roleConnectAPI;
        public BaseResourceAuthorizationHandler(IUserConnectAPI userConnectAPI,IRoleConnectAPI roleConnectAPI)
        {
            _userConnectAPI = userConnectAPI;
            _roleConnectAPI = roleConnectAPI;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, string resource)
        {
            var roles = await _userConnectAPI.GetListRoleOfUserByUserName(context.User.Identity.Name);
            if (roles != null)
            {
                var listRole = roles;
                var request = new CheckPermission()
                {
                    FunctionId = resource,
                    Action = requirement.Name,
                    Roles = roles
                };
                var hasPermission = await _roleConnectAPI.CheckPermission(request);
                if (hasPermission || listRole.Contains(CommonConstants.AppRole.AdminRole))
                {
                    context.Succeed(requirement);
                }
                else
                {
                    context.Fail();
                }
            }
            else
            {
                context.Fail();
            }

        }
    }
}
