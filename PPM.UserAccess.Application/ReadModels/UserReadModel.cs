using System;

namespace PPM.UserAccess.Application.ReadModels
{
    public class UserReadModel
    {
        public string Login { get;  set; }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobPosition { get; set; }
        public DateTime RegisterDate { get;set; }
        public string[] Permissions { get; set; }
    }
}
