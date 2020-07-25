using PPM.UserAccess.Domain.Users;
using System.Linq;

namespace PPM.UserAccess.Infrastructure.Documents
{
    public static class Extensions
    {
        public static User AsEntity(this UserDocument user)
        {
            return new User(user.Id, user.Login, user.Password, user.FirstName, user.LastName,
                user.JobPosition, user.Permssions?.Select(p => new UserPermission(p)).ToList(), 
                user.RegistrationDate);
        }

        public static UserDocument ToDocument(this User user)
        {
            return new UserDocument()
            {
                Id = user.Id,
                Login = user.Login,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                JobPosition = user.JobPosition,
                Permssions = user.Permissions?.Select(p => p.Permission).ToArray(),
                RegistrationDate = user.RegistrationDate
            };
        }
    }
}
