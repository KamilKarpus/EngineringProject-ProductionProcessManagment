using Microsoft.AspNetCore.Authorization;
using System;

namespace PPM.Api.Configuration.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class HasPermissionAttribute : AuthorizeAttribute
    {
        internal static string HasPermissionPolicyName = "HasPermission";
        public string PermissionName { get; }
        public HasPermissionAttribute(string permissionName) : base(HasPermissionPolicyName)
        {
            PermissionName = permissionName;
        }
    }
}
