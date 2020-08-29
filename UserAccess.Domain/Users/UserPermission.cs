using System.Collections.Generic;
using System.Linq;

namespace PPM.UserAccess.Domain.Users
{
    public class UserPermission
    {
        private static readonly List<UserPermission> _permissions = new List<UserPermission>()
        {
            View, EditFlow, CanExecuteFlow, ManageUsers, CanEditLocation
        };
        public static UserPermission View => new UserPermission("View");
        public static UserPermission EmployeeAcess => new UserPermission("EmployeeAcess");
        public static UserPermission EditFlow => new UserPermission("EditFlow");
        public static UserPermission CanExecuteFlow => new UserPermission("CanExecuteFlow");
        public static UserPermission ManageUsers => new UserPermission("ManageUsers");
        public static UserPermission CanEditLocation => new UserPermission("EditLocation");
        public string Permission { get; private set; }
        public UserPermission(string permission)
        {
            Permission = permission;
        }

        public static UserPermission Of(string permission)
        {
           return _permissions.FirstOrDefault(p => p.Permission == permission);
        }
        
    }
}