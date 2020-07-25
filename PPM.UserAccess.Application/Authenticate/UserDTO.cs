using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace PPM.UserAccess.Application.Authenticate
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobPosition { get; set; }
        public List<Claim> Claims { get; set; }
    }
}
