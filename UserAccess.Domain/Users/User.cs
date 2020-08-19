using PPM.Domain;
using PPM.UserAccess.Domain.Users.DomainEvents;
using PPM.UserAccess.Domain.Users.Rules;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PPM.UserAccess.Domain.Users
{
    public class User : Entity
    {
        public Guid Id { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string JobPosition { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public List<UserPermission> Permissions { get; private set; }

        public User(Guid id, string login, string password, string firstName, string lastName, string jobPosition,
            IUserLoginAvailability counter)
        {
            Login = login;
            Id = id;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            JobPosition = jobPosition;
            RegistrationDate = DateTime.Now;
            Permissions = new List<UserPermission>();
            Permissions.Add(UserPermission.View);
            CheckRule(new UserLoginMustBeUniqueRule(counter, login));

            var @event = new UserCreatedDomainEvent()
            {
                Login = Login,
                UserId = Id,
                FirstName = FirstName,
                LastName = LastName,
                JobPosition = JobPosition,
                RegisterDate = RegistrationDate,
                Permissions = Permissions.Select(p => p.Permission).ToArray()
            };
            AddDomainEvent(@event);

        }
        public User(Guid id, string login, string password, string firstName, string lastName, string jobPosition,
            List<UserPermission> permissions, DateTime registerDate)
        {
            Login = login;
            Id = id;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            JobPosition = jobPosition;
            RegistrationDate = registerDate;
            Permissions = permissions;
        }
        public static User CreateUser(Guid id, string login, string password, string firstName, string lastName, string jobPostion, 
            IUserLoginAvailability counter)
        {
            return new User(id, login, password, firstName, lastName, jobPostion, counter);
        }

        public void ChangePermissions(IEnumerable<UserPermission> permissions)
        {
            Permissions = permissions.ToList();
            var @event = new UserPermissionChangedDomainEvent()
            {
                UserId = Id,
                Permissions = Permissions.Select(p => p.Permission).ToArray()
            };
            AddDomainEvent(@event);
        }

    }
}
