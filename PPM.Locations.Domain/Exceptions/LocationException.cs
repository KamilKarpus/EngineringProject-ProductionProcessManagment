using PPM.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PPM.Locations.Domain.Exceptions
{
    public class LocationException : PPMException
    {
        private readonly ErrorCodes _code;
        private readonly string _message;
        public LocationException(string message, ErrorCodes code) : base(message)
        {
            _code = code;
            _message = message;
        }

        public override string ExceptionMessage => _message;

        public override uint ExceptionCode => (uint)_code;
    }
}
