using PPM.Domain.Exceptions;

namespace PPM.Administration.Domain.Exceptions
{
    public class FlowException : PPMException
    {
        private readonly ErrorCodes _code;
        private readonly string _message;
        public FlowException(string message, ErrorCodes code) : base(message)
        {
            _code = code;
            _message = message;
        }

        public override string ExceptionMessage => _message;

        public override uint ExceptionCode => (uint)_code;
    }
}
