using PPM.Domain.Exceptions;
using UserAccess.Domain.Users.Rules;

namespace PPM.UserAccess.Domain.Users.Exception
{
    public class UserException : PPMException
    {
        private ErrorCodes _code;
        public UserException(string message, ErrorCodes code) : base(message)
        {
            _code = code;
        }
        public override string ExceptionMessage => Message;

        public override uint ExceptionCode => (uint)_code;
    }
}
