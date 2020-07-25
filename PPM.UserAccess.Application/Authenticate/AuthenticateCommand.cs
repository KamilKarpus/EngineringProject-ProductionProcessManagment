using PPM.UserAccess.Application.Configuration.Commands;

namespace PPM.UserAccess.Application.Authenticate
{
    public class AuthenticateCommand : ICommand<AuthenticationResult>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
