using System;

namespace PPM.UserAccess.Infrastructure.Documents
{
    public class UserDocument
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobPosition { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string[] Permssions { get; set; }
    }
}
