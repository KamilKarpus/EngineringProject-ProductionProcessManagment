using PPM.Domain.Exceptions;

namespace PPM.Printing.Domain.Exception
{
    public class PrintingException : PPMException
    {
        private readonly ErrorCodes _code;
        private readonly string _message;
        public PrintingException(string message, ErrorCodes code) : base(message)
        {
            _code = code;
            _message = message;
        }

        public override string ExceptionMessage => _message;

        public override uint ExceptionCode => (uint)_code;
    }
}
