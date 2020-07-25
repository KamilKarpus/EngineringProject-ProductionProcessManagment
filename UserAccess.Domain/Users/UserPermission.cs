namespace PPM.UserAccess.Domain.Users
{
    public class UserPermission
    {
        public static UserPermission View => new UserPermission("View");
        public string Permission { get; private set; }
        public UserPermission(string permission)
        {
            Permission = permission;
        }
        
    }
}