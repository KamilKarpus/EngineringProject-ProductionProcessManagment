using PPM.UserAccess.Application.Configuration.Queries;
using System;
using System.Collections.Generic;

namespace PPM.UserAccess.Application.GetUserPermissions
{
    public class GetUserPermissionQuery : IQuery<List<PermissionDTO>>
    {
        public Guid UserId { get; set; }
    }
}
