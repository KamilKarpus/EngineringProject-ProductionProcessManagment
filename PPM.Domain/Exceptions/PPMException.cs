using System;
namespace PPM.Domain.Exceptions
{
    public abstract class PPMException : Exception
    {
        public abstract string ExceptionMessage { get; }
        public abstract uint ExceptionCode { get; }
        public PPMException(string message) : base(message)
        {

        }
    }
}
