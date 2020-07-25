using PPM.Domain;
using PPM.Domain.Exceptions;
using PPM.UserAccess.Domain.Users.Exception;
using UserAccess.Domain.Users.Rules;

namespace PPM.UserAccess.Domain.Users.Rules
{
    public class UserLoginMustBeUniqueRule : IBusinessRule
    {
        private readonly IUserLoginAvailability _loginAvailablity;
        private readonly string _login;
        public PPMException Exception => new UserException("User login is taken", ErrorCodes.LoginTaken);
        public UserLoginMustBeUniqueRule(IUserLoginAvailability loginAvailablity , string login)
        {
            _loginAvailablity = loginAvailablity;
            _login = login;
        }
        public bool IsBroken()
        {
            return _loginAvailablity.isAvailable(_login);
        }
    }
}
