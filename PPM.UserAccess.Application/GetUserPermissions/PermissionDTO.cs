namespace PPM.UserAccess.Application.GetUserPermissions
{
    public class PermissionDTO
    {
        public string PermissionName { get; set; }
        public PermissionDTO(string permissionName)
        {
            PermissionName = permissionName;
        }
    }
}
