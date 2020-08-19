using PPM.Domain;
using System;

namespace PPM.UserAccess.Domain.Users.DomainEvents
{
    public class UserPermissionChangedDomainEvent : DomainEventBase
    {
        public Guid UserId { get; internal set; }
        public string[] Permissions { get; internal set; }
    }
}
