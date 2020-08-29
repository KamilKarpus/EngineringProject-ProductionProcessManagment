using Microsoft.AspNetCore.Authorization;
using PPM.Application;
using PPM.UserAccess.Application;
using PPM.UserAccess.Application.GetUserPermissions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPM.Api.Configuration.Authorization
{
    public class HasPermissionAuthorizationHandler : AttributeAuthorizationHandler<HasPermissionAuthorizationRequirement, HasPermissionAttribute>
    {
        private readonly IUserAccessModule _module;
        private readonly IExecutionContextAccessor _executionContentAccessor;
        public HasPermissionAuthorizationHandler(IUserAccessModule module, IExecutionContextAccessor executionContextAccessor)
        {
            _module = module;
            _executionContentAccessor = executionContextAccessor;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, HasPermissionAuthorizationRequirement requirement, IEnumerable<HasPermissionAttribute> attributes)
        {
            var permissions = await _module.ExecuteQuery<List<PermissionDTO>>(new GetUserPermissionQuery() 
            {
                UserId = _executionContentAccessor.UserId
            });
            foreach(var atrribute in attributes)
            {
                if(!await AuthorizeAsync(atrribute.PermissionName, permissions))
                {
                    context.Fail();
                    return;
                }
            }
            context.Succeed(requirement);
        }


        private Task<bool> AuthorizeAsync(string permission, List<PermissionDTO> permissionDTOs)
        {
            if(permissionDTOs.Any(p=>p.PermissionName == permission))
            {
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}
