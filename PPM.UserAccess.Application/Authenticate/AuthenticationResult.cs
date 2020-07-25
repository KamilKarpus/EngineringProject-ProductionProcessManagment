namespace PPM.UserAccess.Application.Authenticate
{
    public class AuthenticationResult
    {
        public bool IsAuthenticate { get; }
        public string AuthenticateError {get; }
        public UserDTO User { get; }

        public AuthenticationResult(string error)
        {
            AuthenticateError = error;
            IsAuthenticate = false;
        }
        public AuthenticationResult(UserDTO user)
        {
            User = user;
            IsAuthenticate = true;
        }
    }
}
