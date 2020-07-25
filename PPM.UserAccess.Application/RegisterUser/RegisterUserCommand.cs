using PPM.UserAccess.Application.Configuration.Commands;
using System;

namespace PPM.UserAccess.Application.RegisterUser
{
    public class RegisterUserCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobPosition { get; set; }
    }
}
