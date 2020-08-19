using System;

namespace PPM.UserAccess.Application.ReadModels
{
    public class UserShortViewModel
    {
        public Guid Id { get; set; }
        public string Login { get;  set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobPosition { get;  set; }
        public DateTime RegistrationDate { get; set; }
    }
}
