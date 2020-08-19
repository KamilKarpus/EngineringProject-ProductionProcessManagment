using PPM.Domain;
using System;

namespace PPM.UserAccess.Domain.Users.DomainEvents
{
    public class UserCreatedDomainEvent : DomainEventBase
    {
        public string Login { get; internal set; }
        public Guid UserId { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public string JobPosition { get; internal set; }
        public DateTime RegisterDate { get; internal set; }
        public string[] Permissions { get; internal set; }
    }
}
