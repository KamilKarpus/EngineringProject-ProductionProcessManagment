using PPM.Domain.Exceptions;

namespace PPM.Orders.Domain.Exceptions
{
    public class ProductionFlowException : PPMException
    {
        private ErrorCode _code;
        private string _message;
        public ProductionFlowException(string message, ErrorCode code) : base(message)
        {
            _code = code;
            _message = message;
        }

        public override string ExceptionMessage => _message;

        public override uint ExceptionCode => (uint)_code;
    }
}
