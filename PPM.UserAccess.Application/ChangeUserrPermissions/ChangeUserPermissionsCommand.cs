using PPM.UserAccess.Application.Configuration.Commands;
using System;

namespace PPM.UserAccess.Application.ChangeUserrPermissions
{
    public class ChangeUserPermissionsCommand : ICommand
    {
        public Guid Id { get; set; }
        public string[] Permissions { get; set; }
    }
}
